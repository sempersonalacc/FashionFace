using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Responses.Models.TalentLocations;

public sealed record UserTalentLocationListItemResponse(
    Guid Id,
    LocationType Type,
    UserCityResponse City,
    UserPlaceResponse? Place
);