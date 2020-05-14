using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GST.Api.Models.DTOs
{
    public class DealDTO
    {
        public string Name { get; set; }
        public ProductDTO[] ProductsInvolved { get; set; }
    }
}
