using System;

namespace FashionFace.Facades.Users.Args.TalentLocations;

public sealed record UserTalentLocationDeleteArgs(
    Guid UserId,
    Guid TalentLocationId
);