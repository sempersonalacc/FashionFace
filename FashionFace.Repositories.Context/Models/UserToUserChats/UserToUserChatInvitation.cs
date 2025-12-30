using System;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.Base;
using FashionFace.Repositories.Context.Models.IdentityEntities;

namespace FashionFace.Repositories.Context.Models.UserToUserChats;

public sealed class UserToUserChatInvitation : EntityBase, IWithCreatedAt
{
    public required Guid InitiatorUserId { get; set; }
    public required Guid TargetUserId { get; set; }

    public required DateTime CreatedAt { get; set; }
    public required ChatInvitationStatus Status { get; set; }

    public ApplicationUser? InitiatorUser  { get; set; }
    public ApplicationUser? TargetUser { get; set; }
}