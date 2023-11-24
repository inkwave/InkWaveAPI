namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Guid userId, string name, string country, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace);
        Task<List<Address>> GetAllAddressByUserId(Guid userId);
        Task<Address> GetById(Guid id);
        Task UpdateAddress(Guid id, Guid userId, string name, string country, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace);
        Task UpdateDefaultAddres(Guid id, Guid userId);
    }
}
