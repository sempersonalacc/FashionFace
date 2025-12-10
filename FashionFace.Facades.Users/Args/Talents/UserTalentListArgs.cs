using System;

namespace FashionFace.Facades.Users.Args.Talents;

public sealed record UserTalentListArgs(
    Guid UserId,
    Guid ProfileId
);