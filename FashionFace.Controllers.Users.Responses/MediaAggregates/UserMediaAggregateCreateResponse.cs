using System;

namespace FashionFace.Controllers.Users.Responses.MediaAggregates;

public sealed record UserMediaAggregateCreateResponse(
    Guid MediaId
);