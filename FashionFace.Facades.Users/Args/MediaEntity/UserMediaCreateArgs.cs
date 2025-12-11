using System;
using System.IO;

namespace FashionFace.Facades.Users.Args.MediaEntity;

public sealed record UserMediaCreateArgs(
    Guid UserId,
    Stream Stream
);