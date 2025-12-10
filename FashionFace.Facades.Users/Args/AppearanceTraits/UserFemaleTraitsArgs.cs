using System;

namespace FashionFace.Facades.Users.Args.AppearanceTraits;

public sealed record UserFemaleTraitsArgs(
    Guid UserId,
    Guid ProfileId
);