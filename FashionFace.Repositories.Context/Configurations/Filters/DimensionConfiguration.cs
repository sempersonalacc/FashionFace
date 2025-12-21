using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.Filters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.Filters;

public sealed class DimensionConfiguration : EntityBaseConfiguration<Dimension>
{
    public override void Configure(EntityTypeBuilder<Dimension> builder)
    {
        base.Configure(
            builder
        );

        builder
            .Property(
                entity => entity.Code
            )
            .HasColumnName(
                "Code"
            )
            .HasColumnType(
                "varchar(128)"
            )
            .IsRequired();
    }
}