using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Addresses.Commands.SetDefaultAddress;
internal class SetDefaultAddressCommandValidator : AbstractValidator<SetDefaultAddressCommand>
{
    private readonly IUnitOfWork unitOfWork;

    public SetDefaultAddressCommandValidator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsExistsAndActiveUser).WithMessage("{PropertyName} not exists or not active.");

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MustAsync(IsNotExists).WithMessage("address not exists or already default");
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
        return userObject != null && !userObject.IsDefault;
    }
}
