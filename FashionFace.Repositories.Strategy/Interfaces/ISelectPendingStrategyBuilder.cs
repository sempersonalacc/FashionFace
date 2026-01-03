using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Strategy.Args;

namespace FashionFace.Repositories.Strategy.Interfaces;

public interface ISelectPendingStrategyBuilder
{
    PostgresOutboxBatchStrategyArgs Build<TEntity>(
        SelectPendingStrategyBuilderArgs args
    )
        where TEntity : class, IOutbox;
}