using ElkoodTask.Repositories.CompanyInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.CompanyInfo.Queries.GetAll;

public class GetAllCompaniesInfoHandler : IRequestHandler<GetAllCompaniesInfoQuery, IEnumerable<ElkoodTask.Models.CompanyInfo>>
{
    private readonly ICompaniesInfoService _companiesInfoService;

    public GetAllCompaniesInfoHandler(ICompaniesInfoService companiesInfoService)
    {
        _companiesInfoService = companiesInfoService;
    }


    public async Task<IEnumerable<ElkoodTask.Models.CompanyInfo>> Handle(GetAllCompaniesInfoQuery request,
        CancellationToken cancellationToken)
    {
        var companyInfo = await _companiesInfoService.GetAllCompanyInfo();
        return companyInfo;
    }
}