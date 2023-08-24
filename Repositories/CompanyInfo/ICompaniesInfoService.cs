using System.Collections.Generic;
using System.Threading.Tasks;
using ElkoodTask.Models;

namespace ElkoodTask.Servies
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
