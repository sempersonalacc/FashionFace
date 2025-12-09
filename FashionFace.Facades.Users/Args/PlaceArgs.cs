namespace FashionFace.Facades.Users.Args;

public sealed record PlaceArgs(
    string Street,
    string? BuildingName,
    string? LandmarkName
);