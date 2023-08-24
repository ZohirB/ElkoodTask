using System.Threading.Tasks;
using ElkoodTask.Dtos;
using ElkoodTask.Models;
using ElkoodTask.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesInfoController : ControllerBase
    {
        private readonly ICompaniesInfoService _companiesInfoService;

        public CompaniesInfoController(ICompaniesInfoService companiesInfoService)
        {
            this._companiesInfoService = companiesInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var companyInfo = await _companiesInfoService.GetAllCompanyInfo();
            return Ok(companyInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CompanyInfoDto companyInfoDto)
        {
            var companyInfo = await _companiesInfoService.AddCompanyInfo(companyInfoDto);
            return Ok(companyInfo);
        }
        
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CompanyInfo dto)
        {
            var companyInfo = await companiesInfoService.GetCompanyInfoById(id);
            if (companyInfo == null)
            {
                return NotFound(value: $"No Company Info was found with Id: {id}");
            }
            companyInfo.Name = dto.Name;
            companyInfo.Activity = dto.Activity;
            companyInfo.EstablishmentDate = dto.EstablishmentDate;
            companyInfo.Location = dto.Location;
            companiesInfoService.UpdateCompanyInfo(companyInfo);   
            return Ok(companyInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var companyInfo = await companiesInfoService.GetCompanyInfoById(id);
            if (companyInfo == null)
            {
                return NotFound(value: $"No Company Info was found with Id: {id}");
            }
            companiesInfoService.DeleteCompanyInfo(companyInfo);
            return Ok(companyInfo);
        }
        */
    }
}
