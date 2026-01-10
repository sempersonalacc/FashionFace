using System.Collections.Generic;
using System.Linq;

using FashionFace.Repositories.Context;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Models;

using Microsoft.EntityFrameworkCore;

using Npgsql;

namespace FashionFace.Repositories.Implementations;

public sealed class ExecuteRepository(
    ApplicationDatabaseContext context
) : IExecuteRepository
{
    public IQueryable<TEntity> FromSqlRaw<TEntity>(
        string sql,
        IReadOnlyList<SqlParameter> parameterList
    )
        where TEntity : class
    {
        var sqlParameters =
            parameterList
                .Select(
                    item =>
                        new NpgsqlParameter(
                            item.ParameterName,
                            item.Value
                        )
                )
                .ToArray();

        var queryable =
            context
                .Set<TEntity>()
                .FromSqlRaw(
                    sql,
                    sqlParameters
                );

        return
            queryable;
    }
}