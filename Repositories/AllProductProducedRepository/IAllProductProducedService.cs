namespace ElkoodTask.Repositories.AllProductProducedRepository;

public interface IAllProductProducedService
{
    Task<List<ProductProducedDetailsDto>> GetAllProductProduced(string companyName, DateTime startDate,
        DateTime endDate);

    Task<bool> IsValidCompanyName(string companyName);
}