using ElkoodTask.Repositories.DistributionOperationRepository;
using Microsoft.AspNetCore.Mvc;


namespace ElkoodTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DistributionOperationsController : ControllerBase
    {
        private readonly IDistributionOperationService _distributionOperationService;

        public DistributionOperationsController(IDistributionOperationService distributionOperationService)
        {
            _distributionOperationService = distributionOperationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDistributionOperation()
        {
            var distributionOperation = await _distributionOperationService.GetAllDistributionOperation();
            return Ok(distributionOperation);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDistributionOperation([FromBody] DistrubutionOperationDto distrubutionOperationDto)
        {
            var totalRemainingQuantity =  await _distributionOperationService.TotalRemainingQuantity(distrubutionOperationDto);
            if (totalRemainingQuantity < distrubutionOperationDto.quantity)
            {
                return BadRequest("Not enough remaining product quantity ;-)");
            }

            var isValidPrimaryBranchType = await _distributionOperationService.IsValidPrimaryBranchTypeTask(distrubutionOperationDto);
            if (!isValidPrimaryBranchType)
            {
                return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:2 (Secondary) for Distrubution");
            }

            var isValidSecondaryBranchType = await _distributionOperationService.IsValidSecondaryBranchType(distrubutionOperationDto);
            if (!isValidSecondaryBranchType)
            {
                return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:2 (Secondary) for Distrubution");
            }

            _distributionOperationService.CreateDistributionOperation(distrubutionOperationDto);
            return Ok("The products have been transfer from Production to Distrubution");
        }
    }
}
