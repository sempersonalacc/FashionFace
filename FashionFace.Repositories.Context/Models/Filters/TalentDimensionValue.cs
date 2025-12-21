using System;

using FashionFace.Repositories.Context.Models.Base;
using FashionFace.Repositories.Context.Models.Talents;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class TalentDimensionValue : EntityBase
{
    public required Guid TalentId { get; set; }
    public required Guid DimensionValueId { get; set; }

    public Talent? Talent { get; set; }
    public DimensionValue? DimensionValue { get; set; }
}