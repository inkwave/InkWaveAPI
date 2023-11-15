using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public PaymentRepository() { }

        public Task<Payment> CreatePaymentAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
        {
            var payment = Payment.Create(orderId, paymentValue, paymentType, paymentMethod);
            return Task.FromResult(payment);

        }
    }
}
