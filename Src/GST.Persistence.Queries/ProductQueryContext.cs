using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Commands.EF;

namespace GST.Persistence.Queries
{
    public class ProductQueryContext : CommandDbContext
    {
        public ProductQueryContext(DbContextOptions<ProductQueryContext> options, IMediator mediator)
            : base(options, mediator)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductQueryContext).Assembly);
        }
    }
}
