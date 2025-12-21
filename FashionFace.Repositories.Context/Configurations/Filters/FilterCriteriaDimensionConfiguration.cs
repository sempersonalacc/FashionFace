using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.Filters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.Filters;

public sealed class FilterCriteriaDimensionConfiguration : EntityBaseConfiguration<FilterCriteriaDimension>
{
    public override void Configure(EntityTypeBuilder<FilterCriteriaDimension> builder)
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
                entity => entity.FilterCriteriaId
            )
            .HasColumnName(
                "FilterCriteriaId"
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
                entity => entity.FilterCriteria
            )
            .WithMany(
                entity => entity.DimensionCollection
            )
            .HasForeignKey(
                entity => entity.FilterCriteriaId
            )
            .OnDelete(
                DeleteBehavior.Cascade
            );
    }
}