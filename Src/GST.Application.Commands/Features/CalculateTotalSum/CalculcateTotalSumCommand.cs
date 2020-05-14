using System;
using System.Collections.Generic;
using System.Text;
using GST.Application.Commands.Models.InputModels;
using Mediator.Abstractions.Requests;

namespace GST.Application.Commands.Features.CalculateTotalSum
{
    public class CalculcateTotalSumCommand : Command<double>
    {
        public CalculcateTotalSumCommand(ProductsInputModel[] products, DealInputModel[] deals)
        {
            Products = products;
            Deals = deals;
        }

        public ProductsInputModel[] Products { get; set; }
        public DealInputModel[] Deals { get; set; }
    }
}
