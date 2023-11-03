using Inkwave.Application.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Inkwave.Application.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseApplicationLayer(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
