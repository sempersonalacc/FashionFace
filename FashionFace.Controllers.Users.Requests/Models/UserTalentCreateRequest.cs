using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Requests.Models;

public sealed record UserTalentCreateRequest(
    TalentType TalentType,
    string TalentDescription,
    string PortfolioDescription
);