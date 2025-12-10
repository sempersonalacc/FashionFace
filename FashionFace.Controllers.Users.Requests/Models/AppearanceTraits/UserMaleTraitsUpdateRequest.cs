using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models.AppearanceTraits;

public sealed record UserMaleTraitsUpdateRequest(
    HairLengthType FacialHairLengthType
);