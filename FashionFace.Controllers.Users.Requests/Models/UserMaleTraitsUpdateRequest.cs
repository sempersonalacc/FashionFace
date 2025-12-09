using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserMaleTraitsUpdateRequest(
    HairLengthType FacialHairLengthType
);