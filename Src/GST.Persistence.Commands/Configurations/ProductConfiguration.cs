using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GST.Persistence.Commands.Configurations
{
    internal class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(
                x => x.Price,
                priceBuilder =>
                {
                    priceBuilder
                    .Property(x => x.Name)
                    .HasColumnName($"{nameof(Price)}{nameof(Price.Name)}");

                    priceBuilder
                    .Property(x => x.Value)
                    .HasColumnName($"{nameof(Price)}{nameof(Price.Value)}");
                });

        }
    }
}
