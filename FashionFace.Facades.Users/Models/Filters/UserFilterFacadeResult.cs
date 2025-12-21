using System;
using System.Collections.Generic;

using FashionFace.Facades.Users.Args.Filters;
using FashionFace.Facades.Users.Models.Portfolios;
using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Models.Filters;

public sealed record UserFilterFacadeResult(
    Guid Id,
    string Name,
    double PositionIndex,
    TalentType? TalentType,
    UserFilterLocationListItemResult? Location,
    UserFilterAppearanceTraitsResult? AppearanceTraits,
    IReadOnlyList<UserTagListItemResult> TagList
);