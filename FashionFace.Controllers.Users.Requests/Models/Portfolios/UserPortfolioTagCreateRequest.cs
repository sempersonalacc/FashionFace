using System;

namespace FashionFace.Controllers.Users.Requests.Models.Portfolios;

public sealed record UserPortfolioTagCreateRequest(
    Guid TagId,
    Guid PortfolioId
);