using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.Profiles;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.Profiles;

public sealed class ProfileMediaAggregateConfiguration : EntityBaseConfiguration<ProfileMediaAggregate>
{
    public override void Configure(EntityTypeBuilder<ProfileMediaAggregate> builder)
    {
        base.Configure(
            builder
        );

        builder
            .Property(
                entity => entity.ProfileId
            )
            .HasColumnName(
                "ProfileId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.MediaAggregateId
            )
            .HasColumnName(
                "MediaAggregateId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .HasOne(
                entity => entity.Profile
            )
            .WithOne(
                entity => entity.ProfileMediaAggregate
            )
            .HasForeignKey<ProfileMediaAggregate>(
                entity => entity.ProfileId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );

        builder
            .HasOne(
                entity => entity.MediaAggregate
            )
            .WithOne()
            .HasForeignKey<ProfileMediaAggregate>(
                entity => entity.MediaAggregateId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );
    }
}