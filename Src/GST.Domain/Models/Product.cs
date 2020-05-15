using System;
using System.Collections;
using System.Collections.Generic;
using GST.Domain.Enums;
using GST.Domain.Models.Base;

namespace GST.Domain.Models
{
    public class Product : Entity
    {
        public Product()
        {

        }

        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ProductsDeals> ProductDeals { get; set; }
    }
}
