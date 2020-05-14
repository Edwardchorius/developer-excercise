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
            var productsInTotal = request.Products;
            var dealsInTotal = request.Deals;

            var dealOnProducts = new Dictionary<string, ProductsInputModel[]>();

            foreach (var deal in dealsInTotal)
            {
                if (!dealOnProducts.ContainsKey(deal.Name))
                {
                    dealOnProducts.Add(deal.Name, deal.ProductsInvolved);
                }
            }

            foreach (var deal in dealOnProducts)
            {

            }

            return 0;
        }
    }
}
