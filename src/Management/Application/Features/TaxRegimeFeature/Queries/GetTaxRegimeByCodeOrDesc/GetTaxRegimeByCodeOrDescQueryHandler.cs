using Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc;
using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxRegimes;


namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries.GetTaxRegimeByCodeOrDesc
{
    public class GetTaxRegimeByCodeOrDescQueryHandler : IRequestHandler<GetTaxRegimeByCodeOrDescQuery, IDataResult<List<GetTaxRegimeByCodeOrDescResponse>>>
    {
        private readonly ITaxRegimeReadRepository _taxRegimesReadRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTaxRegimeByCodeOrDescQueryHandler> _logger;

        public GetTaxRegimeByCodeOrDescQueryHandler(ITaxRegimeReadRepository taxRegimeReadRepository, IMapper mapper, ILogger<GetTaxRegimeByCodeOrDescQueryHandler> logger)
        {
            _taxRegimesReadRepository = taxRegimeReadRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IDataResult<List<GetTaxRegimeByCodeOrDescResponse>>> Handle(GetTaxRegimeByCodeOrDescQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetTaxRegimeByCodeOrDescQuery");

            var taxRegimes = await _taxRegimesReadRepository.GetByCodeOrDescriptionAsync(request.Code, request.Description);

            if (taxRegimes == null || taxRegimes.Count == 0)
            {
                _logger.LogInformation($"No tax regimes found with code: {request.Code} or description: {request.Description}");
                return new ErrorDataResult<List<GetTaxRegimeByCodeOrDescResponse>>($"No tax regimes found with code: {request.Code} or description: {request.Description}");
            }

            var response = _mapper.Map<List<GetTaxRegimeByCodeOrDescResponse>>(taxRegimes);
            return new SuccessDataResult<List<GetTaxRegimeByCodeOrDescResponse>>(response, "Success");
        }
    }
}
