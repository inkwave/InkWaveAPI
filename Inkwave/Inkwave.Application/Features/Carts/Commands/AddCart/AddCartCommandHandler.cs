using Inkwave.Application.Features.Carts.Commands.AddCart;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Carts.Features.Carts.Commands.AddCart;

internal class AddCartCommandHandler : IRequestHandler<AddCartCommand, Result<Guid>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICartRepository CartRepository;

    public AddCartCommandHandler(IUnitOfWork unitOfWork, ICartRepository CartRepository)
    {
        this.unitOfWork = unitOfWork;
        this.CartRepository = CartRepository;
    }

    public async Task<Result<Guid>> Handle(AddCartCommand command, CancellationToken cancellationToken)
    {
        var Cart = await CartRepository.AddItemCart(command.UserId, command.ItemId, command.Quantity);
        await unitOfWork.Save(cancellationToken);
        if (Cart != null)
            return await Result<Guid>.SuccessAsync(Cart.Id, "Add Cart.");
        else
            return await Result<Guid>.FailureAsync("error in the code");
    }
}