using DespachoWorkspace.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespachoWorkspace.Management.Infrastructure.Data.Configurations;

public class TaxRegimeConfiguration : IEntityTypeConfiguration<TaxRegime>
{
  public void Configure(EntityTypeBuilder<TaxRegime> builder)
  {
    builder.Property(t => t.Description)
        .HasMaxLength(200)
        .IsRequired();

    builder.HasKey(t => t.Id);
  }
}