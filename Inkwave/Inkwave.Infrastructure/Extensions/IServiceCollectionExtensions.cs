using Inkwave.Application.Interfaces;
using Inkwave.Domain.Common;
using Inkwave.Domain.Common.Interfaces;
using Inkwave.Infrastructure.Services;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Inkwave.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>();
        }
    }
}
