using System;
using System.Collections.Generic;
using System.Text;
using GST.Application.Commands.Models.InputModels;
using Mediator.Abstractions.Requests;

namespace GST.Application.Commands.Features.CalculateTotalSum
{
    public class CalculcateTotalSumCommand : Command<double>
    {
        public CalculcateTotalSumCommand(string[] products, string deal, string[] productsForDeals)
        {
            Products = products;
            Deal = deal;
            ProductsForDeals = productsForDeals;
        }

        public string[] Products { get; set; }
        public string Deal { get; set; }
        public string[] ProductsForDeals { get; set; }
    }
}
