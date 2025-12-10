using System;

namespace FashionFace.Controllers.Users.Requests.Models.Portfolios;

public sealed record UserPortfolioMediaDeleteRequest(
    Guid MediaId
);