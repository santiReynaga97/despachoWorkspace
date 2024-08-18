using DespachoWorkspace.Management.Infrastructure;
using DespachoWorkspace.Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {    
    services.AddPersistenceServices(configuration);
    services.AddSingleton(TimeProvider.System);

    return services;
  }
}
