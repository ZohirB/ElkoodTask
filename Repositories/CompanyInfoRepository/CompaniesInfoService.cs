using ElkoodTask.CQRS.CompanyInfo.Commands.Create;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Repositories.CompanyInfoRepository;

public class CompaniesInfoService : ICompaniesInfoService
{
    private readonly ApplicationDbContext _context;

    public CompaniesInfoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CompanyInfo>> GetAllCompanyInfo()
    {
        return await _context.CompanyInfo.ToListAsync();
    }

    public async Task<CompanyInfo> AddCompanyInfo(CreateCompanyInfoCommand companyInfoDto)
    {
        var companyInfo = new CompanyInfo
        {
            Name = companyInfoDto.Name,
            Activity = companyInfoDto.activity,
            EstablishmentDate = companyInfoDto.establishmentDate,
            Location = companyInfoDto.location
        };
        await _context.AddAsync(companyInfo);
        _context.SaveChanges();
        return companyInfo;
    }

    public CompanyInfo DeleteCompanyInfo(CompanyInfo companyInfo)
    {
        _context.Remove(companyInfo);
        _context.SaveChanges();
        return companyInfo;
    }

    public async Task<CompanyInfo> GetCompanyInfoById(int id)
    {
        return await _context.CompanyInfo.SingleOrDefaultAsync(ci => ci.Id == id);
    }

    public CompanyInfo UpdateCompanyInfo(CompanyInfo companyInfo)
    {
        _context.Update(companyInfo);
        _context.SaveChanges();
        return companyInfo;
    }
}