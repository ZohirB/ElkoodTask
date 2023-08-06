using ElkoodTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BranchesInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var branchesInfo = await _context.BranchInfo
                .Include(bi => bi.CompanyInfo)
                .Select(pi => new BranchDetailsDto
                {
                    Id = pi.Id,
                    Name = pi.Name,
                    BranchTypeName = pi.BranchType.Name,
                    CompanyInfoName = pi.CompanyInfo.Name,
                    location = pi.Location
                })
                .ToListAsync();
            return Ok(branchesInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BranchInfoDto dto)
        {
            var isValidBranchType = await _context.BranchTypes.AnyAsync(bi => bi.Id == dto.BranchTypeId);
            var isValidCompanyInfo = await _context.CompanyInfo.AnyAsync(bi => bi.Id == dto.CompanyInfoId);
            
            if (!isValidBranchType) 
            {
                return BadRequest(error: "Invalid Branch Type ID");
            }
            if (!isValidCompanyInfo)
            {
                return BadRequest(error: "Invalid Company Info ID");
            }

            var branchInfo = new BranchInfo
            {
                Name = dto.Name,
                BranchTypeId = dto.BranchTypeId,
                CompanyInfoId = dto.CompanyInfoId,
                Location = dto.location
            };
            await _context.AddAsync(branchInfo);
            _context.SaveChanges();
            return Ok(branchInfo);
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BranchInfo dto)
        {
            var branchInfo = await _context.BranchInfo.SingleOrDefaultAsync(bt => bt.Id == id);
            if (branchInfo == null)
            {
                return NotFound(value: $"No Branch Type was found with Id: {id}");
            }
            branchInfo.Name = dto.Name;
            branchInfo.BranchTypeId = dto.BranchTypeId; 
            branchInfo.CompanyInfoId = dto.CompanyInfoId;
            branchInfo.Location = dto.Location;
            _context.SaveChanges();
            return Ok(branchInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var branchInfo = await _context.BranchInfo.SingleOrDefaultAsync(bi => bi.Id == id);
            if (branchInfo == null)
            {
                return NotFound(value: $"No Branch Info was found with Id: {id}");
            }
            _context.BranchInfo.Remove(branchInfo);
            _context.SaveChanges();
            return Ok(branchInfo);
        }
        */
    }
}
