using DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;
using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.AutoMapperProfiles;

public class TaxObligationWritesProfile : Profile
{
    public TaxObligationWritesProfile()
    {
        CreateMap<TaxObligation, CreateTaxObligationResponse>();
        CreateMap<CreateTaxObligationRequest, CreateTaxObligationCommand>().ReverseMap();

    }
}