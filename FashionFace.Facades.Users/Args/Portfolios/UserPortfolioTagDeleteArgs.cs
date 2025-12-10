using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioTagDeleteArgs(
    Guid UserId,
    Guid TagId
);