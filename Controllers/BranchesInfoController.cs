using ElkoodTask.Servies;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesInfoController : ControllerBase
    {
        private readonly IBranchesInfoService _branchesInfoService;

        public BranchesInfoController(IBranchesInfoService branchesInfoService)
        {
            _branchesInfoService = branchesInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var branchInfo = await _branchesInfoService.GetAllBranchInfo();
            return Ok(branchInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BranchInfoDto branchInfoDto)
        {
            var isValidBranchType = await _branchesInfoService.IsValidBranchType(branchInfoDto.BranchTypeId); 
            var isValidCompanyInfo = await _branchesInfoService.IsValidCompanyInfo(branchInfoDto.CompanyInfoId); 
            
            if (!isValidBranchType) 
            {
                return BadRequest(error: "Invalid Branch Type ID");
            }
            if (!isValidCompanyInfo)
            {
                return BadRequest(error: "Invalid Company Info ID");
            }
            else
            {
                var result = await _branchesInfoService.AddBranchInfo(branchInfoDto);
                return Ok(result);
            }
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BranchInfo dto)
        {
            var isValidBranchInfo = await _branchesInfoService.IsValidBranchInfo(id);
            if (isValidBranchInfo == null)
            {
                return NotFound(value: $"No Branch Info was found with Id: {id}");
            }
            else
            {
                var branchInfo = _branchesInfoService.AddBranchInfo(dto);
                return Ok(branchInfo); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isValidBranchInfo = await _branchesInfoService.IsValidBranchInfo(id);
            if (isValidBranchInfo == null)
            {
                return NotFound(value: $"No Branch Info was found with Id: {id}");
            }
            else
            {
                var branchInfo = _branchesInfoService.DeleteBranchInfo(isValidBranchInfo);
                return Ok(branchInfo);  
            }

        }
        */
    }
}
