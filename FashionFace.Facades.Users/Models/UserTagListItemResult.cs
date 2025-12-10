using System;

namespace FashionFace.Facades.Users.Models;

public sealed record UserTagListItemResult(
    Guid Id,
    double PositionIndex,
    string Name
);