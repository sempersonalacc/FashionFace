using System;

namespace FashionFace.Controllers.Users.Requests.Models.AppearanceTraits;

public sealed record UserAppearanceTraitsRequest(
    Guid ProfileId
);