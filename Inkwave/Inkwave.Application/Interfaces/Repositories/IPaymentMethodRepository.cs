using Inkwave.Domain.PaymentMethod;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {

        Task<PaymentMethod> CreatePaymentMethodAsync(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
        Task<PaymentMethod> GetById(Guid id);
        Task UpdatePaymentMethod(Guid id, Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
    }
}
