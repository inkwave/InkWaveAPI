using Inkwave.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inkwave.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly PublishDominEventInterceptor _publishDominEventInterceptor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, PublishDominEventInterceptor publishDominEventInterceptor) : base(options)
    {
        _publishDominEventInterceptor = publishDominEventInterceptor;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Printing> Prints => Set<Printing>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<SubDescription> SubDescriptions => Set<SubDescription>();
    public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
    public DbSet<Favourite> Favourites => Set<Favourite>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Favourite>().HasIndex(c => c.UserId);
        modelBuilder.Entity<Cart>().HasIndex(c => c.UserId);
        modelBuilder.Entity<Order>().HasIndex(c => c.CustomerId);
        modelBuilder.Entity<Printing>().HasIndex(c => c.UserId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDominEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    //{
    //    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);



    //    return result;
    //}

    //public override int SaveChanges()
    //{
    //    return SaveChangesAsync().GetAwaiter().GetResult();
    //}
}
