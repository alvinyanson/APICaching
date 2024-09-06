namespace APICaching.Interface
{
    public interface ICacheService
    {
        T Get<T>(string key);
        bool Set<T>(string key, T value, DateTimeOffset expiration);
        object Remove(string key);
    }
}
