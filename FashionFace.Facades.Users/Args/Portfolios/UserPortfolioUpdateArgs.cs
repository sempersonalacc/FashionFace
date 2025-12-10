using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioUpdateArgs(
    Guid UserId,
    Guid PortfolioId,
    string Description
);