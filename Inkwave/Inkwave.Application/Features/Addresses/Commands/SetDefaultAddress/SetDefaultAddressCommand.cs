namespace Inkwave.Application.Features.Addresses.Commands.SetDefaultAddress;
public class SetDefaultAddressCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}

