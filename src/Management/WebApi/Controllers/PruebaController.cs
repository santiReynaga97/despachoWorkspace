
using DespachoWorkspace.Management.Application.UseCase.Queries.GetTaxObligation;
using DespachoWorkspace.Management.Application.UseCase.TaxObligations.Queries.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DespachoWorkspace.Management.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PruebaController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PruebaController> _logger;

    public PruebaController(IMediator mediator, ILogger<PruebaController>  logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaxObligationDto>>> Get()
    {
      _logger.LogInformation("entro al controler prueba HOLAA PEPEPEP");
      return await _mediator.Send(new GetTaxObligationQuery {PageNumber=2, PageSize=2});      
    }
}
