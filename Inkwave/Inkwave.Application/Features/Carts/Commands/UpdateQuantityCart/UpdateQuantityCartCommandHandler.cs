using Inkwave.Application.Features.Carts.Commands.UpdateQuantityCart;
using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Carts.Features.Carts.Commands.UpdateQuantityCart;

internal class UpdateQuantityCartCommandHandler : IRequestHandler<UpdateQuantityCartCommand, Result<Cart>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICartRepository CartRepository;

    public UpdateQuantityCartCommandHandler(IUnitOfWork unitOfWork, ICartRepository CartRepository)
    {
        this.unitOfWork = unitOfWork;
        this.CartRepository = CartRepository;
    }

    public async Task<Result<Cart>> Handle(UpdateQuantityCartCommand command, CancellationToken cancellationToken)
    {
        var Cart = await CartRepository.UpdateQuantityAsync(command.UserId, command.ItemId, command.Quantity);
        var result = await unitOfWork.Save(cancellationToken);
        if (result > 0)
            return await Result<Cart>.SuccessAsync(Cart, "Updated Cart.");
        else
            return await Result<Cart>.FailureAsync("error in the code");
    }
}