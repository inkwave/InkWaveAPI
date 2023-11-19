namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {

        Task<Payment> CreatePaymentAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod);
        Task<Payment> RemovePaymentAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod);
        Task<Payment> GetPaymentByIdAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod);
        Task<Guid> GetPaymentByIdAsync(Guid userId, Guid itemId);
        Task RemovePaymentAsync(Guid payment);
    }
}
