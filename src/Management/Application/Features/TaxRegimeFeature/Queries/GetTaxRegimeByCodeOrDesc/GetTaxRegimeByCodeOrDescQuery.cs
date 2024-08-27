
using Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc;
using DespachoWorkspace.Management.Application.Common.Models.Results;

namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc;

public class GetTaxRegimeByCodeOrDescQuery : IRequest<IDataResult<List<GetTaxRegimeByCodeOrDescResponse>>>
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    public GetTaxRegimeByCodeOrDescQuery(string code, string description)
    {
        Code = code;
        Description = description;
    }
}