using System;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserTalentUpdateRequest(
    Guid TalentId,
    string? Description
);