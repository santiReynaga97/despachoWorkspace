

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;
public record GetAllTaxObligationsResponse
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
}
