using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Favourites.Commands.RemoveFavourite
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
            await favouriteRepository.RemoveItemFavourite(command.UserId, command.ItemId);
            var result = await unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<Guid>.SuccessAsync(command.UserId, "Removed Favourite.");
            else
                return await Result<Guid>.FailureAsync("error in the code");
        }



    }
}

