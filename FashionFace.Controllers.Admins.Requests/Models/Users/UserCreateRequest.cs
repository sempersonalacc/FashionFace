using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Admins.Requests.Models.Users;

public sealed record UserCreateRequest(
    string Email,
    string Username,
    string Password,
    string Name,
    string Description,
    AgeCategoryType AgeCategoryType
);