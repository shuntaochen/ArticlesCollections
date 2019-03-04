### Load Configuration In DotnetCore with onload and load to replace configs fetched from consul
---
1. Configuration provider
```
public class ConsulConfigurationProvider : ConfigurationProvider
{
    private const string ConsulIndexHeader = "X-Consul-Index";

    private readonly string _path;
    private readonly HttpClient _httpClient;
    private readonly IReadOnlyList<Uri> _consulUrls;
    private readonly Task _configurationListeningTask;
    private int _consulUrlIndex;
    private int _failureCount;
    private int _consulConfigurationIndex;

    public ConsulConfigurationProvider(IEnumerable<Uri> consulUrls, string path)
    {
        _path = path;
        _consulUrls = consulUrls.Select(u => new Uri(u, $"v1/kv/{path}")).ToList();

        if (_consulUrls.Count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(consulUrls));
        }

        _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip }, true);
        _configurationListeningTask = new Task(ListenToConfigurationChanges);
    }

    public override void Load() => LoadAsync().ConfigureAwait(false).GetAwaiter().GetResult();

    private async Task LoadAsync()
    {
        Data = await ExecuteQueryAsync();

        if (_configurationListeningTask.Status == TaskStatus.Created)
            _configurationListeningTask.Start();
    }

    private async void ListenToConfigurationChanges()
    {
        while (true)
        {
            try
            {
                if (_failureCount > _consulUrls.Count)
                {
                    _failureCount = 0;
                    await Task.Delay(TimeSpan.FromMinutes(1));
                }

                Data = await ExecuteQueryAsync(true);
                OnReload();
                _failureCount = 0;
            }
            catch (TaskCanceledException)
            {
                _failureCount = 0;
            }
            catch
            {
                _consulUrlIndex = (_consulUrlIndex + 1) % _consulUrls.Count;
                _failureCount++;
            }
        }
    }

    private async Task<IDictionary<string, string>> ExecuteQueryAsync(bool isBlocking = false)
    {
        var requestUri = isBlocking ? $"?recurse=true&index={_consulConfigurationIndex}" : "?recurse=true";
        using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(_consulUrls[_consulUrlIndex], requestUri)))
        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            if (response.Headers.Contains(ConsulIndexHeader))
            {
                var indexValue = response.Headers.GetValues(ConsulIndexHeader).FirstOrDefault();
                int.TryParse(indexValue, out _consulConfigurationIndex);
            }

            var tokens = JToken.Parse(await response.Content.ReadAsStringAsync());
            return tokens
                .Select(k => KeyValuePair.Create
                    (
                        k.Value<string>("Key"),//.Substring(_path.Length + 1),
                        k.Value<string>("Value") != null ? JToken.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(k.Value<string>("Value")))) : null
                    ))
                .Where(v => !string.IsNullOrWhiteSpace(v.Key))
                .SelectMany(Flatten)
                .ToDictionary(v => ConfigurationPath.Combine(v.Key.Split('/')), v => v.Value, StringComparer.OrdinalIgnoreCase);
        }
    }

    public static IEnumerable<KeyValuePair<string, string>> Flatten(KeyValuePair<string, JToken> tuple)
    {
        if (!(tuple.Value is JObject value))
            yield break;

        foreach (var property in value)
        {
            var propertyKey = $"{tuple.Key}/{property.Key}";
            switch (property.Value.Type)
            {
                case JTokenType.Object:
                    foreach (var item in Flatten(KeyValuePair.Create(propertyKey, property.Value)))
                        yield return item;
                    break;
                case JTokenType.Array:
                    break;
                default:
                    yield return KeyValuePair.Create(propertyKey, property.Value.Value<string>());
                    break;
            }
        }
    }
}
```
2. Configuration source
```
public class ConsulConfigurationSource : IConfigurationSource
{
    public IEnumerable<Uri> ConsulUrls { get; }
    public string Path { get; }

    public ConsulConfigurationSource(IEnumerable<Uri> consulUrls, string path)
    {
        ConsulUrls = consulUrls;
        Path = path;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new ConsulConfigurationProvider(ConsulUrls, Path);
    }
}
```
3. Extensions
```
public static class ConsulConfigurationExtensions
{
    public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, IEnumerable<Uri> consulUrls, string consulPath)
    {
        return configurationBuilder.Add(new ConsulConfigurationSource(consulUrls, consulPath));
    }

    public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, IEnumerable<string> consulUrls, string consulPath)
    {
        return configurationBuilder.AddConsul(consulUrls.Select(u => new Uri(u)), consulPath);
    }
}
```
4. Configure entry
```
//appsettings.json
{"CONSUL_URL":"{http://consulurl/}","CONSUL_PATH":"{keyname}"}
```
```
public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cb =>
        {
            var configuration = cb.Build();
            cb.AddConsul(new[] { configuration.GetValue<Uri>("CONSUL_URL") }, configuration.GetValue<string>("CONSUL_PATH"));
        })
        .UseStartup<Startup>()
        .Build();
```
5. Usage
```
var Configuration=IocManager.Resolve<IConfiguration>();//or use ctor injection or property injection
var flattenedValue=Configuration["key"];
var kvs=new ConsulConfigurationProvider(Configuration["CONSUL_URL"],Configuration["CONSUL_PATH"]);
```

### Consul deregister a service
```
#Last param is service live Id under each service
curl --request PUT http://192.168.1.7:8500/v1/agent/service/deregister/ConfigCenter_127_0_0_1_18035
```
