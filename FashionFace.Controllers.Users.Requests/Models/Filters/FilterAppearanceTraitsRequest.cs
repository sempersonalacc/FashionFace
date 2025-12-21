using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models.Filters;

public sealed record FilterAppearanceTraitsRequest(
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
    FilterRangeRequest? Height,
    FilterRangeRequest? ShoeSize,
    FilterMaleTraitsRequest? FilterMaleTraits,
    FilterFemaleTraitsRequest? FilterFemaleTraits
);