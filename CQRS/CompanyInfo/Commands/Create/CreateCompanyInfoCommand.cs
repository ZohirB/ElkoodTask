using MediatR;

namespace ElkoodTask.CQRS.CompanyInfo.Commands.Create;

public class CreateCompanyInfoCommand : IRequest<ElkoodTask.Models.CompanyInfo>
{
    [MaxLength(100)] public string Name { get; set; }

    [MaxLength(100)] public string location { get; set; }

    public DateTime establishmentDate { get; set; }

    [MaxLength(100)] public string activity { get; set; }
}