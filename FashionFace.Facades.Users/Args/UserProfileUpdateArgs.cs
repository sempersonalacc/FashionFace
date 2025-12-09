using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args;

public sealed record UserProfileUpdateArgs(
    Guid UserId,
    string? Description,
    AgeCategoryType?  AgeCategoryType
);