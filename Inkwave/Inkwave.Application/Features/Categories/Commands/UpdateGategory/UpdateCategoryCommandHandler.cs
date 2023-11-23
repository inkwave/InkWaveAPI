using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Categories.Commands.UpdateCategory;

internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Category>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Category> _genericRepository;
    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository)
    {
        _unitOfWork = unitOfWork;
        _genericRepository = genericRepository;
    }
    public async Task<Result<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _genericRepository.GetByIdAsync(request.Id);
        category.Update(request.Name, request.Description, request.Image, request.CategoryParentId);
        await _genericRepository.UpdateAsync(category);
        var result = await _unitOfWork.Save(cancellationToken);
        if (result > 0)
            return Result<Category>.Success(category);
        return Result<Category>.Failure();
    }
}
