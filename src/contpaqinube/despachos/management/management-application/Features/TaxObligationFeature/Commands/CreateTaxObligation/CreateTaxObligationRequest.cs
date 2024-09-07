

namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation
{
    public record CreateTaxObligationRequest(string Code, string Description, bool IsActive, string Name);
}
