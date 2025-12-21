using FashionFace.Facades.Users.Models.Filters;
using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args.Filters;

public sealed record UserFilterAppearanceTraitsResult(
    SexType? SexType,
    FaceType? FaceType,
    HairColorType? HairColorType,
    HairType? HairType,
    HairLengthType? HairLengthType,
    BodyType? BodyType,
    SkinToneType? SkinToneType,
    EyeShapeType? EyeShapeType,
    EyeColorType? EyeColorType,
    NoseType? NoseType,
    JawType? JawType,
    FilterRangeResult? Height,
    FilterRangeResult? ShoeSize
);