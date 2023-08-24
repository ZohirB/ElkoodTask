using ElkoodTask.Queries;
using ElkoodTask.Servies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllBranchTypeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task <IActionResult> CreateAsync(CreateBranchTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result); 
        }
    }
}
