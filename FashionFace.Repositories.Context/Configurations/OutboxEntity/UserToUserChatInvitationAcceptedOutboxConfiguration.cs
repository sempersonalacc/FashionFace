using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.OutboxEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.OutboxEntity;

public sealed class UserToUserChatInvitationAcceptedOutboxConfiguration :
    EntityConfigurationBase<UserToUserChatInvitationAcceptedOutbox>
{
    public override void Configure(EntityTypeBuilder<UserToUserChatInvitationAcceptedOutbox> builder)
    {
        base.Configure(
            builder
        );

        builder
            .Property(
                entity => entity.InvitationId
            )
            .HasColumnName(
                "InvitationId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.ChatId
            )
            .HasColumnName(
                "ChatId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.InitiatorUserId
            )
            .HasColumnName(
                "InitiatorUserId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.TargetUserId
            )
            .HasColumnName(
                "TargetUserId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .HasOne(
                entity => entity.Chat
            )
            .WithMany()
            .HasForeignKey(
                entity => entity.ChatId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );

        builder
            .HasOne(
                entity => entity.InitiatorUser
            )
            .WithMany()
            .HasForeignKey(
                entity => entity.InitiatorUserId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );

        builder
            .HasOne(
                entity => entity.TargetUser
            )
            .WithMany()
            .HasForeignKey(
                entity => entity.TargetUserId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );

        builder
            .HasOne(
                entity => entity.Invitation
            )
            .WithOne()
            .HasForeignKey<UserToUserChatInvitationRejectedOutbox>(
                entity => entity.InvitationId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );
    }
}