using Inkwave.Application.Common.Mappings;
using Inkwave.Domain.User;

namespace Inkwave.Application.Features.Users.Queries.GetUsersWithPagination;

public class GetUsersWithPaginationDto : IMapFrom<User>
{
    public Guid Id { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
}
