using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Inkwave.Infrastructure.Authentication;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    const string SectionName = "Jwt";
    private readonly IConfiguration configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public void Configure(JwtOptions options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
