namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Guid userId, string street, string city, string building, string apartment, string markingPlace);
        Task<List<Address>> GetAllAddressByUserId(Guid userId);
        Task<Address> GetById(Guid id);
        Task UpdateAddress(Guid id, Guid userId, string street, string city, string building, string apartment, string markingPlace);
        Task UpdateDefaultAddres(Guid id);
    }
}
