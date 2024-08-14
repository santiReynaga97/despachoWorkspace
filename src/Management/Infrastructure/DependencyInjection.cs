using DespachoWorkspace.Management.Infrastructure;
using DespachoWorkspace.Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<DespachoDbContext>((sp,options) =>
    {
      //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
      options.UseNpgsql(connectionString);
    });
     
    services.AddManagementBackendScopedServices();
    services.AddSingleton(TimeProvider.System);


    return services;
  }
}
