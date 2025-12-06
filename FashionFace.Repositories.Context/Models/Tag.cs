using System.Collections.Generic;

namespace FashionFace.Repositories.Context.Models;

public sealed class Tag : EntityBase
{
    public required string Name { get; set; }

    public ICollection<PortfolioMediaTag> PortfolioMediaTagCollection {get;set;}
    public ICollection<PortfolioTag> PortfolioTagCollection { get; set; }
}