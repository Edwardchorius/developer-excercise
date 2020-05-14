using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GST.Api.Models.DTOs;

namespace GST.Api.Models.Request
{
    public class TestRequestModel
    {
        public ProductDTO[] Products { get; set; }
        public DealDTO[] Deals { get; set; }
    }
}
