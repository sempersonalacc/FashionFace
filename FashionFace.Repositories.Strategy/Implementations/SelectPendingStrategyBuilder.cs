using System.Collections.Generic;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Models;
using FashionFace.Repositories.Strategy.Args;
using FashionFace.Repositories.Strategy.Constants;
using FashionFace.Repositories.Strategy.Interfaces;

namespace FashionFace.Repositories.Strategy.Implementations;

public sealed class SelectPendingStrategyBuilder : ISelectPendingStrategyBuilder
{
    public PostgresOutboxBatchStrategyArgs Build<TEntity>(
        SelectPendingStrategyBuilderArgs args
    )
        where TEntity : class, IOutbox
    {
        const string TableName =
            nameof(TEntity);

        var sql =
            string
                .Format(
                    SqlTemplateConstants.SelectByStatus,
                    TableName
                );

        var batchCount =
            args.BatchCount;

        IReadOnlyList<SqlParameter> parameterList =
        [
            new(
                "Status",
                nameof(OutboxStatus.Pending)
            ),
            new(
                "BatchCount",
                batchCount
            ),
        ];

        var postgresOutboxBatchStrategyArgs =
            new PostgresOutboxBatchStrategyArgs(
                sql,
                parameterList
            );

        return
            postgresOutboxBatchStrategyArgs;
    }
}