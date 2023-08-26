using ElkoodTask.CQRS.Queries.ProductProducedQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsProducedController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsProducedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductProducedDetailsDto>>> GetAllProductsProduced(
        [FromQuery] GetAllProductProducedQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}