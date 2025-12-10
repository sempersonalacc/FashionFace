namespace FashionFace.Facades.Users.Args.TalentLocations;

public sealed record PlaceArgs(
    string Street,
    string? BuildingName,
    string? LandmarkName
);