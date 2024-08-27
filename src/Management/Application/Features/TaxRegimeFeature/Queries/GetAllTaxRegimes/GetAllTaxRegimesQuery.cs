
using DespachoWorkspace.Management.Application.Common.Models.Results;

namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries.GetAllTaxRegimes;

public record GetAllTaxRegimesQuery : IRequest<IDataResult<List<GetAllTaxRegimesResponse>>>
{
    
}