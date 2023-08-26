using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Repositories.BranchTypeRepository;

public class BranchTypesService : IBranchTypesService
{
    private readonly ApplicationDbContext _context;

    public BranchTypesService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BranchType>> GetAllBranchType()
    {
        return await _context.BranchTypes.ToListAsync();
    }

    public async Task<BranchType> GetBranchTypeById(int id)
    {
        return await _context.BranchTypes.SingleOrDefaultAsync(bt => bt.Id == id);
    }

    public async Task<BranchType> CreateBranchType(BranchType branchType)
    {
        await _context.AddAsync(branchType);
        _context.SaveChanges();
        return branchType;
    }

    public BranchType UpdateBranchType(BranchType branchType)
    {
        _context.Update(branchType);
        _context.SaveChanges();
        return branchType;
    }

    public BranchType DeleteBranchType(BranchType branchType)
    {
        _context.Remove(branchType);
        _context.SaveChanges();
        return branchType;
    }
}