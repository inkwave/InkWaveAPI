using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain.Entities;

public class User : BaseAuditableEntity
{
    [Required]
    public required string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    [Required]
    public required string Email { get; set; } = string.Empty;
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    public string RememberToken { get; set; } = string.Empty;
    public string status { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
}
public class Claims : BaseEntity
{
    public string Description { get; set; } = string.Empty;
}
