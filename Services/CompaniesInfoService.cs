using ElkoodTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Servies
{
    public class CompaniesInfoService : ICompaniesInfoService
    {
        private readonly ApplicationDbContext _context;
        public CompaniesInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CompanyInfo> Add(CompanyInfo companyInfo)
        {
            await _context.AddAsync(companyInfo);
            _context.SaveChanges();
            return companyInfo;
        }

        public CompanyInfo Delete(CompanyInfo companyInfo)
        {
            _context.Remove(companyInfo);
            _context.SaveChanges();
            return companyInfo;
        }

        public async Task<IEnumerable<CompanyInfo>> GetAll()
        {
            return await _context.CompanyInfo.ToListAsync();
        }

        public async Task<CompanyInfo> GetById(int id)
        {
            return await _context.CompanyInfo.SingleOrDefaultAsync(ci => ci.Id == id);
        }

        public CompanyInfo Update(CompanyInfo companyInfo)
        {
            _context.Update(companyInfo);
            _context.SaveChanges();
            return companyInfo;
        }
    }
}
