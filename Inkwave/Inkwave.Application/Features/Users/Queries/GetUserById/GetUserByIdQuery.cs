using AutoMapper;
using AutoMapper.QueryableExtensions;

using Inkwave.Application.Extensions;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Common.Interfaces;
using Inkwave.Domain.Entities;
using Inkwave.Shared;
using MediatR;

using Microsoft.EntityFrameworkCore; 

namespace Inkwave.Application.Features.Users.Queries.GetUsersWithPagination
{
    public record GetUserByIdQuery : IRequest<Result<GetUserByIdDto>>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery()
        {

        }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetUserByIdDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<User>().GetByIdAsync(query.Id);
            var User = _mapper.Map<GetUserByIdDto>(entity);
            return await Result<GetUserByIdDto>.SuccessAsync(User);
        }
    }
}
