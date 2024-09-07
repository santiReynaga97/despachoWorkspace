
using ContpaqiNube.Despachos.Management.Application.Common.Models.Results;
using ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;


namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetTaxObligationById;

public class GetTaxObligationByIdQuery : IRequest<IDataResult<GetAllTaxObligationsResponse>>
{
    public Guid TaxObligationId { get; private set; }

    public GetTaxObligationByIdQuery(Guid taxObligationId)
    {
        TaxObligationId = taxObligationId;
    }
}