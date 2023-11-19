using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class Favourite : BaseEntity
{
    /// <summary>
    /// 3 in BaseEntity
    /// </summary>
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
}
