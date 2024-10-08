using ContpaqiNube.Despachos.Management.Application.Interfaces.Repositories.TaxObligations;
using ContpaqiNube.Despachos.Management.Infrastructure.Data;
using ContpaqiNube.Despachos.Management.Infrastructure.Data.Repositories.TaxObligations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContpaqiNube.Despachos.Management.Infrastructure;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DespachoDbContext>((sp, options) =>
        {
            //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });

        services.AddTransient<ITaxObligationReadRepository, TaxObligationReadRepository>();
        services.AddTransient<ITaxObligationWriteRepository, TaxObligationWriteRepository>();

        return services;
    }

}