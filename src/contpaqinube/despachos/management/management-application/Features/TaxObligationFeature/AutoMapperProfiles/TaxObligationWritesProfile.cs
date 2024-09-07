using ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;
using ContpaqiNube.Despachos.Management.Domain.Entities;

namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.AutoMapperProfiles;

public class TaxObligationWritesProfile : Profile
{
    public TaxObligationWritesProfile()
    {
        CreateMap<TaxObligation, CreateTaxObligationResponse>();
        CreateMap<CreateTaxObligationRequest, CreateTaxObligationCommand>().ReverseMap();

    }
}