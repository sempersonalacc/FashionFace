using System;

using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class FilterCriteriaHeight : EntityBase
{
    public required Guid FilterRangeValueId { get; set; }
    public required Guid FilterCriteriaAppearanceTraitsId { get; set; }

    public FilterRangeValue? FilterRangeValue { get; set; }
    public FilterCriteriaAppearanceTraits? FilterCriteriaAppearanceTraits { get; set; }
}