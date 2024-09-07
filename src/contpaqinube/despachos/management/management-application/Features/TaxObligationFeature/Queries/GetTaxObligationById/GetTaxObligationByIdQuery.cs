
using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;


namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Queries.GetTaxObligationById;

public class GetTaxObligationByIdQuery : IRequest<IDataResult<GetAllTaxObligationsResponse>>
{
    public Guid TaxObligationId { get; private set; }

    public GetTaxObligationByIdQuery(Guid taxObligationId)
    {
        TaxObligationId = taxObligationId;
    }
}