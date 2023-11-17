namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> CreatePaymentMethodAsync(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
        Task<List<PaymentMethod>> GetAllPaymentMethodsByUserId(Guid userId);
        Task<PaymentMethod> GetById(Guid id);
        Task UpdatePaymentMethod(Guid id, Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV);
    }
}
