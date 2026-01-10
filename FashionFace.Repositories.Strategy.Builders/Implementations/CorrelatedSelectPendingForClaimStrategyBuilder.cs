using System.Collections.Generic;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Models;
using FashionFace.Repositories.Strategy.Args;
using FashionFace.Repositories.Strategy.Builders.Args;
using FashionFace.Repositories.Strategy.Builders.Constants;
using FashionFace.Repositories.Strategy.Builders.Interfaces;

namespace FashionFace.Repositories.Strategy.Builders.Implementations;

public sealed class CorrelatedSelectPendingForClaimStrategyBuilder : ICorrelatedSelectPendingStrategyBuilder
{
    public OutboxBatchStrategyArgs Build<TEntity>(
        CorrelatedSelectPendingStrategyBuilderArgs args
    )
        where TEntity : class, IOutbox
    {
        var (correlationId, batchCount) = args;

        const string TableName =
            nameof(TEntity);

        var sql =
            string
                .Format(
                    SqlTemplateConstants.CorrelatedSelectPendingForClaim,
                    TableName
                );

        IReadOnlyList<SqlParameter> parameterList =
        [
            new(
                "OutboxStatus",
                nameof(OutboxStatus.Pending)
            ),
            new(
                "BatchCount",
                batchCount
            ),
            new(
                "CorrelationId",
                correlationId
            ),
        ];

        var postgresOutboxBatchStrategyArgs =
            new OutboxBatchStrategyArgs(
                sql,
                parameterList
            );

        return
            postgresOutboxBatchStrategyArgs;
    }
}