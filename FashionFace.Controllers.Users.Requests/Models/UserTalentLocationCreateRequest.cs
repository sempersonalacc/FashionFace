using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserTalentLocationCreateRequest(
    Guid TalentId,
    LocationType LocationType,
    Guid CityId,
    PlaceRequest? Place
);