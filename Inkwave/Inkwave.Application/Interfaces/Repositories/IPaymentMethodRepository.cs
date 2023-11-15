using Inkwave.Domain.PaymentMethod;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        
        Task<PaymentMethod> CreatePaymentMethodAsync(string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
    }
}
