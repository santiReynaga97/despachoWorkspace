using DespachoWorkspace.Management.Application.Common.Interfaces.ITaxObligation;
using DespachoWorkspace.Management.Application.UseCase.Queries.Dtos;
using DespachoWorkspace.Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DespachoWorkspace.Management.Infrastructure.Services.TaxObligation.Repository
{
    public class TaxObligationRepository : ITaxObligationRepository
    {
        private readonly DespachoDbContext _context;

        public TaxObligationRepository(DespachoDbContext despachoDbContext)
        {
            _context = despachoDbContext;
        }

        public async Task<List<TaxObligationDto>> GetTaxObligations()
        {
            var taxObligations = await _context.TaxObligations
                .Select(t => new TaxObligationDto
                {
                    Id = t.TaxObligationId,
                    Name = t.Name,                                     
                }).ToListAsync();                

            return taxObligations;
        }
    }

}