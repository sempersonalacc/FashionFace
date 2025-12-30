using System;

using FashionFace.Repositories.Context.Models.Base;
using FashionFace.Repositories.Context.Models.IdentityEntities;

namespace FashionFace.Repositories.Context.Models.UserToUserChats;

public sealed class UserToUserMessage : EntityBase
{
    public required Guid ApplicationUserId { get; set; }

    public required string Value { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
}