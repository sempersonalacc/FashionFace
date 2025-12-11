using System;
using System.Collections.Generic;

using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models;

public sealed class PortfolioMedia : EntityBase, IWithPositionIndex
{
    public required Guid PortfolioId { get; set; }
    public required Guid MediaId { get; set; }

    public required double PositionIndex { get; set; }
    public required string Description { get; set; }

    public ICollection<PortfolioMediaTag> PortfolioMediaTagCollection { get; set; }

    public Media? Media { get; set; }
    public Portfolio? Portfolio { get; set; }
}