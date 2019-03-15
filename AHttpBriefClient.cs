using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Abp.Configuration;
using EP.Commons.Rest.Extension;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json.Linq;

namespace EP.ConfigCenter.Configuration
{

    [BaseUri("http://localhost:18040/")]
    public interface ISettingsAppService
    {
        Task Create(SettingInfo setting);
        Task Delete(SettingInfo setting);
        Task<List<SettingInfo>> GetAllList();
        Task<string> GetSetting(string name);
        Task Update(SettingInfo setting);
    }

    public class AllMightyRestClient : DynamicObject
    {
        private HttpClient _httpClient;
        private string _serviceName;


        public AllMightyRestClient Init<T>()
        {
            _serviceName = nameof(T).TrimStart('I').Replace("appservice", "", StringComparison.OrdinalIgnoreCase);
            var ret = new HttpClient();

            if (typeof(T).IsInterface && typeof(T).IsDefined(typeof(T), inherit: false))
            {
                var attrs = typeof(T).GetCustomAttributes(false);
                var baseUri = attrs.First(at => at.GetType() == typeof(BaseUriAttribute)) as BaseUriAttribute;
                ret = new HttpClient { BaseAddress = new Uri(baseUri.BaseUri.TrimEnd('/') + "/") };
            }
            _httpClient = ret;

            return this;
        }


        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var path = $"api/services/app/{_serviceName}/{binder.Name}";

            result = ConventionlyIssue(path, binder.Name, args);
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return base.TryGetMember(binder, out result);
        }


        protected string ConventionlyIssue(string path, string methodName, object[] args)
        {
            HttpMethod httpMethod = GetHttpMethodTypeByConvension(methodName);
            var httpMessage = new HttpRequestMessage(httpMethod, path)
            {
                Content = args[0].ToJsonStringContent()
            };
            var ret = "";
            this.SafelyRun(() =>
            {
                ret = _httpClient.SendAsync(httpMessage).Result.Content.ReadAsStringAsync().Result;
            });

            return ret;
        }

        private HttpMethod GetHttpMethodTypeByConvension(string methodName)
        {
            var lowerMN = methodName.ToLower();
            if (lowerMN.StartsWith("g"))
                return HttpMethod.Get;
            if (lowerMN.StartsWith("pu"))
                return HttpMethod.Get;
            if (lowerMN.StartsWith("po"))
                return HttpMethod.Get;
            if (lowerMN.StartsWith("d"))
                return HttpMethod.Delete;
            return HttpMethod.Post;
        }
    }


    [AttributeUsage(AttributeTargets.Interface)]
    public class BaseUriAttribute : Attribute
    {
        public BaseUriAttribute(string baseUri)
        {
            BaseUri = baseUri;
        }
        public string BaseUri { get; private set; }
    }
}
