using ContpaqiNube.Despachos.Management.Application.Common.Models.Results;
using ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;
using ContpaqiNube.Despachos.Management.Application.Interfaces.Repositories.TaxObligations;

namespace ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetTaxObligationById;

public class GetTaxObligationByIdQueryHandler : IRequestHandler<GetTaxObligationByIdQuery, IDataResult<GetAllTaxObligationsResponse>>
{
    private readonly ITaxObligationReadRepository _taxObligationReadRepository;
    private readonly IMapper _mapper;

    private readonly ILogger<GetTaxObligationByIdQueryHandler> _logger;

    public GetTaxObligationByIdQueryHandler(ITaxObligationReadRepository taxObligationReadRepository, IMapper mapper, ILogger<GetTaxObligationByIdQueryHandler> logger)
    {
        _taxObligationReadRepository = taxObligationReadRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IDataResult<GetAllTaxObligationsResponse>> Handle(GetTaxObligationByIdQuery request, CancellationToken cancellationToken)
    {

        _logger.LogInformation("Get TaxObligation By Id Query Handler");
        var taxObligation = await _taxObligationReadRepository.GetByIdAsync(request.TaxObligationId,true);

        if (taxObligation is null)
        {
              _logger.LogInformation($"taxObligation cannot found with id: {request.TaxObligationId}");
            return new ErrorDataResult<GetAllTaxObligationsResponse>($"taxObligation cannot found with id: {request.TaxObligationId}");
        }

        var mappedtaxObligation = _mapper.Map<GetAllTaxObligationsResponse>(taxObligation);
        var result = new SuccessDataResult<GetAllTaxObligationsResponse>(mappedtaxObligation, "Success");

        return result;
    }
}