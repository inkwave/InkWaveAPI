using Inkwave.Domain.Common;
using Inkwave.Domain.User;

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
