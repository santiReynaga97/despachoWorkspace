using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxObligations;

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;

public class GetAllTaxObligationsQueryHandler : IRequestHandler<GetAllTaxObligationsQuery, IDataResult<List<GetAllTaxObligationsResponse>>>
{
    private readonly ITaxObligationReadRepository _taxObligationReadRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllTaxObligationsQueryHandler> _logger;

    public GetAllTaxObligationsQueryHandler(ITaxObligationReadRepository taxObligationReadRepository, IMapper mapper, ILogger<GetAllTaxObligationsQueryHandler> logger)
    {
        _taxObligationReadRepository = taxObligationReadRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IDataResult<List<GetAllTaxObligationsResponse>>> Handle(GetAllTaxObligationsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get All TaxObligations Query Handler");

        var taxObligations = await _taxObligationReadRepository.GetAllAsync();

        var mapperTaxObligations = _mapper.Map<List<GetAllTaxObligationsResponse>>(taxObligations);

        var result = new SuccessDataResult<List<GetAllTaxObligationsResponse>>(mapperTaxObligations, "Success");

        return result;
    }
}