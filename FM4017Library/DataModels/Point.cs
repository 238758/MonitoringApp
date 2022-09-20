namespace FM4017Library.DataModels;

public class Point
{
    public int Id { get; set; }
    public string? SpaceId { get; set; }
    public string? Name { get; set; }
    public string? MetaData { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Signal>? signals { get; set; }
    
    // derived from metadata
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? ImageUrl { get; set; }

}
