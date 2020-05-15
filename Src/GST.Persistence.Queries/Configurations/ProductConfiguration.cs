using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GST.Domain.Enums;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GST.Persistence.Queries.Configurations
{
    internal class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
        }
    }
}
