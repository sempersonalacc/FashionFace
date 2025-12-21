using System;

using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class FilterCriteriaDimension : EntityBase
{
    public required Guid FilterCriteriaId { get; set; }
    public required Guid DimensionValueId { get; set; }

    public FilterCriteria? FilterCriteria { get; set; }
    public DimensionValue? DimensionValue { get; set; }
}