using DespachoWorkspace.Management.Application.Common.Models.Results;


namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;

public class CreateTaxObligationCommand : IRequest<IDataResult<CreateTaxObligationResponse>>
{
    public string? Code { get; set; }   

    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Name { get; set; } = null!;

    public CreateTaxObligationCommand(string code, string description, bool isActive, string name)
    {
        Code = code;        
        Description = description;
        IsActive = isActive;
        Name = name;
    }
}
