using System;
using Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Abstractions.Models;
using Pluralize.NET;

namespace Persistence.Commands.EF.Configurations
{
    public abstract class BaseConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IIdentifiable<TId>, ICreatable, IModifiable, IDeletable
    {
        protected static readonly Pluralizer Pluralizer = new Pluralizer();

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(Pluralizer.Pluralize(typeof(TEntity).Name));

            builder.Property<bool>(nameof(DataModel<TId>.IsDeleted))
                .IsRequired(true)
                .HasDefaultValue(false);

            builder.Property<DateTime?>(nameof(DataModel<TId>.DeletedOn))
                .IsRequired(false);

            builder.HasQueryFilter(x => Microsoft.EntityFrameworkCore.EF.Property<bool>(x, nameof(DataModel<TId>.IsDeleted)) == false);
        }
    }
}
