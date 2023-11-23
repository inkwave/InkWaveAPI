using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Addresses.Commands.UpdateAddress
{
    internal class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {

        private readonly IUnitOfWork unitOfWork;

        public UpdateAddressCommandValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .MustAsync(IsExistsAndActiveUser).WithMessage("{PropertyName} not exists or not active.");

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsNotExists).WithMessage("{PropertyName} not exists or not active.");


            RuleFor(p => p.Street)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Apartment)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Building)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MarkingPlace)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
        private async Task<bool> IsExistsAndActiveUser(Guid userId, CancellationToken cancellationToken)
        {
            var userObject = await unitOfWork.Repository<User>().GetByIdAsync(userId);
            if (userObject == null)
                return false;

            return userObject.Active && !userObject.IsDeleted;
        }
        private async Task<bool> IsNotExists(Guid id, CancellationToken cancellationToken)
        {
            var userObject = await unitOfWork.Repository<Address>().GetByIdAsync(id);
            return userObject != null;
        }


    }

}
