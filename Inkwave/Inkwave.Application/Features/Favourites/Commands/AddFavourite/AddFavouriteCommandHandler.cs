using Inkwave.Application.Features.Favourites.Commands.AddFavourite;
using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Favourites.Features.Favourites.Commands.AddFavourite
{
    internal class AddFavouriteCommandHandler : IRequestHandler<AddFavouriteCommand, Result<Guid>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFavouriteRepository favouriteRepository;

        public AddFavouriteCommandHandler(IUnitOfWork unitOfWork, IFavouriteRepository favouriteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.favouriteRepository = favouriteRepository;
        }

        public async Task<Result<Guid>> Handle(AddFavouriteCommand command, CancellationToken cancellationToken)
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