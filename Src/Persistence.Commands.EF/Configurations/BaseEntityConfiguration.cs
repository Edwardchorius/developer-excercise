
using Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Commands.EF.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity, TId> : BaseConfiguration<TEntity, TId>
       where TEntity : class, IEntity<TId>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
