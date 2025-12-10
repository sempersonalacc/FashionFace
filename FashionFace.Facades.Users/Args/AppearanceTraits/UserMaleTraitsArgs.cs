using System;

namespace FashionFace.Facades.Users.Args.AppearanceTraits;

public sealed record UserMaleTraitsArgs(
    Guid UserId,
    Guid ProfileId
);