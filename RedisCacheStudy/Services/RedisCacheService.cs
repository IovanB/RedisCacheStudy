using RedisCacheStudy.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisCacheStudy.Services
{
    public class RedisCacheService(IConnectionMultiplexer connection) : IRedisCacheService
    {
        private readonly IDatabase _database = connection.GetDatabase();

        public async Task<T?> GetCacheValueAsync<T>(string key)
        {
            var jsonValue = await _database.StringGetAsync(key);
            return jsonValue.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(jsonValue);
        }

        public async Task SetCacheValueAsync<T>(string key, T value)
        {
            var jsonValue = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(key, jsonValue, TimeSpan.FromMinutes(2)); 
        }
    }
}
