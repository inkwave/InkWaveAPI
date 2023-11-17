using FluentValidation;

namespace Inkwave.Application.Features.Address.Queries.GetAddressByUserId
{
    public class GetAddressByUserIdQueryValidator : AbstractValidator<GetAddressByUserIdQuery>
    {
        public GetAddressByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }


    }
}
