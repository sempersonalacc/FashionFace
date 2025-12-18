using System;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Common.Extensions.Implementations;
using FashionFace.Dependencies.Redis.Interfaces;
using FashionFace.Dependencies.Serialization.Interfaces;

using Microsoft.Extensions.Caching.Distributed;

namespace FashionFace.Dependencies.Redis.Implementations;

public sealed class DataCache(
    IDistributedCache cache,
    IExceptionDescriptor exceptionDescriptor,
    ISerializationDecorator serializationDecorator
) : IDataCache
{
    public T? Read<T>(
        string key
    )
        where T : class
    {
        var resultJson =
            cache
                .GetString(
                    key
                );

        if (resultJson.IsEmpty())
        {
            return null;
        }

        cache
            .Refresh(
            key
        );

        return
            serializationDecorator
                .Deserialize<T>(
                    resultJson
                );
    }

    public void Set<T>(
        string key,
        T value,
        int? slidingExpirationMinutes = null
    )
        where T : class
    {
        if (value is null)
        {
            throw exceptionDescriptor.Exception("ValueNotFound");
        }

        var responseJson =
            serializationDecorator
                .Serialize(
                    value
                );

        var options =
            GetOptions(
                slidingExpirationMinutes
            );

        cache
            .SetString(
                key,
                responseJson,
                options
            );
    }

    public void Delete(
        string key
    ) =>
        cache
            .Remove(
                key
            );

    private static DistributedCacheEntryOptions GetOptions(
        int? slidingExpirationMinutes
    )
    {
        var options =
            new DistributedCacheEntryOptions();

        if (slidingExpirationMinutes.HasValue)
        {
            var slidingExpiration =
                TimeSpan
                    .FromMinutes(
                        slidingExpirationMinutes.Value
                    );

            options.SlidingExpiration =
                slidingExpiration;
        }

        return
            options;
    }
}