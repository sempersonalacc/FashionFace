using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserTalentLocationUpdateRequest(
    Guid TalentLocationId,
    LocationType LocationType,
    Guid CityId,
    PlaceRequest? Place
);