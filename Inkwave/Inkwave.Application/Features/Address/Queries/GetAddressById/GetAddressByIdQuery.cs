namespace Inkwave.Application.Features.Address.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<Result<GetAddressByIdDto>>
    {
        public Guid Id { get; set; }

    }

}
