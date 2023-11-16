namespace Inkwave.Application.Features.PaymentMethod.Queries.GetPaymentMethodById
{
    public class GetPaymentMethodByIdQuery : IRequest<Result<GetPaymentMethodByIdDto>>
    {
        public Guid Id { get; set; }
        
    }
   
}
