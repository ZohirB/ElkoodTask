using System.Linq;
using System.Threading.Tasks;
using ElkoodTask.Dtos;
using ElkoodTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var productsInfo = await _context.ProductInfo
                .Include(pi => pi.ProductType)
                .Select(pi => new ProductDetailsDto
                {
                    Id = pi.Id,
                    Name = pi.Name,
                    ProductTypeName = pi.ProductType.Name
                })
                .ToListAsync();
            return Ok(productsInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductInfoDto dto)
        {
            var isValidProductType = await _context.ProductTypes.AnyAsync(pi => pi.Id == dto.ProductTypeId);
            if (!isValidProductType)
            {
                return BadRequest(error: "Invalid Product Type ID");
            }

            var productInfo = new ProductInfo
            {
                Name = dto.Name,
                ProductTypeId = dto.ProductTypeId
            };
            await _context.AddAsync(productInfo);
            _context.SaveChanges();
            return Ok(productInfo);
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductInfo dto)
        {
            var productInfo = await _context.ProductInfo.SingleOrDefaultAsync(bt => bt.Id == id);
            if (productInfo == null)
            {
                return NotFound(value: $"No Product Info was found with Id: {id}");
            }
            productInfo.Name = dto.Name;
            productInfo.ProductTypeId = dto.ProductTypeId;
            _context.SaveChanges();
            return Ok(productInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productInfo = await _context.ProductInfo.SingleOrDefaultAsync(bi => bi.Id == id);
            if (productInfo == null)
            {
                return NotFound(value: $"No Product Info was found with Id: {id}");
            }
            _context.ProductInfo.Remove(productInfo);
            _context.SaveChanges();
            return Ok(productInfo);
        }
        */
    }
}
