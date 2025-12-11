using Microsoft.AspNetCore.Http;

namespace FashionFace.Controllers.Users.Requests.Models.MediaEntity;

public sealed record UserMediaCreateRequest(
    IFormFile File
);