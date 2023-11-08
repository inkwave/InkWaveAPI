﻿using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Favourites.Commands.AddFavourite
{
    public record RemoveFavouriteCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
    }
}