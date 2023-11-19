namespace Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodByUserId
{
    public class GetPaymentMethodByUserIdQuery : IRequest<Result<List<GetPaymentMethodByUserIdDto>>>
    {
        public Guid UserId { get; set; }

    }

}
