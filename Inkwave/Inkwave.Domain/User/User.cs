using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain.User;

public class User : BaseAuditableEntity
{
    private User()
    {
        Id = Guid.NewGuid();
    }
    [Required]
    public required string FirstName { get; set; } = string.Empty;
    [Required]
    public required string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public required string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    public string RememberToken { get; set; } = string.Empty;
    public string status { get; set; } = "Customer";
    public string PhotoUrl { get; set; } = string.Empty;
    public string ActiveCode { get; set; } = string.Empty;
    public bool Active { get; set; } = false;

    public static User CreateUser(string fname, string lname, string email, string phone, string gender, byte[] passwordHash, byte[] passwordSalt)
    {
        User user = new User()
        {
            FirstName = fname,
            LastName = lname,
            Email = email,
            Phone = phone,
            Gender = gender,
            passwordHash = passwordHash,
            passwordSalt = passwordSalt
        };
        user.ActiveCode = System.Security.Cryptography.RandomNumberGenerator.GetInt32(0, 1000000).ToString("D6");
        user.AddDomainEvent(new CreatedUserEvent(user));
        return user;
    }
    public User UpdateUser(string fname, string lname, string email, string phone, string gender)
    {
        this.FirstName = fname;
        this.LastName = lname;
        this.Email = email;
        this.Phone = phone;
        this.Gender = gender;
        this.AddDomainEvent(new UserUpdatedEvent(this));
        return this;
    }
    public User UpdatePhoto(string photoUrl)
    {
        this.PhotoUrl = photoUrl;
        return this;
    }

}
public class Claims : BaseEntity
{
    public string Description { get; set; } = string.Empty;
}
