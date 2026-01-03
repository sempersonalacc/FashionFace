using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Strategy.Args;
using FashionFace.Repositories.Strategy.Builders.Args;

namespace FashionFace.Repositories.Strategy.Builders.Interfaces;

public interface ISelectClaimedRetryStrategyBuilder
{
    OutboxBatchStrategyArgs Build<TEntity>(
        SelectClaimedRetryStrategyBuilderArgs args
    )
        where TEntity : class, IOutbox;
}