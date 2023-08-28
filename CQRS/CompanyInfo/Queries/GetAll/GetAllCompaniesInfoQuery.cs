using MediatR;

namespace ElkoodTask.CQRS.CompanyInfo.Queries.GetAll;

public class GetAllCompaniesInfoQuery : IRequest<IEnumerable<ElkoodTask.Models.CompanyInfo>>
{
}