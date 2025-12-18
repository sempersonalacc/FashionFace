using System;

using FashionFace.Common.Extensions.Implementations;
using FashionFace.Dependencies.Redis.Interfaces;
using FashionFace.Dependencies.Serialization.Interfaces;

using Microsoft.Extensions.Caching.Distributed;

namespace FashionFace.Dependencies.Redis.Implementations;

public abstract class BaseCache<TKey, TEntity>(
    IDistributedCache distributedCache,
    ISerializationDecorator serializationDecorator
) :
    IBaseCache<TKey, TEntity>
    where TEntity : class
{
    private readonly DistributedCacheEntryOptions
        defaultOptions =
            new()
            {
                SlidingExpiration =
                    TimeSpan
                        .FromMinutes(
                            30
                        ),
            };

    public TEntity? Read(
        TKey key
    )
    {
        var strKey =
            GetKey(
                key
            );

        var resultJson =
            distributedCache
                .GetString(
                    strKey
                );

        if (resultJson.IsEmpty())
        {
            distributedCache
                .Remove(
                    strKey
                );

            return default;
        }

        var result =
            serializationDecorator
                .Deserialize<TEntity>(
                    resultJson
                );

        if (result == null)
        {
            distributedCache
                .Remove(
                    strKey
                );

            return default;
        }

        distributedCache
            .Refresh(
                strKey
            );

        return
            result;
    }

    public void Set(
        TKey key,
        TEntity response,
        DistributedCacheEntryOptions? options = default
    )
    {
        var strKey =
            GetKey(
                key
            );

        var responseJson =
            serializationDecorator
                .Serialize(
                    response
                );

        options ??=
            defaultOptions;

        distributedCache
            .SetString(
                strKey,
                responseJson,
                options
            );
    }

    public void Delete(
        TKey key
    )
    {
        var strKey =
            GetKey(
                key
            );

        distributedCache
            .Remove(
                strKey
            );
    }

    protected abstract string GetKey(
        TKey key
    );
}