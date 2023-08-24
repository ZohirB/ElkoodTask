using ElkoodTask.Repositories.AllProductProducedRepository;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllProductsProducedController : ControllerBase
    {
        private readonly IAllProductProducedService _allProductProducedService;

        public AllProductsProducedController(IAllProductProducedService allProductProducedService)
        {
            _allProductProducedService = allProductProducedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProducedDetailsDto>>> GetProductDetails(string companyName, DateTime startDate, DateTime endDate)
        {
            var isValidcompanyName = await _allProductProducedService.IsValidCompanyName(companyName);
            if (!isValidcompanyName)
            {
                return BadRequest(error: "Invalid Company Name");
            }

            var productDetails =
                await _allProductProducedService.GetAllProductProduced(companyName, startDate, endDate);
            if (!productDetails.Any())
            {
                return Content("There is no production recorded for the company between the entered date");
            }
            return Ok(productDetails);
        }
    }
}
