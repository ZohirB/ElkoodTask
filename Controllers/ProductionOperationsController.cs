using ElkoodTask.CQRS.Command.ProductionOprationCommand;
using ElkoodTask.CQRS.Queries.ProductionOprationQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductionOperationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductionOperationsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProductionOperations()
    {
        var query = new GetAllProductionOprationQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductionOperation([FromBody] CreateProductionOprationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}