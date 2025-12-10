namespace FashionFace.Facades.Users.Models.TalentLocations;

public sealed record PlaceModel(
    string Street,
    BuildingModel? Building,
    LandmarkModel? Landmark
);