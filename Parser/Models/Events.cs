using System.Text.Json.Serialization;

namespace Parser.Models;

public class Events
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    [JsonPropertyName("fullname")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("area")]
    public string Area { get; set; } = string.Empty;
}