using System;

namespace FashionFace.Controllers.Users.Requests.Models.Portfolios;

public sealed record UserPortfolioTagDeleteRequest(
    Guid TagId,
    Guid PortfolioId
);