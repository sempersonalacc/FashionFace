using System.Collections.Generic;
using System.Linq;

using FashionFace.Common.Extensions.Dependencies.Implementations;
using FashionFace.Common.Extensions.Dependencies.Models;
using FashionFace.Dependencies.SignalR.Implementations;
using FashionFace.Dependencies.SignalR.Interfaces;

namespace FashionFace.Dependencies.SignalR;

public sealed class DependencyManager :
    IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies() =>
        typeof(DependencyManager).GetSingletonDependencies().ToList();
}