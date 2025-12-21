using System;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.Filters;

public sealed class FilterCriteriaAppearanceTraits : EntityBase
{
    public required Guid FilterCriteriaId { get; set; }

    public SexType? SexType { get; set; }
    public FaceType? FaceType { get; set; }
    public HairColorType? HairColorType { get; set; }
    public HairType? HairType { get; set; }
    public HairLengthType? HairLengthType { get; set; }
    public BodyType? BodyType { get; set; }
    public SkinToneType? SkinToneType { get; set; }
    public EyeShapeType? EyeShapeType { get; set; }
    public EyeColorType? EyeColorType { get; set; }
    public NoseType? NoseType { get; set; }
    public JawType? JawType { get; set; }

    public FilterCriteriaHeight? Height { get; set; }
    public FilterCriteriaShoeSize? ShoeSize { get; set; }
    public FilterCriteriaMaleTraits? MaleTraits { get; set; }
    public FilterCriteriaFemaleTraits? FemaleTraits { get; set; }

    public FilterCriteria? FilterCriteria { get; set; }
}