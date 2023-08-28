using ElkoodTask.Repositories.CompanyInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.CompanyInfo.Commands.Create;

public class CreateCompanyInfoHandler : IRequestHandler<CreateCompanyInfoCommand, ElkoodTask.Models.CompanyInfo>
{
    private readonly ICompaniesInfoService _companiesInfoService;

    public CreateCompanyInfoHandler(ICompaniesInfoService companiesInfoService)
    {
        _companiesInfoService = companiesInfoService;
    }


    public async Task<ElkoodTask.Models.CompanyInfo> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
    {
        var companyInfo = await _companiesInfoService.AddCompanyInfo(request);
        return companyInfo;
    }
}