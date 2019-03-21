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
    public interface ISettings
    {
        object Create(SettingInfo setting);
        object Delete(SettingInfo setting);
        object GetAllList();
        object GetSetting(string name);
        object Update(SettingInfo setting);
    }

    public class AllMightyRestClient<T> : DynamicObject
    {
        private HttpClient _httpClient;
        private string _serviceName;

        public AllMightyRestClient()
        {
            _serviceName = typeof(T).Name.TrimStart('I').Replace("appservice", "", StringComparison.OrdinalIgnoreCase);
            var ret = new HttpClient();

            if (typeof(T).IsInterface)
            {
                var attrs = typeof(T).GetCustomAttributes(false);
                var baseUri = attrs.First(at => at.GetType() == typeof(BaseUriAttribute)) as BaseUriAttribute;
                ret = new HttpClient { BaseAddress = new Uri(baseUri.BaseUri.TrimEnd('/') + "/") };
            }
            _httpClient = ret;
        }


        //public AllMightyRestClient Init<T>()
        //{
        //    _serviceName = nameof(T).TrimStart('I').Replace("appservice", "", StringComparison.OrdinalIgnoreCase);
        //    var ret = new HttpClient();

        //    if (typeof(T).IsInterface && typeof(T).IsDefined(typeof(T), inherit: false))
        //    {
        //        var attrs = typeof(T).GetCustomAttributes(false);
        //        var baseUri = attrs.First(at => at.GetType() == typeof(BaseUriAttribute)) as BaseUriAttribute;
        //        ret = new HttpClient { BaseAddress = new Uri(baseUri.BaseUri.TrimEnd('/') + "/") };
        //    }
        //    _httpClient = ret;
        //    return this;
        //}


        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var path = $"api/services/app/{_serviceName}/{binder.Name}";

            result = ConventionlyIssue(path, binder.Name, args);
            this._result = result;
            return true;
        }

        protected object _result;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _result;
            return true;
        }


        protected string ConventionallyIssue(string path, string methodName, object[] args)
        {
            HttpMethod httpMethod = GetHttpMethodTypeByConvension(methodName);
            HttpContent content;
            if (httpMethod == HttpMethod.Get) content = args[0]?.ToFormUrlEncodedContent();
            else content = args[0]?.ToJsonStringContent();
            var httpMessage = new HttpRequestMessage(httpMethod, path)
            {
                Content = content
            };
            var ret = "";
            this.SafelyRun(() =>
            {
                var retr = this.Sync(_httpClient.SendAsync(httpMessage));
                ret = this.Sync(retr.Content.ReadAsStringAsync());
            });

            return ret;
        }

        private HttpMethod GetHttpMethodTypeByConvension(string methodName)
        {
            var lowerMN = methodName.ToLower();
            if (lowerMN.StartsWith("get"))
                return HttpMethod.Get;
            if (lowerMN.StartsWith("pu"))
                return HttpMethod.Put;
            if (lowerMN.StartsWith("po"))
                return HttpMethod.Post;
            if (lowerMN.StartsWith("del"))
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



//Below to create type that implements interface with Expression
public static Func<object[], IMyInterface> BuildFactoryExpression(ConstructorInfo ctor)
{
    ParameterInfo[] par = ctor.GetParameters(); // Get the parameters of the constructor
    Expression[] args = new Expression[par.Length];
    ParameterExpression param = Expression.Parameter(typeof(object[])); // The object[] paramter to the Func
    for (int i = 0; i != par.Length; ++i)
    {
        // get the item from the array in the parameter and cast it to the correct type for the constructor
        args[i] = Expression.Convert(Expression.ArrayIndex(param, Expression.Constant(i)), par[i].ParameterType);
    }
    return Expression.Lambda<Func<object[], IMyInterface>>(
        // call the constructor and cast to IMyInterface.
        Expression.Convert(
            Expression.New(ctor, args)
        , typeof(IMyInterface)
        ), param
    ).Compile();
}

//walk through of how to use dynamic object
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/walkthrough-creating-and-using-dynamic-objects
//Third part of convert dynamicobject to interface type
https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject.tryconvert?view=netframework-4.7.2
//Using assembly builder and type builders
...
// And the ultimate solution to create an object of an interface is to write concrete method and use ilspy.exe to view il generated code.
// Then use ILGenerator to generate the class and code. What a shame, but have no idea what IL code really means, no need to bother the meaning anyway.

//The castle project can create proxy of an interface without target, can specify the invocations!
    
            var pg = new ProxyGenerator();

            var tp = typeof(TInterface);

            var ret = pg.CreateInterfaceProxyWithoutTarget(tp);
