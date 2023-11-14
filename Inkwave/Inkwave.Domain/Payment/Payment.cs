using Inkwave.Domain.Common;

namespace Inkwave.Domain.Payment;

public class Payment : BaseAuditableEntity
{
    private Payment()
    {
        Id = Guid.NewGuid();
    }
    public PaymentStatus PaymentStatus { get; set; }
    public double PaymentValue { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentType { get; set; } = "";
    public string PaymentMethod { get; set; } = "";
    public static Payment Create(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
    {
        Payment payment = new Payment();
        payment.Id = Guid.NewGuid();
        payment.PaymentStatus = PaymentStatus.NotPaid;
        payment.PaymentValue = paymentValue;
        payment.PaymentDate = DateTime.Now;
        payment.PaymentType = paymentType;
        payment.PaymentMethod = paymentMethod;
        return payment;
    }
}

