using System;

namespace FashionFace.Controllers.Users.Requests.MediaAggregates;

public sealed record UserMediaAggregateDeleteRequest(
    Guid MediaId
);