using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.PaymentMethod;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    internal class PaymentMethodRepository : IPaymentMethodRepository
    {


        readonly IGenericRepository<PaymentMethod> genericRepository;
        public PaymentMethodRepository(IGenericRepository<PaymentMethod> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<PaymentMethod> CreatePaymentMethodAsync(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV)
        {
            var model = PaymentMethod.Create(userId, cardName, cardNumber, cardMonth, cardYear, cardCVV);
            await genericRepository.AddAsync(model);
            return model;

        }

        public Task<PaymentMethod> GetById(Guid id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public async Task UpdatePaymentMethod(Guid id, Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV)
        {
            var model = await genericRepository.GetByIdAsync(id);
            model.Update(userId, cardName, cardNumber, cardMonth, cardYear, cardCVV);
            await genericRepository.UpdateAsync(model);
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethodsByUserId(Guid userId)
        {
            return await genericRepository.Entities.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodById(Guid id)
        {
            return await genericRepository.GetByIdAsync(id);
        }
    }
}
