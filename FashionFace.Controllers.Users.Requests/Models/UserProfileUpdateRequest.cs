using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserProfileUpdateRequest(
    string? Description,
    AgeCategoryType?  AgeCategoryType
);