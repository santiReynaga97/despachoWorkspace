using DespachoWorkspace.Management.Application.UseCase.Queries.Dtos;
using DespachoWorkspace.Management.Application.UseCase.Queries.GetTaxObligation;
using Microsoft.AspNetCore.Mvc;

namespace DespachoWorkspace.Management.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PruebaController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PruebaController> _logger;

    public PruebaController(IMediator mediator, Logger<PruebaController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        return "HOLA MUNDO";                
    }

    // [HttpGet(Name ="GetPrueba")]
    // public Task<List<TaxObligationDto>> Get()
    // {
    //     return 
    //     _logger.LogInformation("entro al controler prueba HOLAA PEPEPEP");
    //     return _mediator.Send(new GetTaxObligationQuery { PageNumber = 1, PageSize = 2 });
    // }

}