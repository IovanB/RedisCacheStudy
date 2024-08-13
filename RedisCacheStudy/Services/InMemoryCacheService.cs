using Microsoft.Extensions.Caching.Memory;
using RedisCacheStudy.Interfaces;
using System.Text.Json;

namespace RedisCacheStudy.Services
{
    public class InMemoryCacheService(IMemoryCache memoryCache) : ICacheService
    {
        public async Task<T?> GetCacheValueAsync<T>(string key)
        {
            return await Task.Run(() =>
            {
                if (memoryCache.TryGetValue(key, out string? jsonValue))
                {
                    return JsonSerializer.Deserialize<T>(jsonValue);
                }
                return default;

            });
        }

        public async Task SetCacheValueAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(2),
            };

            memoryCache.Set(key, JsonSerializer.Serialize(value), cacheEntryOptions);
            await Task.Run(() => memoryCache.Set(key, JsonSerializer.Serialize(value), cacheEntryOptions));
        }
    }
}
