
namespace DespachoWorkspace.Management.Domain.Entities
{
  public class TaxRegime : BaseEntity
  {
        public Guid TaxRegimeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int PersonType { get; set; }
  }

}