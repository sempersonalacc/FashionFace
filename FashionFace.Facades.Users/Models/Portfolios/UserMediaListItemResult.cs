using System;

namespace FashionFace.Facades.Users.Models.Portfolios;

public sealed record UserMediaListItemResult(
    Guid Id,
    double PositionIndex,
    string Description,
    string RelativePath
);