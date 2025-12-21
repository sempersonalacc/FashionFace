using System;

using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class DimensionValue : EntityBase
{
    public required Guid DimensionId { get; set; }

    public required string Code { get; set; }

    public Dimension? Dimension { get; set; }
}