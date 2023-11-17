using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _DbContext = dbContext;
    }

    public readonly ApplicationDbContext _DbContext;

    public async Task<User?> GetUserByEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return null;
        return await Entities.SingleOrDefaultAsync(x => x.Email == email.Trim());
    }
}
