using ContpaqiNube.Despachos.Management.Application.Interfaces.Repositories.TaxObligations;
using ContpaqiNube.Despachos.Management.Domain.Entities;

namespace ContpaqiNube.Despachos.Management.Infrastructure.Data.Repositories.TaxObligations;

public class TaxObligationReadRepository: GenericReadRepository<TaxObligation>,ITaxObligationReadRepository
{
    public TaxObligationReadRepository(DespachoDbContext dbContext) : base(dbContext)
    {
    }
}