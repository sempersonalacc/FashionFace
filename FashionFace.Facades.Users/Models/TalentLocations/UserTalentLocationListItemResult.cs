using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Models.TalentLocations;

public sealed record UserTalentLocationListItemResult(
    Guid Id,
    LocationType Type,
    CityModel City,
    PlaceModel? Place
);