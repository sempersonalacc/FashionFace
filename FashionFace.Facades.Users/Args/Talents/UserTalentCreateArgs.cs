using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Args.Talents;

public sealed record UserTalentCreateArgs(
    Guid UserId,
    TalentType TalentType,
    string TalentDescription,
    string PortfolioDescription
);