using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Enums;
using GST.Domain.Models;
using GST.Persistence.Commands;
using Persistence.Abstractions.Interfaces;

namespace GST.Persistence.Services
{
    public class DataSeedingService : IDataSeedingService
    {
        private readonly ProductCommandContext _dbContext;

        public DataSeedingService(ProductCommandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            SeedProducts();
        }

        private void SeedProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "apple",
                    Price = 0.67,
                    ProductDeals = new List<ProductsDeals>()
                },
                new Product()
                {
                    Name = "banana",
                    Price = 2.22,
                    ProductDeals = new List<ProductsDeals>()
                },
                new Product()
                {
                    Name = "tomato",
                    Price = 3.00,
                    ProductDeals = new List<ProductsDeals>()
                },
                new Product()
                {
                    Name = "potato",
                    Price = 1.32,
                    ProductDeals = new List<ProductsDeals>()
                },
            };

            var deals = new List<Deal>()
            {
                new Deal()
                {
                    Name = "2 for 3",
                    ProductDeals = new List<ProductsDeals>()
                },
                new Deal()
                {
                    Name = "buy 1 get 1 half price",
                    ProductDeals = new List<ProductsDeals>()
                }
            };

            products[2].ProductDeals.Add(new ProductsDeals()
            {
                Product = products[2],
                Deal = deals[0]
            });

            _dbContext.Products.AddRange(products);
            _dbContext.Deals.AddRange(deals);

            _dbContext.SaveChanges();
        }
    }
}
