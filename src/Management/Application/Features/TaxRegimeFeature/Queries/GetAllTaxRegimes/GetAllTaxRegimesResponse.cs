namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries.GetAllTaxRegimes;
public record GetAllTaxRegimesResponse
{
    public Guid Id { get; init; }
    public string? Code { get; init; }
}