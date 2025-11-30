using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserPasswordSetArgs(
    Guid UserId,
    string OldPassword,
    string NewPassword
);