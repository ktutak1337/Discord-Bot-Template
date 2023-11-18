using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBotTemplate;

internal static class Extensions
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddTransient<IBotConfigurator, BotConfigurator>()
            .AddTransient<IVoiceMessageProcessor, VoiceMessageProcessor>()
            .AddDiscord(configuration)
            .AddIntegrationTool(configuration);
    }

    public static IServiceCollection AddDiscord(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<DiscordOptions>(configuration.GetSection(DiscordOptions.Key));

    public static IServiceCollection AddIntegrationTool(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<IntegrationOptions>(configuration.GetSection(IntegrationOptions.Key));
}
