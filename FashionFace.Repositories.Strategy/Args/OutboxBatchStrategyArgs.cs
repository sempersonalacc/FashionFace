using System.Collections.Generic;

using FashionFace.Repositories.Models;

namespace FashionFace.Repositories.Strategy.Args;

public sealed record OutboxBatchStrategyArgs(
    string Sql,
    IReadOnlyList<SqlParameter> ParameterList
);