using Microsoft.Extensions.Options;

namespace DiscordBotTemplate.Services.Bot;

internal class BotConfigurator : IBotConfigurator
{
    private DiscordClient? Client { get; set; }
    private readonly IOptions<DiscordOptions> _discordOptions;
    private readonly IVoiceMessageProcessor _voiceMessageProcessor;

    public BotConfigurator(IOptions<DiscordOptions> discordOptions, IVoiceMessageProcessor voiceMessageProcessor)
    {
        _discordOptions = discordOptions;
        _voiceMessageProcessor = voiceMessageProcessor;
    }

    public async Task LaunchAsync() 
        => await InitializeDiscordClient();

    private async Task InitializeDiscordClient()
    {
        Client = new DiscordClient(BuildDiscordConfiguration());

        RegisterDiscordEvents();

        await Client.ConnectAsync();
        await Task.Delay(-1);
    }

    private void RegisterDiscordEvents()
    {
        Client!.MessageCreated += _voiceMessageProcessor.OnMessageCreated;
    }

    private DiscordConfiguration BuildDiscordConfiguration() 
        => new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = _discordOptions.Value.Token,
            TokenType = TokenType.Bot,
            AutoReconnect = true,
        };
}
