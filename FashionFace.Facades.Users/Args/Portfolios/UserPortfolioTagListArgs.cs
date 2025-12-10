using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioTagListArgs(
    Guid UserId,
    Guid PortfolioId
);