using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioMediaCreateArgs(
    Guid UserId,
    Guid MediaId,
    Guid PortfolioId
);