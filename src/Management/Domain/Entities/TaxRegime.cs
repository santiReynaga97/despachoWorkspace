

namespace DespachoWorkspace.Management.Domain.Entities
{
    public class TaxRegime : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsFisica { get; set; }
        public bool IsMoral { get; set; }
    }
}