using DespachoWorkspace.Management.Application.UseCase.Queries.Dtos;
using DespachoWorkspace.Management.Application.UseCase.Queries.GetTaxObligation;
using DespachoWorkspace.Management.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DespachoWorkspace.Management.WebApi.Endpoints
{
    public class TaxObligations : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)                
                .MapGet(GetTaxObligation);                                          
        }

        public Task<List<TaxObligationDto>> GetTaxObligation( [FromServices] ISender sender,  [FromBody] GetTaxObligationQuery query)
        {
            return sender.Send(query);
        }
    }
}