namespace FashionFace.Controllers.Requests.Models;

public sealed record RegisterRequest(
    string Email,
    string Password
);