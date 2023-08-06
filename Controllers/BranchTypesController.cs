using ElkoodTask.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchTypesController : ControllerBase
    {
        private readonly IBranchTypesService branchTypesService;

        public BranchTypesController(IBranchTypesService branchTypesService)
        {
            this.branchTypesService = branchTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var BranchTypes = await branchTypesService.GetAll();
            return Ok(BranchTypes);
        }

        [HttpPost]
        public async Task <IActionResult> CreateAsync(BranchTypeDto dto)
        {
            var branchType = new BranchType { Name = dto.Name};
            await branchTypesService.Add(branchType);
            return Ok(branchType); 
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BranchType dto)
        {
            var  branchType = await branchTypesService.GetById(id);
            if (branchType == null)
            {
                return NotFound(value: $"No Branch Type was found with Id: {id}");
            }
            branchType.Name = dto.Name;
            branchTypesService.Update(branchType);
            return Ok(branchType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync (int id)
        {
            var branchType = await branchTypesService.GetById(id);
            if (branchType == null)
            {
                return NotFound(value: $"No Branch Type was found with Id: {id}");
            }
            branchTypesService.Delete(branchType);
            return Ok(branchType);
        }
        */
    }
}
