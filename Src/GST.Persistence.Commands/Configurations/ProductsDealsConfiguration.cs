using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GST.Persistence.Commands.Configurations
{
    internal class ProductsDealsConfiguration : IEntityTypeConfiguration<ProductsDeals>
    {
        public void Configure(EntityTypeBuilder<ProductsDeals> builder)
        {
            builder.HasKey(pd => new { pd.ProductId, pd.DealId });
           
            builder.HasOne<Product>(pd => pd.Product)
                .WithMany(p => p.ProductDeals)
                .HasForeignKey(pd => pd.ProductId);

            builder.HasOne<Deal>(pd => pd.Deal)
                .WithMany(d => d.ProductDeals)
                .HasForeignKey(pd => pd.DealId);
        }
    }
}
