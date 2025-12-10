using System;

namespace FashionFace.Controllers.Users.Requests.Models.Talents;

public sealed record UserTalentListRequest(
    Guid ProfileId
);