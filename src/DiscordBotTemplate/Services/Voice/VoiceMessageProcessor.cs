using Microsoft.Extensions.Options;

namespace DiscordBotTemplate.Services.Voice;

internal class VoiceMessageProcessor : IVoiceMessageProcessor
{
    private readonly string[] allowedAudioTypes = { "audio/mpeg", "audio/wav", "audio/ogg", "audio/aac" };
    private readonly IOptions<IntegrationOptions> _integrationOptions;

    public VoiceMessageProcessor(IOptions<IntegrationOptions> integrationOptions)
        => _integrationOptions = integrationOptions;

    public async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs @event)
    {
        if (IsBotMessage(@event.Author))
            return;

        var message = @event.Message;
        var attachment = message.Attachments.FirstOrDefault();

        if (attachment is not null)
        {
            var audioFileMetadata = CreateAudioMetadataFromAttachment(attachment);
            await SendAudioToWebhookAsync(audioFileMetadata, _integrationOptions.Value.WebhookUrl);
            await @event.Message.RespondAsync("Hey Master! Good news; the note has been saved! :rocket:");
        }
    }

    private async Task SendAudioToWebhookAsync(AudioFileMetadata? audioFileMetadata, string webhookUrl)
    {
        using var client = new HttpClient();

        var payload = audioFileMetadata?.ToJson();
        var response = (await client.PostAsync(webhookUrl, payload))
            .EnsureSuccessStatusCode();

        if (response is not null)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }

    private AudioFileMetadata? CreateAudioMetadataFromAttachment(DiscordAttachment attachment)
    {
        if (!IsAudioAttachment(attachment))
            return null;

        var filename = attachment.FileName;
        var url = attachment.Url;
        var extension = Path.GetExtension(filename);

        return new AudioFileMetadata(filename, url, extension);
    }

    private bool IsAudioAttachment(DiscordAttachment attachment)
        => allowedAudioTypes.Contains(attachment.MediaType);

    private bool IsBotMessage(DiscordUser author)
        => author.IsBot;

    private async Task SendAudioAsStreamToWebhookAsync(Stream audioStream, string webhookUrl)
    {
        using var httpClient = new HttpClient();
        using var content = new StreamContent(audioStream);
        var response = await httpClient.PostAsync(webhookUrl, content);

        Console.WriteLine(response.EnsureSuccessStatusCode());
    }
}
