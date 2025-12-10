using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioMediaDeleteArgs(
    Guid UserId,
    Guid MediaId
);