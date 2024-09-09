using ContpaqiNube.Despachos.Management.Api.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddWebApiServices(this IServiceCollection services, WebApplicationBuilder builder)
  {    
    services.AddHttpContextAccessor();         
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
      c.TagActionsBy(ta => new List<string> { ta.ActionDescriptor.DisplayName! });
    });
    
    return services;
  }
}