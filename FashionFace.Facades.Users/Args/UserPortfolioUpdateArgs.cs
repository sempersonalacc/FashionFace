using System;

namespace FashionFace.Facades.Users.Args;

public sealed record UserPortfolioUpdateArgs(
    Guid UserId,
    Guid PortfolioId,
    string Description
);