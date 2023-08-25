using ElkoodTask.Queries.AllProductProducedQuery;
using ElkoodTask.Repositories.AllProductProducedRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllProductsProducedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AllProductsProducedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductProducedDetailsDto>>> GetProductDetails([FromQuery] GetAllProductProducedQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
