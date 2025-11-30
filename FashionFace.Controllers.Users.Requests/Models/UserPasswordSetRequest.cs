namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserPasswordSetRequest(
    string OldPassword,
    string NewPassword
);