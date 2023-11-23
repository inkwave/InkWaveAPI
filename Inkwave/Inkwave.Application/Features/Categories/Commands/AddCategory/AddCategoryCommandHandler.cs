using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Categories.Commands.AddCategory;

internal class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Result<Category>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Category> _genericRepository;
    public AddCategoryCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository)
    {
        _unitOfWork = unitOfWork;
        _genericRepository = genericRepository;
    }
    public async Task<Result<Category>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = Category.Create(request.Name, request.Description, request.Image, request.CategoryParentId);
        await _genericRepository.AddAsync(category);
        var result = await _unitOfWork.Save(cancellationToken);
        if (result > 0)
            return Result<Category>.Success(category);
        return Result<Category>.Failure();
    }
}
