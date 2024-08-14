using DespachoWorkspace.Management.Application.Common.Interfaces.ITaxObligation;
using DespachoWorkspace.Management.Application.UseCase.Queries.Dtos;
using MediatR;
using AutoMapper;

namespace DespachoWorkspace.Management.Application.UseCase.Queries.GetTaxObligation;

public record GetTaxObligationQuery : IRequest<List<TaxObligationDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTaxObligationQueryHandler : IRequestHandler<GetTaxObligationQuery, List<TaxObligationDto>>
{
    private readonly ITaxObligationRepository _repository;
    private readonly IMapper _mapper;

    public GetTaxObligationQueryHandler(ITaxObligationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TaxObligationDto>> Handle(GetTaxObligationQuery request, CancellationToken cancellationToken)
    {
       return  await _repository.GetTaxObligations();
    }
}
