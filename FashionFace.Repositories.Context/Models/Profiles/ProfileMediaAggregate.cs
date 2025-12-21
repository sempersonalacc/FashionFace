using System;

using FashionFace.Repositories.Context.Models.Base;
using FashionFace.Repositories.Context.Models.MediaEntities;

namespace FashionFace.Repositories.Context.Models.Profiles;

public sealed class ProfileMediaAggregate : EntityBase
{
    public required Guid ProfileId { get; set; }
    public required Guid MediaAggregateId { get; set; }

    public Profile? Profile { get; set; }
    public MediaAggregate? MediaAggregate { get; set; }
}