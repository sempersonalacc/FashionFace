using System;

namespace FashionFace.Controllers.Users.Requests.Models.TalentLocations;

public sealed record UserTalentLocationDeleteRequest(
    Guid TalentLocationId
);