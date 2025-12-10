using System;
using System.Linq.Expressions;
using System.Reflection;

using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.IdentityEntities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionFace.Repositories.Context;

public sealed class ApplicationDatabaseContext(
    DbContextOptions<ApplicationDatabaseContext> options
) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(
    options
)
{
    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {
        base.OnModelCreating(
            modelBuilder
        );

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly()
        );

        var mutableEntityTypes =
            modelBuilder
                .Model
                .GetEntityTypes();

        foreach (var entityType in mutableEntityTypes)
        {
            var isAssignableFromIWithIsDeleted =
                typeof(IWithIsDeleted)
                    .IsAssignableFrom(
                        entityType.ClrType
                    );

            if (!isAssignableFromIWithIsDeleted)
            {
                continue;
            }

            var parameter =
                Expression
                    .Parameter(
                        entityType.ClrType,
                        "entity"
                    );

            var property =
                Expression
                    .Property(
                        parameter,
                        nameof(IWithIsDeleted.IsDeleted)
                    );

            var constantExpression =
                Expression
                    .Constant(
                        false
                    );

            var binaryExpression =
                Expression
                    .Equal(
                        property,
                        constantExpression
                    );

            var filter =
                Expression
                    .Lambda(
                        binaryExpression,
                        parameter
                    );

            modelBuilder
                .Entity(
                    entityType.ClrType
                )
                .HasQueryFilter(
                    filter
                );
        }
    }
}