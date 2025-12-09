using System;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserPortfolioUpdateRequest(
    Guid PortfolioId,
    string Description
);