using ElkoodTask.Repositories.BranchInfoRepository;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchesInfoController : ControllerBase
    {
        private readonly IBranchesInfoService _branchesInfoService;

        public BranchesInfoController(IBranchesInfoService branchesInfoService)
        {
            _branchesInfoService = branchesInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranchInfo()
        {
            var branchInfo = await _branchesInfoService.GetAllBranchInfo();
            return Ok(branchInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranchInfo([FromBody] BranchInfoDto branchInfoDto)
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
                var result = await _branchesInfoService.CreateBranchInfo(branchInfoDto);
                return Ok(result);
            }
        }
    }
}
