using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsProducedController : ControllerBase
    {
        private ApplicationDbContext _context;
        public ProductsProducedController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get(string companyName, int primaryBranchId, DateTime fromDate, DateTime toDate)
        {
            var primaryBranch = _context.BranchInfo.FirstOrDefault(b => b.Id == primaryBranchId && b.CompanyInfo.Name.Equals(companyName) && b.BranchType.Name.Equals("Primary"));
            if (primaryBranch == null)
            {
                return BadRequest("Invalid primary branch or company name.");
            }
            var quantitiesByProductName = _context.ProductionOperations
                .Where(p => p.BranchInfoId == primaryBranchId && p.Date >= fromDate && p.Date <= toDate)
                .GroupBy(p => p.ProductInfo.Name)
                .Select(g => new { ProductName = g.Key, TotalQuantityProduced = g.Sum(p => p.Quantity) })
                .ToList();

            return Ok(quantitiesByProductName);
        }
    }
}
