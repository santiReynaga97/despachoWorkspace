using DespachoWorkspace.Management.Application.Common.Interfaces.ITaxObligation;
using DespachoWorkspace.Management.Application.UseCase.Queries.Dtos;


namespace DespachoWorkspace.Management.Application.UseCase.Queries.GetTaxObligation;

public record GetTaxObligationQuery : IRequest<List<TaxObligationDto>>
{    
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTaxObligationQueryHandler : IRequestHandler<GetTaxObligationQuery, List<TaxObligationDto>>
{
    private readonly ITaxObligationRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetTaxObligationQueryHandler> _logger;

    public GetTaxObligationQueryHandler(ITaxObligationRepository repository, IMapper mapper, ILogger<GetTaxObligationQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<TaxObligationDto>> Handle(GetTaxObligationQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("entro al handler HOLAA PEPEPEP");
       return  await _repository.GetTaxObligations();
    }
}
