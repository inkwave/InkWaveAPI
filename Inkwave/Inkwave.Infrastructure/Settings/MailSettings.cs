using Inkwave.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Inkwave.Infrastructure.Settings;


public class MailSettingsSetup : IConfigureOptions<MailSettings>
{
    const string SectionName = "MailSettings";
    private readonly IConfiguration configuration;

    public MailSettingsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public void Configure(MailSettings options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
