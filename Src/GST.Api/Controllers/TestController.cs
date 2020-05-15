
using System.Linq;
using System.Threading.Tasks;
using GST.Api.Controllers.Base;
using GST.Api.Models.Request;
using GST.Api.Models.Response;
using GST.Application.Commands.Features.CalculateTotalSum;
using GST.Application.Commands.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GST.Api.Controllers
{
    public class TestController : BaseController
    {
        public TestController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<double>> Test([FromBody] ScannedProductsRequest request)
        {            
            var command = new CalculcateTotalSumCommand(request.Products.Names, request.Deals.Name, request.Deals.ProductsInvolved);
            ScannedProductsResponse response = new ScannedProductsResponse();
            response.FinalPrice = await Mediator.Send(command);

            return Ok(response.FinalPrice);
        }
    }
}
