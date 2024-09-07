using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxObligations;
using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Infrastructure.Data.Repositories.TaxObligations;

public class TaxObligationReadRepository: GenericReadRepository<TaxObligation>,ITaxObligationReadRepository
{
    public TaxObligationReadRepository(DespachoDbContext dbContext) : base(dbContext)
    {
    }
}