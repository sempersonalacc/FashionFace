using System;

namespace FashionFace.Controllers.Users.Requests.Models.Portfolios;

public sealed record UserPortfolioMediaCreateRequest(
    Guid MediaId,
    Guid PortfolioId
);