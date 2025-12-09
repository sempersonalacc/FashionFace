using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args;

public sealed record UserMaleTraitsUpdateArgs(
    Guid UserId,
    HairLengthType FacialHairLengthType
);