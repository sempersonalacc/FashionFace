using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserPortfolioTagDeleteArgs(
    Guid UserId,
    Guid TagId
);