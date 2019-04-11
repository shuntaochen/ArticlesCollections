using Abp;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Runtime;
using Abp.Runtime.Session;
using EP.Commons.Core.Configuration;
using EP.Commons.Core.Extensions;
using EP.DynamicForms.DynamicForm;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace EP.DynamicForms.Helpers
{


    public class MongoHelper : IMongoHelper, ITransientDependency //IDisposable,
    {
        #region Fields
        //数据项key
        private const string DataContextKey = "EP.DynamicForms.Helpers.MongoHelper";

        private const string TENANT_ID_KEY = "TenantId";

        private static IConfigurationRoot ConfigurationRoot => AppConfigurations.GetConfiguration(Commons.Core.Web.WebContentDirectoryFinder.CalculateContentRootFolder());

        private int? TenantId => GetCurrentItem(DataContextKey)?.Value ?? IocManager.Instance.Resolve<IAbpSession>()?.TenantId;

        private static readonly string MONGO_ADDRESS = ConfigurationRoot["ConnectionStrings:Mongodb"];

        private static readonly string databaseName = ConfigurationRoot["CustomConfig:Db:MongodbDBName"];

        protected IMongoClient _client;
        protected IMongoDatabase _database;
        #endregion


        #region Constructors

        public MongoHelper()
        {
            string dbname = databaseName;
            _client = new MongoClient(MONGO_ADDRESS);
            _database = _client.GetDatabase(dbname);
            EnsureCollectionsCreated();
            _dataContext = IocManager.Instance.Resolve<IAmbientDataContext>();
        }

        private void EnsureCollectionsCreated()
        {
            var collections = new string[] { nameof(MongoEditorTree), nameof(MongoFormListItem) };
            foreach (var name in collections)
            {
                var collection = _database.GetCollection<BsonDocument>(name);
                if (collection == null)
                    _database.CreateCollection(name);
            }
        }

        #endregion

        #region Select
        #region Select Count
        /// <summary>
        /// Returns the count of all recors in the specified collection
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public long? SelectCount(string collectionName, bool isMultitenancy = true)
        {
            try
            {
                var defFilter = new BsonDocument(); ;
                var collection = _database.GetCollection<BsonDocument>(collectionName);
                return collection.CountDocuments(isMultitenancy ? Builder.FilterEq("tenantId", TenantId) : defFilter);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Select count 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public long SelectCount(string collectionName, FilterDefinition<BsonDocument> filter, bool isMultitenancy = true)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            return collection.CountDocuments(filter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="field"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public long SelectCount(string collectionName, string field, string value, bool isMultitenancy = true)
        {
            var filter = Builder.FilterEq(field, value);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            return collection.CountDocuments(filter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long SelectCount(string collectionName, string field, ObjectId id, bool isMultitenancy = true)
        {
            var filter = Builder.FilterEq(field, id);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            return collection.CountDocuments(filter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long SelectCount<T>(string collectionName, string field, T value, bool isMultitenancy = true)
        {
            var filter = Builder.FilterEq<T>(field, value);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            return collection.CountDocuments(filter);
        }
        #endregion
        /// <summary>
        /// Returns a list of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> Select<T>(string collectionName, FilterDefinition<BsonDocument> filter, bool isMultitenancy = true)
        {
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var result = collection.Find(filter).ToList();
            List<T> returnList = new List<T>();
            foreach (var l in result)
            {
                returnList.Add(BsonSerializer.Deserialize<T>(l));
            }
            return returnList;
        }
        /// <summary>
        /// Select a single record of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T SelectOne<T>(string collectionName, FilterDefinition<BsonDocument> filter, bool isMultitenancy = true)
        {
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var result = collection.Find(filter).ToList();
            if (result.Count > 1)
            {
                throw new Exception("To many results");
            }
            var firstEl = result.ElementAt(0);
            return BsonSerializer.Deserialize<T>(firstEl);
        }
        public BsonDocument SelectOne(string collectionName, FilterDefinition<BsonDocument> filter, bool isMultitenancy = true)
        {
            if (isMultitenancy) ApplyMultiTenantFilter(ref filter);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var set = collection.Find(filter);
            return set.FirstOrDefault();
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a BsonDocument 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public void Insert(string collectionName, BsonDocument doc, bool isMultitenancy = true)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            if (isMultitenancy) AttachTenantIdToData(ref doc);
            collection.InsertOne(doc);
        }
        /// <summary>
        /// Insert an object of any type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public void Insert<T>(string collectionName, T doc, bool isMultitenancy = true)
        {

            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var bson = doc.ToBsonDocument();
            if (isMultitenancy)
                AttachTenantIdToData(ref bson);
            collection.InsertOne(bson);

        }
        /// <summary>
        /// Insert multiple objects into a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
        public void InsertMany<T>(string collectionName, IEnumerable<T> documents, bool isMultitenancy = true)
        {

            List<BsonDocument> docs = new List<BsonDocument>();
            for (int i = 0; i < documents.Count(); i++)
            {
                var doc = documents.ElementAt(i).ToBsonDocument();
                if (isMultitenancy)
                    AttachTenantIdToData(ref doc);
                docs[i] = doc;
            }
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertMany(docs);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public void UpdateOne(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update, bool isMultitenancy = true)
        {
            if (isMultitenancy)
            {
                ApplyMultiTenantFilter(ref filter);
            }
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="fieldName">The field name to identify the object to be updated</param>
        /// <param name="value">The value to the identifier field</param>
        /// <param name="update"></param>
        /// <returns></returns>
        public void UpdateOne(string collectionName, string fieldName, string value, UpdateDefinition<BsonDocument> update, bool isMultitenancy = true)
        {
            var filter = Builder.FilterEq(fieldName, value);
            if (isMultitenancy)
            {
                ApplyMultiTenantFilter(ref filter);
            }
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Update an Array inside an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="arrayField"></param>
        /// <param name="list"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public void UpdateArray<T>(string collectionName, string arrayField, List<T> list, FilterDefinition<BsonDocument> filter, bool isMultitenancy = true)
        {
            if (isMultitenancy)
            {
                ApplyMultiTenantFilter(ref filter);
            }
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var update = Builders<BsonDocument>.Update.PushEach(arrayField, list);
            collection.FindOneAndUpdate<BsonDocument>(filter, update);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Remove objects by condition
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public void Delete(string collectionName, FilterDefinition<BsonDocument> filter, bool isMultiTenancy = true)
        {
            if (isMultiTenancy)
            {
                ApplyMultiTenantFilter(ref filter);
            }
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.DeleteMany(filter);
        }

        /// <summary>
        /// Remove an object from a collection
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Delete(string collectionName, string fieldName, string value, bool isMultiTenancy = true)
        {
            var filter = Builder.FilterEq(fieldName, value);
            if (isMultiTenancy)
            {
                ApplyMultiTenantFilter(ref filter);
            }
            Delete(collectionName, filter);
        }
        #endregion





        #region 多租户过滤器
        private void ApplyMultiTenantFilter(ref FilterDefinition<BsonDocument> filter)
        {
            filter = filter & Builder.FilterEq(TENANT_ID_KEY, TenantId);
        }

        private void AttachTenantIdToData(ref BsonDocument bsonElements)
        {
            bsonElements["tenantId"] = TenantId;
        }

        #endregion

        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}


        public IDisposable Use(int? tenantId)
        {
            var item = new ScopeItem(tenantId, GetCurrentItem(DataContextKey));

            string key = item.Id;
            if (!ConcurrentItems.TryAdd(key, item))
            {
                throw new AbpException("Can not add item! ConcurrentItems.TryAdd returns false!");
            }

            _dataContext.SetData(DataContextKey, key);

            return new DisposeAction(() =>
            {
                ConcurrentItems.TryRemove(key, out item);
                if (item == null)
                {
                    _dataContext.SetData(DataContextKey, null);
                    return;
                }
                _dataContext.SetData(DataContextKey, item.Outer?.Id);
            });
        }

        private static ConcurrentDictionary<string, ScopeItem> ConcurrentItems { get; set; } = new ConcurrentDictionary<string, ScopeItem>();
        private IAmbientDataContext _dataContext;

        private ScopeItem GetCurrentItem(string contextKey)
        {
            var objKey = _dataContext.GetData(contextKey) as string;
            return objKey != null ? ConcurrentItems.GetValueOrDefault(objKey) : null;
        }

        private class ScopeItem
        {
            public string Id { get; }

            public ScopeItem Outer { get; }

            public dynamic Value { get; }

            public ScopeItem(dynamic value, ScopeItem outer = null)
            {
                Id = Guid.NewGuid().ToString();

                Value = value;
                Outer = outer;
            }
        }
    }






}


//data context is a a wrapper of concurrent dictionary that uses AsyncLocal<string> as data type and string as key
//# using System.Collections.Concurrent;
using System.Threading;
using Abp.Dependency;

namespace Abp.Runtime.Remoting
{
    public class AsyncLocalAmbientDataContext : IAmbientDataContext, ISingletonDependency
    {
        private static readonly ConcurrentDictionary<string, AsyncLocal<object>> AsyncLocalDictionary = new ConcurrentDictionary<string, AsyncLocal<object>>();

        public void SetData(string key, object value)
        {
            var asyncLocal = AsyncLocalDictionary.GetOrAdd(key, (k) => new AsyncLocal<object>());
            asyncLocal.Value = value;
        }

        public object GetData(string key)
        {
            var asyncLocal = AsyncLocalDictionary.GetOrAdd(key, (k) => new AsyncLocal<object>());
            return asyncLocal.Value;
        }
    }
}
