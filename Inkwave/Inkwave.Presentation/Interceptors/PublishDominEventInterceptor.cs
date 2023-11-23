using Inkwave.Domain.Common;
using Inkwave.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Inkwave.Persistence.Interceptors
{
    public class PublishDominEventInterceptor : SaveChangesInterceptor
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public PublishDominEventInterceptor(IDomainEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDominEvent(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }
        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            await PublishDominEvent(eventData.Context);
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }
        public async Task PublishDominEvent(DbContext? dbContext)
        {
            if (dbContext == null) return;

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return;

            // dispatch events only if save was successful
            var entitiesWithEvents = dbContext.ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();
            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);
        }
    }
}
