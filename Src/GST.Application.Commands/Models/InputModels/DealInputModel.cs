using System;
using System.Collections.Generic;
using System.Text;

namespace GST.Application.Commands.Models.InputModels
{
    public class DealInputModel
    {
        public DealInputModel(string name, ProductsInputModel[] productsInvolved)
        {
            Name = name;
            ProductsInvolved = productsInvolved;
        }
        public string Name { get; set; }
        public ProductsInputModel[] ProductsInvolved { get; set; }
    }
}
