using System;

namespace FashionFace.Controllers.Users.Requests.Models.Portfolios;

public sealed record UserPortfolioTagListRequest(
    Guid TalentId
);