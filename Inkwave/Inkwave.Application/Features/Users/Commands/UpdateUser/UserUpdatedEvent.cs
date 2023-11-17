using Inkwave.Domain.Common;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public class UserUpdatedEvent : BaseEvent
    {
        public User User { get; }

        public UserUpdatedEvent(User User)
        {
            this.User = User;
        }
    }
}
