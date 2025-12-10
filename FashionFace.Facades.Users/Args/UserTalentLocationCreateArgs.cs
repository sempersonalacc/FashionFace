using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args;

public sealed record UserTalentLocationCreateArgs(
    Guid UserId,
    Guid TalentId,
    LocationType LocationType,
    Guid CityId,
    PlaceArgs? Place
);