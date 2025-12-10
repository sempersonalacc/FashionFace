using System;

namespace FashionFace.Facades.Users.Args.TalentLocations;

public sealed record UserTalentLocationListArgs(
    Guid UserId,
    Guid TalentId
);