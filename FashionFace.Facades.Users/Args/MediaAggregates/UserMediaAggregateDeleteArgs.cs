using System;

namespace FashionFace.Facades.Users.Args.MediaAggregates;

public sealed record UserMediaAggregateDeleteArgs(
    Guid UserId,
    Guid MediaId
);