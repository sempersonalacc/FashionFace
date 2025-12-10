using System;

namespace FashionFace.Facades.Users.Args.Profiles;

public sealed record UserProfileDeleteArgs(
    Guid UserId
);