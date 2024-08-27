using DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxRegimes;
using DespachoWorkspace.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DespachoWorkspace.Management.Infrastructure.Data.Repositories.TaxRegimes;

public class TaxRegimeReadRepository : GenericReadRepository<TaxRegime>, ITaxRegimeReadRepository
{
  public TaxRegimeReadRepository(DespachoDbContext dbContext) : base(dbContext)
  {
  }

  public async Task<List<TaxRegime>> GetByCodeOrDescriptionAsync(string codeOrDescription)
  {
    return await dbContext.Set<TaxRegime>()
        .Where(tr => tr.Code == codeOrDescription || tr.Description == codeOrDescription)
        .ToListAsync();
  }
}