using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Models;

namespace GST.Domain.Models
{
    public class ProductsDeals
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string DealId { get; set; }
        public Deal Deal { get; set; }
    }
}
