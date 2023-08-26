﻿using ElkoodTask.CQRS.Command.ProductsInfoCommand;
using ElkoodTask.CQRS.Queries.ProductsInfoQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsInfo()
    {
        var query = new GetAllProductsInfoQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductsInfo([FromBody] CreateProductsInfoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}