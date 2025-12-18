using Microsoft.Extensions.Caching.Distributed;

namespace FashionFace.Dependencies.Redis.Interfaces;

public interface IBaseCache<in TKey, TEntity>
    where TEntity : class
{
    TEntity? Read(
        TKey key
    );

    void Set(
        TKey key,
        TEntity response,
        DistributedCacheEntryOptions? options = null
    );

    void Delete(
        TKey key
    );
}