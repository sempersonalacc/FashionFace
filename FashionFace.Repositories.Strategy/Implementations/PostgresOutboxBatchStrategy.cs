using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Strategy.Args;
using FashionFace.Repositories.Strategy.Interfaces;
using FashionFace.Repositories.Transactions.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Repositories.Strategy.Implementations;

public sealed class PostgresOutboxBatchStrategy<TEntity>(
    IExecuteRepository executeRepository,
    IUpdateRepository updateRepository,
    ITransactionManager transactionManager
) : IOutboxBatchStrategy<TEntity>
    where TEntity : class, IOutbox
{
    public async Task<IReadOnlyList<TEntity>> ClaimBatchAsync(
        PostgresOutboxBatchStrategyArgs args
    )
    {
        var (sql, parameterList) = args;

        using var transaction =
            await
                transactionManager.BeginTransaction();

        var entityList =
            await
                executeRepository
                    .FromSqlRaw<TEntity>(
                        sql,
                        parameterList
                    )
                    .ToListAsync();

        foreach (var entity in entityList)
        {
            entity.AttemptCount++;
            entity.Status = OutboxStatus.Claimed;
            entity.ProcessingStartedAt = DateTime.UtcNow;
        }

        await
            updateRepository
                .UpdateCollectionAsync(
                    entityList
                );

        await
            transaction.CommitAsync();

        return
            entityList;
    }

    public async Task MakeDoneAsync(
        TEntity entity
    )
    {
        entity.Status = OutboxStatus.Done;

        await
            updateRepository
                .UpdateAsync(
                    entity
                );
    }
}