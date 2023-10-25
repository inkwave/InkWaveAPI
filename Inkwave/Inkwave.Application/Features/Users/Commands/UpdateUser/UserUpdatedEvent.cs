using Inkwave.Domain.Common;
using Inkwave.Domain.Entities;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public class UserUpdatedEvent : BaseEvent
    {
        public User User { get; }

        public UserUpdatedEvent(User User)
        {
            User = User;
        }
    }
}
