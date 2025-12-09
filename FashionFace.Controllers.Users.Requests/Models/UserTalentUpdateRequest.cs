using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserTalentUpdateRequest(
    Guid TalentId,
    string? Description,
    TalentType?  TalentType
);