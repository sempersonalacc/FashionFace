using System.Collections.Generic;

using FashionFace.Common.Extensions.Dependencies.Models;
using FashionFace.Repositories.Transactions.Implementations;
using FashionFace.Repositories.Transactions.Interfaces;

namespace FashionFace.Repositories.Transactions;

public sealed class DependencyManager : IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies() =>
        new List<DependencyBase>
        {
            new ScopeDependency(
                typeof(ITransactionManager),
                typeof(TransactionManager)
            ),
        };
}