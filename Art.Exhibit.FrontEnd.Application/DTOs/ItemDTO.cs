using System.Text.Json.Serialization;

namespace Art.Exhibit.FrontEnd.Application.DTOs;

public class ItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();

    [JsonPropertyName("image")]
    public string ImageLink { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
}
