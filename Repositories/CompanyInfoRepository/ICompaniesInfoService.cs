namespace ElkoodTask.Repositories.CompanyInfoRepository
{
    public interface ICompaniesInfoService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanyInfo();
        Task<CompanyInfo> GetCompanyInfoById(int id);
        Task<CompanyInfo> AddCompanyInfo(CompanyInfoDto companyInfo);
        CompanyInfo UpdateCompanyInfo(CompanyInfo companyInfo);
        CompanyInfo DeleteCompanyInfo(CompanyInfo companyInfo);
    }
}
