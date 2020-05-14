
using System.Linq;
using System.Threading.Tasks;
using GST.Api.Controllers.Base;
using GST.Api.Models.Request;
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

        [HttpGet("[action]")]
        public async Task<ActionResult<double>> Test([FromQuery] TestRequestModel request)
        {
            ProductsInputModel[]? productsInputModels = request.Products.Select(k => new ProductsInputModel(k.Name, k.PriceValue)).ToArray();
            DealInputModel[]? dealsInputModels = request.Deals.Select(k => new DealInputModel(k.Name, productsInputModels)).ToArray();

            var command = new CalculcateTotalSumCommand(productsInputModels, dealsInputModels);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
