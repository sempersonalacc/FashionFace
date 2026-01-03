using System.Collections.Generic;

using FashionFace.Repositories.Models;

namespace FashionFace.Repositories.Strategy.Args;

public sealed record PostgresOutboxBatchStrategyArgs(
    string Sql,
    IReadOnlyList<SqlParameter> ParameterList
);