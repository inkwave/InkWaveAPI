using Inkwave.Domain.Common;

namespace Inkwave.Domain.User
{
    internal class UserUpdatedEvent : BaseEvent
    {
        private User user;

        public UserUpdatedEvent(User user)
        {
            this.user = user;
        }
    }
}