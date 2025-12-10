using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserPortfolioTagCreateArgs(
    Guid UserId,
    Guid TagId,
    Guid PortfolioId
);