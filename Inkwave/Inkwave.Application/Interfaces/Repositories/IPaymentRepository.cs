namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {

        Task<Payment> CreatePaymentAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod);

    }
}
