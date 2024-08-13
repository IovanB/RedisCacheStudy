namespace RedisCacheStudy.Interfaces
{
    public interface ICacheService
    {
        Task SetCacheValueAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task<T?> GetCacheValueAsync<T>(string key);
    }
}
