﻿

using System.Collections.Generic;
using GST.Domain.Models.Base;

namespace GST.Domain.Models
{
    public class Deal : Entity
    {
        public string Name { get; set; }
        public ICollection<ProductsDeals> ProductDeals { get; set; }
    }
}
