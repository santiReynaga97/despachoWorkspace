using DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;
using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.AutoMapperProfiles;

public class TaxObligationReadsProfile : Profile
{
    public TaxObligationReadsProfile()
    {
        CreateMap<TaxObligation, GetAllTaxObligationsResponse>();

    }
}