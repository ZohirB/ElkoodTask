using ElkoodTask.Command.DistributionOperationCommand;
using ElkoodTask.Repositories.DistributionOperationRepository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ElkoodTask.Handlers.DistributionOperationsHandler;

public class CreateDistributionOperationHandler : IRequestHandler<CreateDistributionOperationCommand, DistributionOperation>
{
        private readonly IDistributionOperationService _distributionOperationService;

        public CreateDistributionOperationHandler(IDistributionOperationService distributionOperationService)
        {
                _distributionOperationService = distributionOperationService;
        }

        public async Task<DistributionOperation> Handle(CreateDistributionOperationCommand request, CancellationToken cancellationToken)
        {
                //TODO find solution for checking response Create Create new Distribution Operation
        /*
                var totalRemainingQuantity =  await _distributionOperationService.TotalRemainingQuantity(request);
                if (totalRemainingQuantity < request.quantity)
                {
                        return BadRequest("Not enough remaining product quantity ;-)");
                }

                var isValidPrimaryBranchType = await _distributionOperationService.IsValidPrimaryBranchTypeTask(request);
                if (!isValidPrimaryBranchType)
                {
                        return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:2 (Secondary) for Distrubution");
                }

                var isValidSecondaryBranchType = await _distributionOperationService.IsValidSecondaryBranchType(request);
                if (!isValidSecondaryBranchType)
                {
                        return BadRequest(error: "Invalid Branch Type ID... you can only USE ID:2 (Secondary) for Distrubution");
                }
        */
        // TODO check for bug
                _distributionOperationService.CreateDistributionOperation(request);
                var distributionOperation =  new DistributionOperation
                {
                        Quantity = request.quantity,
                        Date = request.date,

                };
                return distributionOperation;
                //return "The products have been transfer from Production to Distrubution";
        }
}