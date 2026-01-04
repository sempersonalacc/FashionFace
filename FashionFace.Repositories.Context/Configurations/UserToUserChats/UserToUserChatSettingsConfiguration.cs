using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.UserToUserChats;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.UserToUserChats;

public sealed class UserToUserChatSettingsConfiguration : EntityConfigurationBase<UserToUserChatSettings>
{
    public override void Configure(EntityTypeBuilder<UserToUserChatSettings> builder)
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
                entity => entity.ChatType
            )
            .HasColumnName(
                "ChatType"
            )
            .HasConversion<string>()
            .HasColumnType(
                "varchar(32)"
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
    }
}