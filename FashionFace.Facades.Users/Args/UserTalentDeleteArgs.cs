using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserTalentDeleteArgs(
    Guid UserId,
    Guid TalentId
);