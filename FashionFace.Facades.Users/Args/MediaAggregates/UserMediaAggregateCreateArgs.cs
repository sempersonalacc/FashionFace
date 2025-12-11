using System;

namespace FashionFace.Facades.Users.Args.MediaAggregates;

public sealed record UserMediaAggregateCreateArgs(
    Guid UserId,
    Guid PreviewMediaId,
    Guid OriginalMediaId,
    string Description
);