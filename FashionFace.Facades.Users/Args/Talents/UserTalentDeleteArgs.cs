using System;

namespace FashionFace.Facades.Users.Args.Talents;

public sealed record UserTalentDeleteArgs(
    Guid UserId,
    Guid TalentId
);