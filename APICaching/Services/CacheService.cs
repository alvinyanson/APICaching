using APICaching.Interface;
using StackExchange.Redis;
using System.Text.Json;

namespace APICaching.Services
{
    public class CacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }


        public T Get<T>(string key)
        {
            var value = _cacheDb.StringGet(key);

            if(!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);

            return default;
        }

        public object Remove(string key)
        {
            var exist = _cacheDb.KeyExists(key);

            if(exist)
                _cacheDb.KeyDelete(key);

            return false;
        }

        public bool Set<T>(string key, T value, DateTimeOffset expiration)
        {
            var expiryTime = expiration.DateTime.Subtract(DateTime.Now);
         
            return _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expiryTime);
        }
    }
}
