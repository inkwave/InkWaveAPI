using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Persistence.Contexts;
using Inkwave.Persistence.Interceptors;
using Inkwave.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inkwave.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HostConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<PublishDominEventInterceptor>()
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient(typeof(IUserRepository), typeof(UserRepository))
                .AddTransient(typeof(IItemRepository), typeof(ItemRepository))
                .AddTransient(typeof(IFavouriteRepository), typeof(FavouriteRepository))
                .AddTransient(typeof(IAddressRepository), typeof(AddressRepository))
                .AddTransient(typeof(IOrderRepository), typeof(OrderRepository))
                .AddTransient(typeof(ICartRepository), typeof(CartRepository))
                .AddTransient(typeof(IPaymentRepository), typeof(PaymentRepository))
                .AddTransient(typeof(IPaymentMethodRepository), typeof(PaymentMethodRepository));

        }
    }
}
