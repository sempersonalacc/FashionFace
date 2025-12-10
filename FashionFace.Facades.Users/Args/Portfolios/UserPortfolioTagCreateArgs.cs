using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioTagCreateArgs(
    Guid UserId,
    Guid TagId,
    Guid PortfolioId
);