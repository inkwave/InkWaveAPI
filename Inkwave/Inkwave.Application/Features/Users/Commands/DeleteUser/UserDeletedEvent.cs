using Inkwave.Domain.Common;

namespace Inkwave.Application.Features.Users.Commands.DeleteUser
{
    public class UserDeletedEvent : BaseEvent
    {
        public User User { get; }

        public UserDeletedEvent(User User)
        {
            this.User = User;
        }
    }
}
