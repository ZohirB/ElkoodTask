using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllProductsProducedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AllProductsProducedController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProducedDetailsDto>>> GetProductDetails(string companyName, DateTime startDate, DateTime endDate)
        {
            var isValidcompanyName = await _context.CompanyInfo.AnyAsync(ci => ci.Name == companyName);
            if (!isValidcompanyName)
            {
                return BadRequest(error: "Invalid Company Name");
            }

            var productDetails = await _context.ProductionOperations
                            .Include(p => p.BranchInfo)
                            .ThenInclude(b => b.CompanyInfo)
                            .Include(p => p.ProductInfo)
                            .Where(p => p.BranchInfo.CompanyInfo.Name == companyName &&
                                        p.Date >= startDate &&
                                        p.Date <= endDate)
                            .GroupBy(p => p.ProductInfo.Name)
                            .Select(g => new ProductProducedDetailsDto
                            {
                                ProductName = g.Key,
                                TotalQuantity = g.Sum(p => p.Quantity)
                            })
                            .ToListAsync();

            if (productDetails == null || !productDetails.Any())
            {
                return Content("There is no production recorded for the company between the entered date");
            }

            return Ok(productDetails);
        }
    }
}
