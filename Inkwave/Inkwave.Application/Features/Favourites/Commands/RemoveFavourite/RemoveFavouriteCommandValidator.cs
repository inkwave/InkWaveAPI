﻿using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Favourites.Commands.RemoveFavourite;

public class RemoveFavouriteCommandValidator : AbstractValidator<RemoveFavouriteCommand>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveFavouriteCommandValidator(IUnitOfWork unitOfWork)
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
        RuleFor(x => x)
            .MustAsync(IsExistsItem).WithMessage("item not exists.");

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
    private async Task<bool> IsExistsItem(RemoveFavouriteCommand command, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Favourite>().Entities.AnyAsync(x => x.UserId == command.UserId && x.ItemId == command.ItemId, cancellationToken);
    }
}

