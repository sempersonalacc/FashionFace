namespace FashionFace.Controllers.Users.Responses.Models.TalentLocations;

public sealed record UserPlaceResponse(
    string Street,
    UserBuildingResponse? Building,
    UserLandmarkResponse? Landmark
);