using MediatR;
namespace Inkwave.Domain.Common.Interfaces;

public interface IDomainEventDispatcher : INotification
{
    Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
}
