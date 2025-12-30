using System;
using System.Collections.Generic;

using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.UserToUserChats;

public sealed class UserToUserChat : EntityBase, IWithCreatedAt
{
    public required DateTime CreatedAt { get; set; }

    public ICollection<UserToUserChatMessage> MessageCollection { get; set; }
    public ICollection<UserToUserChatProfile> ProfileCollection { get; set; }

    public UserToUserChatSettings?  Settings { get; set; }
}