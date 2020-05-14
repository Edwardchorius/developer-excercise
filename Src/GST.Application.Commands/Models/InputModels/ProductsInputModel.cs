using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Models;

namespace GST.Application.Commands.Models.InputModels
{
    public class ProductsInputModel
    {
        public ProductsInputModel(string name, double priceValue)
        {
            Name = name;
            PriceValue = priceValue;
        }
        public string Name { get; set; }
        public double PriceValue { get; set; }
    }
}
