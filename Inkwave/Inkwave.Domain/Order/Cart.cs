using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class Cart : BaseEntity
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Quantity { get; set; }
}
