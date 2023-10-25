using Inkwave.Domain.Common;
using Inkwave.Domain.Entities;

namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    public class UserCreatedEvent : BaseEvent
    {
        public User User { get; }

        public UserCreatedEvent(User User)
        {
            User = User;
        }
    }
}
