using DespachoWorkspace.Management.Application.UseCase.Queries.Dtos;

namespace DespachoWorkspace.Management.Application.Common.Interfaces.ITaxObligation
{
    public interface ITaxObligationRepository : IScopedService
    {
        public Task<List<TaxObligationDto>> GetTaxObligations();        
    }
}