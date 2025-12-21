using System.Collections.Generic;

using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class Dimension : EntityBase
{
    public required string Code { get; set; }

    public ICollection<DimensionValue> DimensionValueCollection { get; set; }
}