using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.Filters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.Filters;

public sealed class TalentDimensionValueConfiguration : EntityBaseConfiguration<TalentDimensionValue>
{
    public override void Configure(EntityTypeBuilder<TalentDimensionValue> builder)
    {
        base.Configure(
            builder
        );

        builder
            .Property(
                entity => entity.DimensionValueId
            )
            .HasColumnName(
                "DimensionValueId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.TalentId
            )
            .HasColumnName(
                "TalentId"
            )
            .HasColumnType(
                "uuid"
            )
            .IsRequired();

        builder
            .HasOne(
                entity => entity.DimensionValue
            )
            .WithMany()
            .HasForeignKey(
                entity => entity.DimensionValueId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );

        builder
            .HasOne(
                entity => entity.Talent
            )
            .WithMany(
                entity => entity.TalentDimensionValueCollection
            )
            .HasForeignKey(
                entity => entity.TalentId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );

        builder
            .HasIndex(
                entity =>
                    new
                    {
                        entity.DimensionValueId,
                        entity.TalentId,
                    }
            )
            .IsUnique();
    }
}