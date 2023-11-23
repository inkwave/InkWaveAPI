using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Categories.Commands.UpdateCategory;


public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly IGenericRepository<Category> _genericRepository;

    public UpdateCategoryCommandValidator(IGenericRepository<Category> genericRepository)
    {
        _genericRepository = genericRepository;

        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsFound).WithMessage("{PropertyName} should be not empty. NEVER!");
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x)
           .MustAsync(IsNotDuplicate)
           .WithMessage("wrong Zip County");
    }
    public async Task<bool> IsFound(Guid id, CancellationToken cancellationToken)
    {
        var result = await _genericRepository.GetByIdAsync(id);
        return result != null;
    }
    public async Task<bool> IsNotDuplicate(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await _genericRepository.Entities.AnyAsync(x => x.Name == command.Name && x.Id != command.Id);
        return result != null;
    }
}