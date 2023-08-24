using ElkoodTask.Repositories.ProductsProducedRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsProducedController : ControllerBase
    {
        private IProductsProducedService _productsProducedService;

        public ProductsProducedController(IProductsProducedService productsProducedService)
        {
            _productsProducedService = productsProducedService;
        }

        [HttpGet]
        public IActionResult GetAllProductsProduced(string companyName, int primaryBranchId, DateTime fromDate, DateTime toDate)
        {
            var isValidPrimaryBranch = _productsProducedService.IsValidPrimaryBranch(primaryBranchId, companyName);
            if (isValidPrimaryBranch == null)
            {
                return BadRequest("Invalid primary branch or company name.");
            }
            var quantitiesByProductName = _productsProducedService.GetAllProductsProduced(primaryBranchId, fromDate, toDate);
            return Ok(quantitiesByProductName);
        }
    }
}
