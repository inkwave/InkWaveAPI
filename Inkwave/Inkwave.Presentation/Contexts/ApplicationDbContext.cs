using Inkwave.Domain;
using Inkwave.Domain.Common;
using Inkwave.Domain.Common.Interfaces;
using Inkwave.Domain.Item;
using Inkwave.Domain.Payment;
using Inkwave.Domain.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inkwave.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
      IDomainEventDispatcher dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<SubDescription> SubDescriptions => Set<SubDescription>();
    public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
    public DbSet<Favourite> Favourites => Set<Favourite>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Favourite>().HasIndex(c => c.UserId);
        modelBuilder.Entity<Cart>().HasIndex(c => c.UserId);
        modelBuilder.Entity<Order>().HasIndex(c => c.CustomerId);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
