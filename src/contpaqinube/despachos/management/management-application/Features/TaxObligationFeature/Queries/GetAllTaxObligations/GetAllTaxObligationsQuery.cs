
using ContpaqiNube.Despachos.Management.Application.Common.Models.Results;

namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;

public record GetAllTaxObligationsQuery : IRequest<IDataResult<List<GetAllTaxObligationsResponse>>>
{    

}