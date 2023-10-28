namespace Inkwave.Domain.Common.Interfaces;


public interface IEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
}
