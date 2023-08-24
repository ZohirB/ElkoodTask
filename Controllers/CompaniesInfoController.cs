using ElkoodTask.Repositories.CompanyInfoRepository;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesInfoController : ControllerBase
    {
        private readonly ICompaniesInfoService _companiesInfoService;

        public CompaniesInfoController(ICompaniesInfoService companiesInfoService)
        {
            this._companiesInfoService = companiesInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesInfo()
        {
            var companyInfo = await _companiesInfoService.GetAllCompanyInfo();
            return Ok(companyInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyInfo(CompanyInfoDto companyInfoDto)
        {
            var companyInfo = await _companiesInfoService.AddCompanyInfo(companyInfoDto);
            return Ok(companyInfo);
        }  
    }
}
