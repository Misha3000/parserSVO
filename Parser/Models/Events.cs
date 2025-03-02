using System.Text.Json.Serialization;

namespace Parser.Models;

public class Events
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
    [JsonPropertyName("fullname")]
    public string Name { get; set; }
    [JsonPropertyName("area")]
    public string Area { get; set; }
}