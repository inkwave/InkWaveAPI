using FluentValidation;

namespace Inkwave.Application.Features.Items.Queries.GetItemsWithPagination;


public class GetItemsWithPaginationValidator : AbstractValidator<GetItemsWithPaginationQuery>
{
    public GetItemsWithPaginationValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize at least greater than or equal to 1.");
    }
}
