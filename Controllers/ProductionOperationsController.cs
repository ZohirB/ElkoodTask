using ElkoodTask.Repositories.ProductionOperationRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductionOperationsController : ControllerBase
    {
        private readonly IProductionOperationService _productionOperationService;

        public ProductionOperationsController(IProductionOperationService productionOperationService)
        {
            _productionOperationService = productionOperationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductionOperations()
        {
            var productionOperations = await _productionOperationService.GetAllProductionOperations();
             return Ok(productionOperations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductionOperation([FromBody] ProductionOprerationDto productionOprerationDto)
        {
            var isValidBranchInfo =
                await _productionOperationService.IsValidBranchInfo(productionOprerationDto.BranchInfoId);
            var isValidProductInfo =
                await _productionOperationService.IsValidProductInfo(productionOprerationDto.ProductInfoId);
            var isValidBranchType =
                await _productionOperationService.IsValidBranchType(productionOprerationDto.BranchInfoId);
            
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

            var productionOperation =
                await _productionOperationService.CreateProductionOperation(productionOprerationDto);
            return Ok(productionOperation);
        }
    }
}
