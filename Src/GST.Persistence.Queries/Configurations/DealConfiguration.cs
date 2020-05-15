using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GST.Persistence.Queries.Configurations
{
    internal class DealConfiguration : BaseConfiguration<Deal>
    {
        public override void Configure(EntityTypeBuilder<Deal> builder)
        {
            base.Configure(builder);


        }
    }
}
