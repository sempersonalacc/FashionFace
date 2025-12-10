namespace FashionFace.Controllers.Users.Requests.Models.TalentLocations;

public sealed record PlaceRequest(
    string Street,
    string? BuildingName,
    string? LandmarkName
);