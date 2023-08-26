using Elkood.Application.OperationResponses;
using ElkoodTask.CQRS.Command.DistributionOperationCommand;
using ElkoodTask.CQRS.Queries.DistributionOperationsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DistributionOperationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DistributionOperationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDistributionOperation()
    {
        var query = new GetAllDistributionOperationsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddDistributionOperation([FromBody] CreateDistributionOperationCommand command)
    {
        return await _mediator.Send(command).ToJsonResultAsync();
    }
}