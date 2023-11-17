namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {

        Task<User?> GetUserByEmail(string email);

    }
}
