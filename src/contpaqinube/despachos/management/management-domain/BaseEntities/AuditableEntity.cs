namespace ContpaqiNube.Despachos.Management.Domain.BaseEntities;

public class AuditableEntity : BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid DeletedBy { get; set; }
    public bool Deleted { get; set; }
    public Guid InstanceId { get; set; }
}