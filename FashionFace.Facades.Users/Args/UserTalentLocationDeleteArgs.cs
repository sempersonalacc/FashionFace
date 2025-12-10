using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserTalentLocationDeleteArgs(
    Guid UserId,
    Guid TalentLocationId
);