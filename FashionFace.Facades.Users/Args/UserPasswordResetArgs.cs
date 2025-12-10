using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserPasswordResetArgs(
    Guid UserId,
    string OldPassword,
    string NewPassword
);