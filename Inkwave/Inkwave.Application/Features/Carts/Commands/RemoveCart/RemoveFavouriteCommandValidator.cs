using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Carts.Commands.RemoveCart;

public class RemoveCartCommandValidator : AbstractValidator<RemoveCartCommand>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveCartCommandValidator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;


        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x)
            .MustAsync(IsExistsItem).WithMessage("{PropertyName} not exists.");

    }
    private async Task<bool> IsExistsItem(RemoveCartCommand command, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Cart>().Entities.AnyAsync(x => x.UserId == command.UserId && x.ItemId == command.ItemId, cancellationToken);
    }

}

