namespace Inkwave.Application.Features.Address.Commands.AddAddress
{
    public class AddAddressCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }

        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;

        public string MarkingPlace { get; set; } = string.Empty;

    }
}
