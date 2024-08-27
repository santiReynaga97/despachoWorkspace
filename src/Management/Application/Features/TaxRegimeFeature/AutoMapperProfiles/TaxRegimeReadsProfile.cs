using Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc;
using DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries.GetAllTaxRegimes;
using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.AutoMapperProfiles;

public class TaxRegimeReadsProfile : Profile
{
    public TaxRegimeReadsProfile()
    {
        CreateMap<TaxRegime, GetAllTaxRegimesResponse>();
        CreateMap<TaxRegime, GetTaxRegimeByCodeOrDescResponse>();
    }
}