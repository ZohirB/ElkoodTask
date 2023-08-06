namespace ElkoodTask.Servies
{
    public interface ICompaniesInfoService
    {
        Task<IEnumerable<CompanyInfo>> GetAll();
        Task<CompanyInfo> GetById(int id);
        Task<CompanyInfo> Add(CompanyInfo companyInfo);
        CompanyInfo Update(CompanyInfo companyInfo);
        CompanyInfo Delete(CompanyInfo companyInfo);
    }
}
