using Inkwave.Domain.Common;

namespace Inkwave.Domain;

public class PaymentMethod : BaseAuditableEntity
{
    private PaymentMethod() { }
    private PaymentMethod(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        CardName = cardName;
        CardNumber = cardNumber;
        CardMonth = cardMonth;
        CardYear = cardYear;
        CardCVV = cardCvv;
    }
    public Guid UserId { get; set; }
    public string CardName { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public string CardMonth { get; set; } = string.Empty;
    public string CardYear { get; set; } = string.Empty;
    public string CardCVV { get; set; } = string.Empty;
    public static PaymentMethod Create(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)
    {
        PaymentMethod paymentMethod = new PaymentMethod(userId, cardName, cardNumber, cardMonth, cardYear, cardCvv);
        return paymentMethod;
    }
    public PaymentMethod Update(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)
    {
        if (userId != this.UserId)
            return this;
        this.CardName = cardName;
        this.CardNumber = cardNumber;
        this.CardMonth = cardMonth;
        this.CardYear = cardYear;
        this.CardCVV = cardCvv;
        return this;
    }

}
