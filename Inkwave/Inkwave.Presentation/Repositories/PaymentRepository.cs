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

        public Task<Payment> GetPaymentByIdAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
        {
            var payment = Payment.Create(orderId, paymentValue, paymentType, paymentMethod);
            return Task.FromResult(payment);
        }

        public Task<Payment> RemovePaymentAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
        {
            var payment = Payment.Create(orderId, paymentValue, paymentType, paymentMethod);
            return Task.FromResult(payment);
        }

        public Task<IEnumerable<Payment>> GetAllPaymentsAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
        {
            var payment = Payment.Create(orderId, paymentValue, paymentType, paymentMethod);
            return Task.FromResult(new List<Payment> { payment }.AsEnumerable());
        }



    }
}
