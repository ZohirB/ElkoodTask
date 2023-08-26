using ElkoodTask.CQRS.Command.CompanyInfoCommand;
using ElkoodTask.Repositories.CompanyInfoRepository;
using MediatR;

namespace ElkoodTask.CQRS.Handlers.CompanyInfoHandler;

public class CreateCompanyInfoHandler : IRequestHandler<CreateCompanyInfoCommand, CompanyInfo>
{
    private readonly ICompaniesInfoService _companiesInfoService;

    public CreateCompanyInfoHandler(ICompaniesInfoService companiesInfoService)
    {
        _companiesInfoService = companiesInfoService;
    }


    public async Task<CompanyInfo> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
    {
        var companyInfo = await _companiesInfoService.AddCompanyInfo(request);
        return companyInfo;
    }
}