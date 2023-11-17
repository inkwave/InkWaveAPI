namespace Inkwave.Application.Features.Address.Commands.UpdateAddress;
public class UpdateAddressCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Street { get; set; } = "";

    public string City { get; set; } = "";

    public string Building { get; set; } = "";
    public string Apartment { get; set; } = "";

    public string MarkingPlace { get; set; } = "";
}

