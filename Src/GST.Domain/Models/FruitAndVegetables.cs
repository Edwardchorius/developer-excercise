using System;

namespace GST.Domain.Models
{
    public class FruitAndVegetables
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
