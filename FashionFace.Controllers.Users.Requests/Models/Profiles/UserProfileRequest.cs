using System;

namespace FashionFace.Controllers.Users.Requests.Models.Profiles;

public sealed record UserProfileRequest(
    Guid ProfileId
);