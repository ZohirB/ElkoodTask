using MediatR;

namespace ElkoodTask.Command.CompanyInfoCommand;

public class CreateCompanyInfoCommand : IRequest<CompanyInfo>
{
    [MaxLength(length: 100)]
    public string Name { get; set; }

    [MaxLength(length: 100)]
    public string location { get; set; }
    public DateTime establishmentDate { get; set; }

    [MaxLength(length: 100)]
    public string activity { get; set; }
}