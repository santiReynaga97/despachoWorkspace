

namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation
{
    public record CreateTaxObligationResponse
    {
        public Guid Id { get; init; }
        public string? Code { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public string Name { get; set; } = null!;
    }
}
