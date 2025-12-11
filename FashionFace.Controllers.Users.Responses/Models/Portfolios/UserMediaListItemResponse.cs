using System;

namespace FashionFace.Controllers.Users.Responses.Models.Portfolios;

public sealed record UserMediaListItemResponse(
    Guid Id,
    double PositionIndex,
    string Description,
    string RelativePath
);