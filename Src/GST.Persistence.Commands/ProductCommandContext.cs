
using GST.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Commands.EF;

namespace GST.Persistence.Commands
{
    public class ProductCommandContext : CommandDbContext
    {
        public ProductCommandContext(DbContextOptions options, IMediator mediator)
            : base(options, mediator)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Deal> Deals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductCommandContext).Assembly);
        }
    }
}
