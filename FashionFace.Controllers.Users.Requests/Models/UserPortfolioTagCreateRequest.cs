using System;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserPortfolioTagCreateRequest(
    Guid TagId,
    Guid PortfolioId
);