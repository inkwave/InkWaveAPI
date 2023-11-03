using Microsoft.OpenApi.Models;

namespace Inkwave.WebAPI.Extensions;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Inkwave Application",
                Description = "Inkwave Application Web API",
            });
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Input the JWT like: Bearer {your token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });
            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    Array.Empty<string>()
                },
            });
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //public static void AddApiVersioningExtension(this IServiceCollection services)
    //{ 
    //    services.AddApiVersioning(config =>
    //    {
    //        // Specify the default API Version as 1.0
    //        config.DefaultApiVersion = new ApiVersion(1, 0);
    //        // If the client hasn't specified the API version in the request, use the default API version number
    //        config.AssumeDefaultVersionWhenUnspecified = true;
    //        // Advertise the API versions supported for the particular endpoint
    //        config.ReportApiVersions = true;
    //    });
    //}
}

