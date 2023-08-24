namespace ElkoodTask.Repositories.DistributionOperationRepository;

public interface IDistributionOperationService
{
    Task<List<DistrubutionDetailsDto>> GetAllDistributionOperation();
    void CreateDistributionOperation(DistrubutionOperationDto distrubutionOperationDto);
    Task<int> TotalRemainingQuantity (DistrubutionOperationDto distrubutionOperationDto);
    Task<bool> IsValidPrimaryBranchTypeTask(DistrubutionOperationDto distrubutionOperationDto);
    Task<bool> IsValidSecondaryBranchType(DistrubutionOperationDto distrubutionOperationDto);
}