using System;
using System.Linq.Expressions;

using FashionFace.Dependencies.LinqKit.Interfaces;

using LinqKit;

namespace FashionFace.Dependencies.LinqKit.Implementations;

public sealed class PredicateBuilderDecorator : IPredicateBuilderDecorator
{
    public Expression<Func<TEntity, bool>> Build<TEntity>(
        bool includeByDefault = true
    ) =>
        PredicateBuilder
            .New<TEntity>()
            .Start(
                entity =>
                    includeByDefault
            );
}