using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    internal class AddressRepository : IAddressRepository
    {


        readonly IGenericRepository<Address> genericRepository;
        public AddressRepository(IGenericRepository<Address> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<Address> CreateAddressAsync(Guid userId, string name, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace)
        {
            var model = Address.Create(userId, name, governorate, street, city, district, building, zipCode, apartment, markingPlace);
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

        public async Task UpdateAddress(Guid id, Guid userId, string name, string governorate, string street, string city, string district, string building, string zipCode, string apartment, string markingPlace)
        {
            var model = await genericRepository.GetByIdAsync(id);
            model.Update(userId, name, governorate, street, city, district, building, zipCode, apartment, markingPlace);
            await genericRepository.UpdateAsync(model);
        }

        public async Task UpdateDefaultAddres(Guid id, Guid userId)
        {
            var model = await genericRepository.GetByIdAsync(id);
            if (model.UserId != userId)
                return;
            var other = await GetAllAddressByUserId(userId);
            model.SetDefaultAddres(other);
            other.ForEach(async x => await genericRepository.UpdateAsync(x));
            await genericRepository.UpdateAsync(model);
        }
    }
}
