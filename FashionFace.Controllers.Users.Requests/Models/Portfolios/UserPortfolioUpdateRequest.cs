using System;

namespace FashionFace.Controllers.Users.Requests.Models.Portfolios;

public sealed record UserPortfolioUpdateRequest(
    Guid PortfolioId,
    string Description
);