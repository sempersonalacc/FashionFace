using System;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models.UserToUserChats;

public sealed class UserToUserChatSettings : EntityBase
{
    public required Guid ChatId { get; set; }

    public required UserToUserChatType ChatType { get; set; }

    public UserToUserChat? Chat  { get; set; }
}