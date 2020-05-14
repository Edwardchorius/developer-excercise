using System;
using GST.Domain.Models.Base;

namespace GST.Domain.Models
{
    public class FruitAndVegetables : Entity
    {
        public FruitAndVegetables(string product, Price price)
        {
            this.Product = product ?? throw new ArgumentException(product);
            this.Price = price ?? throw new ArgumentNullException(nameof(price));
        }

        public string Product { get; set; }
        public Price Price { get; set; }
        public Deal Deal { get; set; }
    }
}
