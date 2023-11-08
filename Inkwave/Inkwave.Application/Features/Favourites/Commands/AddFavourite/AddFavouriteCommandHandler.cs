﻿using Inkwave.Application.Features.Favourites.Commands.AddFavourite;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Favourites.Features.Favourites.Commands.AddFavourite
{
    internal class RemoveFavouriteCommandHandler : IRequestHandler<RemoveFavouriteCommand, Result<Guid>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFavouriteRepository favouriteRepository;

        public RemoveFavouriteCommandHandler(IUnitOfWork unitOfWork, IFavouriteRepository favouriteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.favouriteRepository = favouriteRepository;
        }

        public async Task<Result<Guid>> Handle(RemoveFavouriteCommand command, CancellationToken cancellationToken)
        {
            var favourite = await favouriteRepository.AddItemFavourite(command.UserId, command.ItemId);
            await unitOfWork.Save(cancellationToken);
            if (favourite != null)
                return await Result<Guid>.SuccessAsync(favourite.Id, "Add Favourite.");
            else
                return await Result<Guid>.FailureAsync("error in the code");
        }
    }
}