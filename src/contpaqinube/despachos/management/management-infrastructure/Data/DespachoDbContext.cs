using ContpaqiNube.Despachos.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContpaqiNube.Despachos.Management.Infrastructure.Data;

public class DespachoDbContext : DbContext
{
    public DespachoDbContext(DbContextOptions<DespachoDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }
    public DbSet<TaxObligation> TaxObligations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {        
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}