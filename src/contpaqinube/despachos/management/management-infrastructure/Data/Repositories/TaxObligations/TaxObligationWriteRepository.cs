
using ContpaqiNube.Despachos.Management.Application.Interfaces.Repositories.TaxObligations;
using ContpaqiNube.Despachos.Management.Domain.Entities;

namespace ContpaqiNube.Despachos.Management.Infrastructure.Data.Repositories.TaxObligations;

public class TaxObligationWriteRepository: GenericWriteRepository<TaxObligation>,ITaxObligationWriteRepository
{
    public TaxObligationWriteRepository(DespachoDbContext dbContext) : base(dbContext)
    {
    }
    
}