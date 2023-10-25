namespace Inkwave.Domain.Common.Interfaces;

public interface IAuditableEntity : IEntity
{
    Guid? CreatedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    Guid? UpdatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
}
