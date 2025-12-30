using System;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.Base;
using FashionFace.Repositories.Context.Models.Profiles;

namespace FashionFace.Repositories.Context.Models.UserToUserChats;

public sealed class UserToUserChatProfile : EntityBase
{
    public required Guid ProfileId { get; set; }
    public required Guid ChatId { get; set; }

    public required ChatMemberType Type { get; set; }
    public required ChatMemberStatus Status { get; set; }

    public required double LastReadMessagePositionIndex { get; set; }

    public Profile? Profile  { get; set; }
    public UserToUserChat? Chat { get; set; }
}