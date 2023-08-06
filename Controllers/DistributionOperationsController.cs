using ElkoodTask.Dtos;
using ElkoodTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionOperationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DistributionOperationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var distributionOperations = await _context.DistributionOperations
                .Include(dio => dio.ProductInfo)
                .Select(dio => new DistrubutionDetailsDto
                {
                    Id = dio.Id,
                    PrimaryBranchInfoName = dio.PrimaryBranchInfo.Name,
                    SecondaryBranchInfoName = dio.SecondaryBranchInfo.Name,
                    ProductInfoName = dio.ProductInfo.Name,
                    Quantity = dio.Quantity,
                    Date = dio.Date
                })
                .ToListAsync();
            return Ok(distributionOperations);
        }


        [HttpPost]
        public async Task<IActionResult> AddDistributionOperation([FromBody] DistrubutionOperationDto dto)
        {
            var totalRemainingQuantity = await _context.ProductionOperations
                .Where(po => po.BranchInfoId == dto.PrimaryBranchInfoId && po.ProductInfoId == dto.ProductInfoId)
                .SumAsync(po => po.RemainingQuantity);
            if (totalRemainingQuantity < dto.quantity)
            {
                return BadRequest("Not enough remaining product quantity ;-)");
            }

            var isValidPrimaryBranchType = await _context.BranchInfo
                .Where(bt => bt.BranchTypeId == 1)
                .AnyAsync(bt => bt.Id == dto.PrimaryBranchInfoId);
            if (!isValidPrimaryBranchType)
            {
                return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:2 (Secondary) for Distrubution");
            }

            var isValidSecondaryBranchType = await _context.BranchInfo
                    .Where(bt => bt.BranchTypeId == 2)
                    .AnyAsync(bt => bt.Id == dto.SecondaryBranchInfoId);
            if (!isValidSecondaryBranchType)
            {
                return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:2 (Secondary) for Distrubution");
            }

            var distribution = new DistributionOperation
            {
                PrimaryBranchInfoId = dto.PrimaryBranchInfoId,
                SecondaryBranchInfoId = dto.SecondaryBranchInfoId,
                ProductInfoId = dto.ProductInfoId,
                Quantity = dto.quantity,
                Date = dto.date
            };
            _context.DistributionOperations.Add(distribution);
            var remainingQuantityToUpdate = dto.quantity;
            var productionOperations = await _context.ProductionOperations
                .Where(po => po.BranchInfoId == dto.PrimaryBranchInfoId && po.ProductInfoId == dto.ProductInfoId)
                .OrderBy(po => po.Date)
                .ToListAsync();
            foreach (var production in productionOperations)
            {
                if (remainingQuantityToUpdate <= 0) break;
                var quantityToUpdate = Math.Min(remainingQuantityToUpdate, production.RemainingQuantity);
                production.RemainingQuantity -= quantityToUpdate;
                remainingQuantityToUpdate -= quantityToUpdate;
            }
            await _context.SaveChangesAsync();
            return Ok("The products have been transfer from Production to Distrubution");
        }

        /*
         * i have commented this section beacuse to make the user make change or delete in the 
         * Distrubution section there most be method to change the changes in the produdtion data
         * (remainig quantitiy) and making that method not necessary at this time ;-)
        /*

        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DistrubutionOperationDto dto)
        {
            var distributionOperation = await _context.DistributionOperations.SingleOrDefaultAsync(bt => bt.Id == id);
            if (distributionOperation == null)
            {
                return NotFound(value: $"No Distribution Operation was found with Id: {id}");
            }
            distributionOperation.PrimaryBranchInfoId = dto.PrimaryBranchInfoId;
            distributionOperation.SecondaryBranchInfoId = dto.SecondaryBranchInfoId;
            distributionOperation.ProductInfoId = dto.ProductInfoId;
            distributionOperation.Quantity = dto.quantity;
            distributionOperation.Date = dto.date;

            _context.SaveChanges();
            return Ok(distributionOperation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var distributionOperation = await _context.DistributionOperations.SingleOrDefaultAsync(bi => bi.Id == id);
            if (distributionOperation == null)
            {
                return NotFound(value: $"No Distribution Operation was found with Id: {id}");
            }
            _context.DistributionOperations.Remove(distributionOperation);
            _context.SaveChanges();
            return Ok(distributionOperation);
        }
        */
    }
}
