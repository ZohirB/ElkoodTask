using ElkoodTask.Repositories.ProductsInfoRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsInfoController : ControllerBase
    {
        private readonly IProductsInfoService _productsInfoService;

        public ProductsInfoController(IProductsInfoService productsInfoService)
        {
            _productsInfoService = productsInfoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProductsInfo()
        {
            var productsInfo = await _productsInfoService.GetAllProductsInfo();
            return Ok(productsInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductsInfo([FromBody] ProductInfoDto productInfoDto)
        {
            var isValidProductType = await _productsInfoService.IsValidProductType(productInfoDto.ProductTypeId);
            if (!isValidProductType)
            {
                return BadRequest(error: "Invalid Product Type ID");
            }

            var productInfo = await _productsInfoService.CreateProductsInfo(productInfoDto);
            return Ok(productInfo);
        }
    }
}
