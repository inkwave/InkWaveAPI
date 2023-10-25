﻿using Inkwave.Application.Common.Mappings;
using Inkwave.Domain.Entities;

namespace Inkwave.Application.Features.Users.Queries.GetUsersWithPagination
{
    public class GetAllUsersDto : IMapFrom<User>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
     }
}