using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Item;
using Inkwave.Domain.User;
namespace Inkwave.Application.Features.Carts.Commands.AddCart;

public class AddCartCommandValidator : AbstractValidator<AddCartCommand>
{
    private readonly IUnitOfWork unitOfWork;

    public AddCartCommandValidator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsExistsAndActiveUser).WithMessage("{PropertyName} not exists or not active.");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsExistsItem).WithMessage("{PropertyName} not exists.");

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .NotNull()
            .LessThan(0.1);

    }
    private async Task<bool> IsExistsAndActiveUser(Guid userId, CancellationToken cancellationToken)
    {
        var userObject = await unitOfWork.Repository<User>().GetByIdAsync(userId);
        if (userObject == null)
            return false;

        return userObject.Active && !userObject.IsDeleted;
    }
    private async Task<bool> IsExistsItem(Guid itemId, CancellationToken cancellationToken)
    {
        var userObject = await unitOfWork.Repository<Item>().GetByIdAsync(itemId);
        if (userObject == null)
            return false;

        return !userObject.IsDeleted;
    }

}
