using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.Base;

public abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var type =
            typeof(TEntity);

        builder.ToTable(
            type.Name
        );

        var isWithIdentifier =
            typeof(IWithIdentifier)
                .IsAssignableFrom(
                    type
                );

        if (isWithIdentifier)
        {
            builder.HasKey(
                nameof(IWithIdentifier.Id)
            );

            builder
                .Property(
                    nameof(IWithIdentifier.Id)
                )
                .HasColumnName(
                    nameof(IWithIdentifier.Id)
                )
                .HasColumnType(
                    "uuid"
                )
                .ValueGeneratedOnAdd();
        }

        var iWithCorrelationId =
            typeof(IWithCorrelationId)
                .IsAssignableFrom(
                    type
                );

        if (iWithCorrelationId)
        {
            builder
                .Property(
                    nameof(IWithCorrelationId.CorrelationId)
                )
                .HasColumnName(
                    nameof(IWithCorrelationId.CorrelationId)
                )
                .HasColumnType(
                    "uuid"
                )
                .ValueGeneratedOnAdd();
        }

        var isWithIDeleted =
            typeof(IWithIsDeleted)
                .IsAssignableFrom(
                    type
                );

        if (isWithIDeleted)
        {
            builder
                .Property(
                    nameof(IWithIsDeleted.IsDeleted)
                )
                .HasColumnName(
                    nameof(IWithIsDeleted.IsDeleted)
                )
                .HasColumnType(
                    "boolean"
                )
                .IsRequired();
        }

        var isWithPositionIndex =
            typeof(IWithPositionIndex)
                .IsAssignableFrom(
                    type
                );

        if (isWithPositionIndex)
        {
            builder
                .Property(
                    nameof(IWithPositionIndex.PositionIndex)
                )
                .HasColumnName(
                    nameof(IWithPositionIndex.PositionIndex)
                )
                .HasColumnType(
                    "double precision"
                )
                .IsRequired();
        }

        var isWithCreatedAt =
            typeof(IWithCreatedAt)
                .IsAssignableFrom(
                    type
                );

        if (isWithCreatedAt)
        {
            builder
                .Property(
                    nameof(IWithCreatedAt.CreatedAt)
                )
                .HasColumnName(
                    nameof(IWithCreatedAt.CreatedAt)
                )
                .HasColumnType(
                    "timestamp with time zone"
                )
                .IsRequired();
        }

        var isWithOutboxStatus =
            typeof(IWithOutboxStatus)
                .IsAssignableFrom(
                    type
                );

        if (isWithOutboxStatus)
        {
            builder
                .Property(
                    nameof(IWithOutboxStatus.OutboxStatus)
                )
                .HasColumnName(
                    nameof(IWithOutboxStatus.OutboxStatus)
                )
                .HasConversion<string>()
                .HasColumnType(
                    "varchar(16)"
                )
                .IsRequired();
        }

        var isWithAttemptCount =
            typeof(IWithAttemptCount)
                .IsAssignableFrom(
                    type
                );

        if (isWithAttemptCount)
        {
            builder
                .Property(
                    nameof(IWithAttemptCount.AttemptCount)
                )
                .HasColumnName(
                    nameof(IWithAttemptCount.AttemptCount)
                )
                .HasColumnType(
                    "integer"
                )
                .IsRequired();
        }

        var isWithProcessingStartedAt =
            typeof(IWithClaimedAt)
                .IsAssignableFrom(
                    type
                );

        if (isWithProcessingStartedAt)
        {
            builder
                .Property(
                    nameof(IWithClaimedAt.ClaimedAt)
                )
                .HasColumnName(
                    nameof(IWithClaimedAt.ClaimedAt)
                )
                .HasColumnType(
                    "timestamp with time zone"
                )
                .IsRequired();
        }
    }
}