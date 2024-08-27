using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxRegimes;
using DespachoWorkspace.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DespachoWorkspace.Management.Infrastructure.Data.Repositories.TaxRegimes;

public class TaxRegimeReadRepository : GenericReadRepository<TaxRegime>, ITaxRegimeReadRepository
{
    public TaxRegimeReadRepository(DespachoDbContext dbContext) : base(dbContext)
    {
    }

      public async Task<List<TaxRegime>> GetByCodeOrDescriptionAsync(string code, string description)
        {
            return await dbContext.Set<TaxRegime>()
                .Where(tr => tr.Code == code || tr.Description == description)
                .ToListAsync();
        }
}