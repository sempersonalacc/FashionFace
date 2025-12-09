using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args;

public sealed record UserTalentLocationUpdateArgs(
    Guid UserId,
    Guid TalentLocationId,
    LocationType LocationType,
    Guid CityId,
    PlaceArgs? Place
);