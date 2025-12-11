using System;

namespace FashionFace.Controllers.Users.Requests.MediaAggregates;

public sealed record UserMediaAggregateCreateRequest(
    Guid PreviewMediaId,
    Guid OriginalMediaId,
    string Description
);