using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    internal class AddressRepository : IAdressRepository
    {


        readonly IGenericRepository<Address> genericRepository;
        public AddressRepository(IGenericRepository<Address> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<Address> CreateAddressAsync(Guid userId, string street, string city, string building, string apartment, string markingPlace)
        {
            var model = Address.Create(userId, street, city, building, apartment, markingPlace);
            await genericRepository.AddAsync(model);
            return model;
        }

        public async Task<List<Address>> GetAllAddressByUserId(Guid userId)
        {
            return await genericRepository.Entities.Where(x => x.UserId == userId).ToListAsync();
        }

        public Task<Address> GetById(Guid id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAddress(Guid id, Guid userId, string street, string city, string building, string apartment, string markingPlace)
        {
            var model = await genericRepository.GetByIdAsync(id);
            model.Update(userId, street, city, building, apartment, markingPlace);
            await genericRepository.UpdateAsync(model);
        }

    }
}
