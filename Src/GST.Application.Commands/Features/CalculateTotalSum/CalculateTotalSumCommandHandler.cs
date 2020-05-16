using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GST.Application.Commands.Models.InputModels;
using MediatR;

namespace GST.Application.Commands.Features.CalculateTotalSum
{
    public class CalculateTotalSumCommandHandler : IRequestHandler<CalculcateTotalSumCommand, double>
    {
        private readonly IProductDataUnitOfWork _data;

        public CalculateTotalSumCommandHandler(IProductDataUnitOfWork data)
        {
            _data = data;
        }

        public async Task<double> Handle(CalculcateTotalSumCommand request, CancellationToken cancellationToken)
        {
            double result = 0;
            var productsToScan = request.Products;
            var availableDeal = request.Deal;
            var productsInDeal = request.ProductsForDeals.ToHashSet<string>();

            var pricePerProduct = new Dictionary<string, double>();
            var productsFromDB = await _data.ReadProducts.GetByNameAsync(productsToScan.Distinct().ToArray());


            pricePerProduct = productsFromDB.ToDictionary(k => k.Name, v => v.Price);
            double initialSum = productsFromDB.Sum(k => k.Price * productsToScan.Where(pr => pr == k.Name).Count());

            if(availableDeal == "2 for 3")
            {
                result = TwoForThree(initialSum, productsToScan, productsInDeal, pricePerProduct);
            }

            var now = DateTime.UtcNow;
            await _data.Products.UpdateAllAsync(productsFromDB.ToList());

            return result;
        }

        private double TwoForThree(double currentSum, string[] items, HashSet<string> availableForDiscount, Dictionary<string, double> prices)
        {
            var validForDiscount = new HashSet<double>();
            int counter = 0;

            for (int i = 0; i < items.Length; i++)
            {
                if (availableForDiscount.Contains(items[i]))
                {
                    validForDiscount.Add(prices[items[i]]);
                    counter++;
                }

                if(counter == 3)
                {
                    currentSum = currentSum - validForDiscount.Min();
                    validForDiscount.Clear();
                    counter = 0;
                }
            }


            return currentSum;
        }
    }
}
