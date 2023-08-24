namespace ElkoodTask.Servies;

public interface IBranchesInfoService
{
    Task<IEnumerable<BranchDetailsDto>> GetAllBranchInfo();
    Task<BranchInfo> AddBranchInfo(BranchInfoDto branchInfoDto);
    Task<BranchInfo> UpdateBranchInfo(int id, BranchInfo branchInfo);
    Task<BranchInfo> DeleteBranchInfo(BranchInfo branchInfo);
    Task<bool> IsValidBranchType(int branchTypeId);
    Task<bool> IsValidCompanyInfo(int companyInfoId);
    
    Task<BranchInfo> IsValidBranchInfo(int companyInfoId);
    
}