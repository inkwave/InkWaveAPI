using Inkwave.Domain.PaymentMethod;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        
        Task<PaymentMethod> CreatePaymentMethodAsync(string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
        Task<Domain.Entities.PaymentMethod> GetById(Guid id);
        Task Update(object paymentMethod);
        Task UpdatePaymentMethod(Guid id, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
        Task<PaymentMethod> UpdatePaymentMethodAsync(PaymentMethod paymentMethod);
    }
}
