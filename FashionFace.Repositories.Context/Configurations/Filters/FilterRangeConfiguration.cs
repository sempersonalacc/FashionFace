using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.Filters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.Filters;

public sealed class FilterRangeValueConfiguration : EntityConfigurationBase<FilterRangeValue>
{
    public override void Configure(EntityTypeBuilder<FilterRangeValue> builder)
    {
        base.Configure(
            builder
        );

        builder
            .Property(
                entity => entity.Min
            )
            .HasColumnName(
                "Min"
            )
            .HasColumnType(
                "integer"
            )
            .IsRequired();

        builder
            .Property(
                entity => entity.Max
            )
            .HasColumnName(
                "Max"
            )
            .HasColumnType(
                "integer"
            )
            .IsRequired();
    }
}