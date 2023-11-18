namespace DiscordBotTemplate.Services;

internal interface IVoiceMessageProcessor
{
    Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs @event);
}
