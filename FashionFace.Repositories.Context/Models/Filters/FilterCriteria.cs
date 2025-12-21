using System.Collections.Generic;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class FilterCriteria : EntityBase
{
    public TalentType? TalentType { get; set; }
    public FilterCriteriaLocation? Location { get; set; }
    public FilterCriteriaAppearanceTraits? AppearanceTraits { get; set; }
    public ICollection<FilterCriteriaTag> TagCollection { get; set; }

    public ICollection<FilterCriteriaDimension> DimensionCollection { get; set; }
}