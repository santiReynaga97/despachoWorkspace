
namespace DespachoWorkspace.Management.Domain.Entities
{
  public class TaxObligation : BaseEntity
  {
    public string? Code { get; set; }

    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Name { get; set; } = null!;

    public static TaxObligation CreateTaxObligation(string? code, string description, bool isActive, string name)
    {
      return new TaxObligation
      {
        Id = Guid.NewGuid(),
        Code = code,
        Description = description,
        IsActive = isActive,
        Name = name,
        CreatedAt = DateTime.UtcNow
      };
    }
  }

}
