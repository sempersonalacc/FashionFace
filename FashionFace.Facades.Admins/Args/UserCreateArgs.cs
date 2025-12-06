using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Admins.Args;

public sealed record UserCreateArgs(
    Guid UserId,
    string Email,
    string Username,
    string Password,
    string Name,
    string Description,
    AgeCategoryType AgeCategoryType
);