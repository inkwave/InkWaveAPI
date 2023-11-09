using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Commands.RemoveCart;

internal class RemoveCartCommandHandler : IRequestHandler<RemoveCartCommand, Result<Guid>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICartRepository CartRepository;

    public RemoveCartCommandHandler(IUnitOfWork unitOfWork, ICartRepository CartRepository)
    {
        this.unitOfWork = unitOfWork;
        this.CartRepository = CartRepository;
    }

    public async Task<Result<Guid>> Handle(RemoveCartCommand command, CancellationToken cancellationToken)
    {
        await CartRepository.RemoveItemCart(command.UserId, command.ItemId);
        var result = await unitOfWork.Save(cancellationToken);
        if (result > 0)
            return await Result<Guid>.SuccessAsync(command.UserId, "Removed Item From Cart.");
        else
            return await Result<Guid>.FailureAsync("error in the code");
    }



}

