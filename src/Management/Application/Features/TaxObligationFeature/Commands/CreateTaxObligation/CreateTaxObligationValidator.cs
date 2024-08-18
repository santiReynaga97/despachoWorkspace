using DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;

public class CreateTaxObligationValidator: AbstractValidator<CreateTaxObligationCommand>
{
    public CreateTaxObligationValidator()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty();
        RuleFor(_ => _.Description).NotNull().NotEmpty(); 
        RuleFor(_ => _.Code).NotNull().NotEmpty();        
        RuleFor(_ => _.IsActive).NotNull().NotEmpty();         
    }
}