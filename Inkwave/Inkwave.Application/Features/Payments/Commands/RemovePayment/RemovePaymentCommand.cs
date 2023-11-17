namespace Inkwave.Application.Features.Payments.Commands.RemovePayment
{
    internal class RemovePaymentCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
    }
    
}
