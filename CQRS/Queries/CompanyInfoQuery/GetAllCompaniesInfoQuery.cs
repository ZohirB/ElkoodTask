using MediatR;

namespace ElkoodTask.CQRS.Queries.CompanyInfoQuery;

public class GetAllCompaniesInfoQuery : IRequest<IEnumerable<CompanyInfo>>
{
}