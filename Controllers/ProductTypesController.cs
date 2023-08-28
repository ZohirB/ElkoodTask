using ElkoodTask.CQRS.ProductType.Commands.Create;
using ElkoodTask.CQRS.ProductType.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductTypes()
    {
        var query = new GetProductTypeQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductType(CreateProductTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}