using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.UserToUserChats;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.UserToUserChats;

public sealed class UserToUserMessageConfiguration : EntityBaseConfiguration<UserToUserMessage>
{
    public override void Configure(EntityTypeBuilder<UserToUserMessage> builder)
    {
        base.Configure(
            builder
        );

        builder
            .Property(
                entity => entity.ApplicationUserId
            )
            .HasColumnName(
                "ApplicationUserId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.Value
            )
            .HasColumnName(
                "Value"
            )
            .HasColumnType(
                "text"
            )
            .IsRequired();

        builder
            .HasOne(
                entity => entity.ApplicationUser
            )
            .WithMany()
            .HasForeignKey(
                entity => entity.ApplicationUserId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );
    }
}