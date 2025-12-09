using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args;

public sealed record UserTalentUpdateArgs(
    Guid UserId,
    Guid TalentId,
    string? Description,
    TalentType?  TalentType
);