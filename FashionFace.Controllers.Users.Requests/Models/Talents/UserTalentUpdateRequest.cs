using System;

namespace FashionFace.Controllers.Users.Requests.Models.Talents;

public sealed record UserTalentUpdateRequest(
    Guid TalentId,
    string? Description
);