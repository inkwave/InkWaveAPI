using AutoMapper.QueryableExtensions;
using Inkwave.Application.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Categorys.Queries.GetCategorysWithPagination;

public record GetAllCategoriesQuery : IRequest<Result<List<GetAllCategoriesDto>>>;

internal class GetAllCategorysQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<GetAllCategoriesDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCategorysQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllCategoriesDto>>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        var Categorys = await _unitOfWork.Repository<Category>().Entities
               .ProjectTo<GetAllCategoriesDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

        return await Result<List<GetAllCategoriesDto>>.SuccessAsync(Categorys);
    }
}
