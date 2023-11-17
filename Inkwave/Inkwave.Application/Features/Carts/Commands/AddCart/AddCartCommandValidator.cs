using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
            .GreaterThan(0.1);

        RuleFor(x => x).MustAsync(IsNotExists).WithMessage("item exists.");


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
    private async Task<bool> IsNotExists(AddCartCommand command, CancellationToken cancellationToken)
    {
        return !await unitOfWork.Repository<Cart>().Entities.AnyAsync(x => x.UserId == command.UserId && x.ItemId == command.ItemId, cancellationToken);
    }

}
