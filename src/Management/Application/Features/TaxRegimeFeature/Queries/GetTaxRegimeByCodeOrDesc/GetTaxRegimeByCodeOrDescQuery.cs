using Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc;
using DespachoWorkspace.Management.Application.Common.Models.Results;

namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc;

public class GetTaxRegimeByCodeOrDescQuery : IRequest<IDataResult<List<GetTaxRegimeByCodeOrDescResponse>>>
{
    public string CodeOrDescription { get; private set; }

    public GetTaxRegimeByCodeOrDescQuery(string codeOrDescription)
    {
        CodeOrDescription = codeOrDescription;
    }
}