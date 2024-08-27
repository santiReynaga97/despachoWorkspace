using DespachoWorkspace.Management.Domain.Entities;

namespace DespachoWorkspace.Management.Application.Interfaces.Repositories.TaxRegimes;

public interface ITaxRegimeReadRepository : IGenericReadRepository<TaxRegime>
{
     Task<List<TaxRegime>> GetByCodeOrDescriptionAsync(string code, string description);
}