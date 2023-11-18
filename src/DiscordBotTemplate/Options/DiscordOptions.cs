namespace DiscordBotTemplate.Options;

internal class DiscordOptions
{
    public const string Key = "discord";
    public string Token { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
}
