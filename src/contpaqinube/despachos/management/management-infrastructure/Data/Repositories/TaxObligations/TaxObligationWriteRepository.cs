
using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxObligations;
using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Infrastructure.Data.Repositories.TaxObligations;

public class TaxObligationWriteRepository: GenericWriteRepository<TaxObligation>,ITaxObligationWriteRepository
{
    public TaxObligationWriteRepository(DespachoDbContext dbContext) : base(dbContext)
    {
    }
    
}