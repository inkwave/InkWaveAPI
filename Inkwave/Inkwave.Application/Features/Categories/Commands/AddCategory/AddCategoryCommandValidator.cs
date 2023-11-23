using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Categories.Commands.AddCategory;


public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    private readonly IGenericRepository<Category> _genericRepository;

    public AddCategoryCommandValidator(IGenericRepository<Category> genericRepository)
    {
        _genericRepository = genericRepository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsFound).WithMessage("{PropertyName} should be not empty. NEVER!");
    }
    public async Task<bool> IsFound(string name, CancellationToken cancellationToken)
    {
        var result = await _genericRepository.Entities.AnyAsync(x => x.Name == name);
        return result != null;
    }
}