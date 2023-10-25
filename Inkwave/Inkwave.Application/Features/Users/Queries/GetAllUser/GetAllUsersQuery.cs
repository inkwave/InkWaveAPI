using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Entities;
using Inkwave.Shared;
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Queries.GetUsersWithPagination;

public record GetAllUsersQuery : IRequest<Result<List<GetAllUsersDto>>>;

internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllUsersDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    { 
        var Users = await _unitOfWork.Repository<User>().Entities
               .ProjectTo<GetAllUsersDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

        return await Result<List<GetAllUsersDto>>.SuccessAsync(Users);
    }
}
