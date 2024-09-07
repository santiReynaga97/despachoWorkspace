
using DespachoWorkspace.Management.Application.Common.Models.Results;

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;

public record GetAllTaxObligationsQuery : IRequest<IDataResult<List<GetAllTaxObligationsResponse>>>
{    

}