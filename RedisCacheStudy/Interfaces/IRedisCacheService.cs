namespace RedisCacheStudy.Interfaces
{
    public interface IRedisCacheService
    {
        Task SetCacheValueAsync<T>(string key, T value);
        Task<T?> GetCacheValueAsync<T>(string key);
    }
}
