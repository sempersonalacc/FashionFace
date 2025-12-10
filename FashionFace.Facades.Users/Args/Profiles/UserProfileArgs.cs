using System;

namespace FashionFace.Facades.Users.Args.Profiles;

public sealed record UserProfileArgs(
    Guid UserId,
    Guid ProfileId
);