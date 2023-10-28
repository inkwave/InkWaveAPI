namespace Inkwave.Domain.Authentication;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevorked { get; set; }

    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime ExpiryDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
}
