using DespachoWorkspace.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespachoWorkspace.Management.Infrastructure.Data.Configurations;

public class TaxObligationConfiguration : IEntityTypeConfiguration<TaxObligation>
{
  public void Configure(EntityTypeBuilder<TaxObligation> builder)
  {
    builder.Property(t => t.Name)
        .HasMaxLength(200)
        .IsRequired();
  }
}
