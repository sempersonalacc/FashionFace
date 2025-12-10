using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserProfileDeleteArgs(
    Guid UserId
);