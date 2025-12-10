using System;

namespace FashionFace.Controllers.Users.Requests.Models.AppearanceTraits;

public sealed record UserFemaleTraitsRequest(
    Guid ProfileId
);