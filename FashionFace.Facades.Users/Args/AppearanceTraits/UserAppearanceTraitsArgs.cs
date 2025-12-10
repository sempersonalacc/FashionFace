using System;

namespace FashionFace.Facades.Users.Args.AppearanceTraits;

public sealed record UserAppearanceTraitsArgs(
    Guid UserId,
    Guid ProfileId
);