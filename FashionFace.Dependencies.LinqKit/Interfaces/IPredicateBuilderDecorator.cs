using System;
using System.Linq.Expressions;

namespace FashionFace.Dependencies.LinqKit.Interfaces;

public interface IPredicateBuilderDecorator
{
    Expression<Func<TEntity, bool>> Build<TEntity>(bool includeByDefault = true);
}