using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxObligations;
using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;
public class CreateTaxObligationCommandHandler : IRequestHandler<CreateTaxObligationCommand, IDataResult<CreateTaxObligationResponse>>
{

    private readonly ITaxObligationWriteRepository _taxObligationWriteRepository;
    
    private readonly IMapper _mapper;

    public CreateTaxObligationCommandHandler(ITaxObligationWriteRepository taxObligationWriteRepository, IMapper mapper)
    {
        _taxObligationWriteRepository = taxObligationWriteRepository;        
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateTaxObligationResponse>> Handle(CreateTaxObligationCommand request, CancellationToken cancellationToken)
    {
        var taxObligation = TaxObligation.CreateTaxObligation(request.Code, request.Description, request.IsActive, request.Name);

        //var author = await _authorReadRepository.GetByIdAsync(blog.AuthorId);

        // if (author is null)
        // {
        //     return new ErrorDataResult<CreateTaxObligationResponse>($"Author cannot found with id: {request.AuthorId}");
        // }

        await _taxObligationWriteRepository.AddAsync(taxObligation);
        await _taxObligationWriteRepository.SaveChangesAsync();

        //taxObligation.SetOwner(author);

        var addedTaxObligation = _mapper.Map<CreateTaxObligationResponse>(taxObligation);

        var result = new SuccessDataResult<CreateTaxObligationResponse>(addedTaxObligation, "Success");

        return result;
    }
}