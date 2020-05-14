
using GST.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Commands.EF;

namespace GST.Persistence.Commands
{
    public class FruitAndVegetablesCommandContext : CommandDbContext
    {
        public FruitAndVegetablesCommandContext(DbContextOptions options, IMediator mediator)
            : base(options, mediator)
        {

        }

        public DbSet<FruitAndVegetables> FruitAndVegetables { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(FruitAndVegetablesCommandContext).Assembly);
        }
    }
}
