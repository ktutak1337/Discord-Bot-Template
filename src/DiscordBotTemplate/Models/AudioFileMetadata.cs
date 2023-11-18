using System.Text;

namespace DiscordBotTemplate.Models;

internal record AudioFileMetadata(string Filename, string Url, string Extension)
{
    public StringContent ToJson()
    {
        var json = JsonConvert.SerializeObject(this);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}
