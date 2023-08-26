using ElkoodTask.Repositories.ProductTypeRepository;
using Microsoft.AspNetCore.Mvc;

namespace ElkoodTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTypesController : ControllerBase
{
    private readonly IProductTypesService productTypesService;

    public ProductTypesController(IProductTypesService productTypesService)
    {
        this.productTypesService = productTypesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var ProductType = await productTypesService.GetAllProductTypes();
        return Ok(ProductType);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ProductTypeDto dto)
    {
        var productType = new ProductType { Name = dto.Name };
        await productTypesService.CreateProductType(productType);
        return Ok(productType);
    }
}