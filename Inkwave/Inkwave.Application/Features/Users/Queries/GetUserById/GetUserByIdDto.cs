using Inkwave.Application.Common.Mappings;
using Inkwave.Domain.User;

namespace Inkwave.Application.Features.Users.Queries.GetUsersWithPagination;

public class GetUserByIdDto : IMapFrom<User>
{
    public Guid Id { get; init; }
    public string Name { get; init; } 
}
