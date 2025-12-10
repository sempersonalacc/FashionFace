namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserPasswordResetRequest(
    string OldPassword,
    string NewPassword
);