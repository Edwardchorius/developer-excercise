using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GST.Persistence.Commands.Configurations.FruitsAndVegetables
{
    internal class FruitAndVegetablesConfiguration : BaseConfiguration<FruitAndVegetables>
    {
        public override void Configure(EntityTypeBuilder<FruitAndVegetables> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(x => x.Deal);

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
