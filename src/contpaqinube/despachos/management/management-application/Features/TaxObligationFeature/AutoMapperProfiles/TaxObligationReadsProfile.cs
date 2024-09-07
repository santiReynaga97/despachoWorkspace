using ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;
using ContpaqiNube.Despachos.Management.Domain.Entities;

namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.AutoMapperProfiles;

public class TaxObligationReadsProfile : Profile
{
    public TaxObligationReadsProfile()
    {
        CreateMap<TaxObligation, GetAllTaxObligationsResponse>();

    }
}