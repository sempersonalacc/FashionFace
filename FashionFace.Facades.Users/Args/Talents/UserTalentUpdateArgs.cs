using System;

namespace FashionFace.Facades.Users.Args.Talents;

public sealed record UserTalentUpdateArgs(
    Guid UserId,
    Guid TalentId,
    string? Description
);