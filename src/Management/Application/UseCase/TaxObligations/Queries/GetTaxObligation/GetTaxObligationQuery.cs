using DespachoWorkspace.Management.Application.Common.Interfaces.ITaxObligation;
using DespachoWorkspace.Management.Application.UseCase.TaxObligations.Queries.Dtos;


namespace DespachoWorkspace.Management.Application.UseCase.Queries.GetTaxObligation;

public record GetTaxObligationQuery : IRequest<List<TaxObligationDto>>
{    
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTaxObligationQueryHandler : IRequestHandler<GetTaxObligationQuery, List<TaxObligationDto>>
{
    private readonly ITaxObligationRepository _repository;    
    private readonly ILogger<GetTaxObligationQueryHandler> _logger;

    public GetTaxObligationQueryHandler(ITaxObligationRepository repository, ILogger<GetTaxObligationQueryHandler> logger)
    {
        _repository = repository;        
        _logger = logger;
    }

    public async Task<List<TaxObligationDto>> Handle(GetTaxObligationQuery request, CancellationToken cancellationToken)
    {
        _logger.LogError("entro al handler HOLAA PEPEPEP");
       return  await _repository.GetTaxObligations();
    }
}
