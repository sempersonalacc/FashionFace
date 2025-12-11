using System;

namespace FashionFace.Facades.Users.Models.MediaAggregates;

public sealed record UserMediaAggregateCreateResult(
    Guid MediaId
);