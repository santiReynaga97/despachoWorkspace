using ContpaqiNube.Despachos.Management.Application.Common.Interfaces;
using ContpaqiNube.Despachos.Management.Api.Services;
using ContpaqiNube.Despachos.Management.Api.Infrastructure;
using ContpaqiNube.Despachos.Management.Api.Abstractions;
using ContpaqiNube.Despachos.Management.Api.Models;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddWebApiServices(this IServiceCollection services, WebApplicationBuilder builder)
  {    
    services.AddHttpContextAccessor();
     
    services.AddExceptionHandler<CustomExceptionHandler>();

    services.AddScoped<CustomSessionModel>();
    services.AddScoped<IEncryptionService, EncryptionService>();   
    services.AddScoped<ISessionService, SessionService>();
    

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
      c.TagActionsBy(ta => new List<string> { ta.ActionDescriptor.DisplayName! });
    });
    
    return services;
  }
}
