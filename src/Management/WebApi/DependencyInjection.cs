using DespachoWorkspace.Management.Application.Common.Interfaces;
using DespachoWorkspace.Management.WebApi.Services;
using DespachoWorkspace.Management.WebApi.Infrastructure;
using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Models;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddWebApiServices(this IServiceCollection services, WebApplicationBuilder builder)
  {    
    services.AddHttpContextAccessor();
     
    services.AddExceptionHandler<CustomExceptionHandler>();

    services.AddScoped<CustomSessionModel>();
    services.AddScoped<ISessionService, SessionService>();
    services.AddScoped<IEncryptionService, EncryptionService>();   

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
      c.TagActionsBy(ta => new List<string> { ta.ActionDescriptor.DisplayName! });
    });
    
    return services;
  }
}
