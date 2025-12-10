using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Responses.Models.AppearanceTraits;

public sealed record UserFemaleTraitsResponse(
    BustSizeType BustSizeType
);