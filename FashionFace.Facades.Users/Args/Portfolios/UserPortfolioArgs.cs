using System;

namespace FashionFace.Facades.Users.Args.Portfolios;

public sealed record UserPortfolioArgs(
    Guid UserId,
    Guid TalentId
);