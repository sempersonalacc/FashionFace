namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record PlaceRequest(
    string Street,
    string? BuildingName,
    string? LandmarkName
);