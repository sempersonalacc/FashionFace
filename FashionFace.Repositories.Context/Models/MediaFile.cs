using System;

using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models;

public sealed class MediaFile : EntityBase
{
    public required Guid ProfileId { get; set; }

    public required string RelativePath { get; set; }

    public Profile? Profile { get; set; }
}