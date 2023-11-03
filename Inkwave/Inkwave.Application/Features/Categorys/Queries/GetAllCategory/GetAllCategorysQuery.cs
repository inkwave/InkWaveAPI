using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Item;
using Inkwave.Shared;
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Categorys.Queries.GetCategorysWithPagination;

public record GetAllCategorysQuery : IRequest<Result<List<GetAllCategoryDto>>>;

internal class GetAllCategorysQueryHandler : IRequestHandler<GetAllCategorysQuery, Result<List<GetAllCategoryDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCategorysQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllCategoryDto>>> Handle(GetAllCategorysQuery query, CancellationToken cancellationToken)
    {
        var Categorys = await _unitOfWork.Repository<Category>().Entities
               .ProjectTo<GetAllCategoryDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

        return await Result<List<GetAllCategoryDto>>.SuccessAsync(Categorys);
    }
}
