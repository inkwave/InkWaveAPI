using FluentValidation;
using Inkwave.Application.Features.Users.Commands.UpdateUserPhoto;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserPhotoCommandValidator : AbstractValidator<UpdateUserPhotoCommand>
    {

        public UpdateUserPhotoCommandValidator()
        {

            RuleFor(p => p.PhotoUrl)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        }
    }
}
