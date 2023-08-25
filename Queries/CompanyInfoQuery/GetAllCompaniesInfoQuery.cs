using MediatR;

namespace ElkoodTask.Queries.CompanyInfoQuery;

public class GetAllCompaniesInfoQuery : IRequest<IEnumerable<CompanyInfo>>
{
    
}