namespace Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc
{
    public class GetTaxRegimeByCodeOrDescResponse
    {
        public Guid Id { get; init; }
        public string? Code { get; init; }
        public string? Description { get; init; }
    }
}