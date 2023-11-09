using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class OrderLine : BaseEntity
{
    [Required]
    public Guid OrderId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public double Net { get; set; }
}