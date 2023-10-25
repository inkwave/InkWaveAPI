using FluentValidation;

namespace Inkwave.Application.Features.Users.Queries.GetUsersWithPagination;

public class GetUsersWithPaginationValidator : AbstractValidator<GetUsersWithPaginationQuery>
{
    public GetUsersWithPaginationValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize at least greater than or equal to 1.");
    }
}
