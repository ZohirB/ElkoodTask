using ElkoodTask.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
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
            var ProductType = await productTypesService.GetAll();
            return Ok(ProductType);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductTypeDto dto)
        {
            var productType = new ProductType { Name = dto.Name };
            await productTypesService.Add(productType);
            return Ok(productType);
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductType dto)
        {
            var productType = await productTypesService.GetById(id);
            if (productType == null)
            {
                return NotFound(value: $"No Product Type was found with Id: {id}");
            }
            productType.Name = dto.Name;
            productTypesService.Update(productType);
            return Ok(productType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productType = await productTypesService.GetById(id);
            if (productType == null)
            {
                return NotFound(value: $"No Product Type was found with Id: {id}");
            }
            productTypesService.Delete(productType);
            return Ok(productType);
        }
        */
    }
}
