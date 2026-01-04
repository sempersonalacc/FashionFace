using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.OutboxEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.OutboxEntity;

public sealed class UserToUserChatMessageSendOutboxConfiguration :
    EntityConfigurationBase<UserToUserChatMessageSendOutbox>
{
    public override void Configure(EntityTypeBuilder<UserToUserChatMessageSendOutbox> builder)
    {
        base.Configure(
            builder
        );

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
                entity => entity.MessageId
            )
            .HasColumnName(
                "MessageId"
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
                entity => entity.Message
            )
            .WithOne()
            .HasForeignKey<UserToUserChatMessageSendOutbox>(
                entity => entity.MessageId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );
    }
}