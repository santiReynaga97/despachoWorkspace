using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.TaxRegimeFeature.Queries;
using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxRegimes;

namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries
{
    public class GetAllTaxRegimesQueryHandler : IRequestHandler<GetAllTaxRegimesQuery, IDataResult<List<GetAllTaxRegimesResponse>>>
    {
        private readonly ITaxRegimeReadRepository _taxRegimesReadRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllTaxRegimesQueryHandler> _logger;

        public GetAllTaxRegimesQueryHandler(ITaxRegimeReadRepository taxRegimeReadRepository, IMapper mapper, ILogger<GetAllTaxRegimesQueryHandler> logger)
        {
            _taxRegimesReadRepository = taxRegimeReadRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllTaxRegimesResponse>>> Handle(GetAllTaxRegimesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get All TaxRegimes Query Handler");

            var taxRegimes = await _taxRegimesReadRepository.GetAllAsync();

            var mapperTaxRegimes = _mapper.Map<List<GetAllTaxRegimesResponse>>(taxRegimes);

            var result = new SuccessDataResult<List<GetAllTaxRegimesResponse>>(mapperTaxRegimes, "Success");

            return result;
        }
    }
}