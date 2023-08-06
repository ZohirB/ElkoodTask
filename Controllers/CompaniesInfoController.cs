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
        private readonly ICompaniesInfoService companiesInfoService;

        public CompaniesInfoController(ICompaniesInfoService companiesInfoService)
        {
            this.companiesInfoService = companiesInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var CompanyInfo = await companiesInfoService.GetAll();
            return Ok(CompanyInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CompanyInfoDto dto)
        {
            var companyInfo = new CompanyInfo { 
                Name = dto.Name, 
                Activity = dto.activity,
                EstablishmentDate = dto.establishmentDate,
                Location = dto.location
            };
            await companiesInfoService.Add(companyInfo);
            return Ok(companyInfo);
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CompanyInfo dto)
        {
            var companyInfo = await companiesInfoService.GetById(id);
            if (companyInfo == null)
            {
                return NotFound(value: $"No Company Info was found with Id: {id}");
            }
            companyInfo.Name = dto.Name;
            companyInfo.Activity = dto.Activity;
            companyInfo.EstablishmentDate = dto.EstablishmentDate;
            companyInfo.Location = dto.Location;
            companiesInfoService.Update(companyInfo);   
            return Ok(companyInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var companyInfo = await companiesInfoService.GetById(id);
            if (companyInfo == null)
            {
                return NotFound(value: $"No Company Info was found with Id: {id}");
            }
            companiesInfoService.Delete(companyInfo);
            return Ok(companyInfo);
        }
        */
    }
}
