namespace FashionFace.Dependencies.Redis.Interfaces;

public interface IDataCache
{
    T? Read<T>(
        string key
    )
        where T : class;

    void Set<T>(
        string key,
        T value,
        int? slidingExpirationMinutes = null
    )
        where T : class;

    void Delete(
        string key
    );
}