using ElkoodTask.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOperationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductionOperationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var productionOperations = await _context.ProductionOperations
                .Include(po => po.ProductInfo)
                .Select(po => new ProductionDetailsDto
                {
                    Id = po.Id,
                    BranchInfoName = po.BranchInfo.Name,
                    ProductInfoName = po.ProductInfo.Name, 
                    quantity = po.Quantity,
                    RemainingQuantity = po.RemainingQuantity,  
                    date = po.Date
                })
                .ToListAsync();
             return Ok(productionOperations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductionOprerationDto dto)
        {
            var isValidBranchInfo = await _context.BranchInfo.AnyAsync(bi => bi.Id == dto.BranchInfoId);
            var isValidProductInfo = await _context.ProductInfo.AnyAsync(pi => pi.Id == dto.ProductInfoId);
            var isValidBranchType = await _context.BranchInfo
                .Where(bi => bi.BranchTypeId == 1)
                .AnyAsync(bi => bi.Id == dto.BranchInfoId);
            /*  this is not good way to check for Valid Branch Type 
                becuause the id For Primary could not be known yet and in this case i need to make
                select with join (Include) to see where the id goes for (if the id:1 is primary or secondary in the Branch type table) 
                and i still do not know how to apply it :-\
            */
            if (!isValidBranchInfo)
            {
                return BadRequest(error: "Invalid Branch Info ID");
            }
            if (!isValidProductInfo)
            {
                return BadRequest(error: "Invalid Product Info ID");
            }
            if (!isValidBranchType)
            {
                return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:1 (Primary) for production");
            }

            var productionOperation = new ProductionOperation
            {
                ProductInfoId = dto.ProductInfoId,
                BranchInfoId = dto.BranchInfoId,
                Quantity = dto.quantity,
                Date = dto.date
            };
            await _context.AddAsync(productionOperation);
            _context.SaveChanges();
            return Ok(productionOperation);
        }
    }
}
