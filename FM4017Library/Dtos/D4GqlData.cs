using System.Text.Json.Serialization;

namespace FM4017Library.Dtos;

public class D4GqlData
{
    [JsonPropertyName("data")]
    public D4GqlDataData? Data { get; set; }
}

public class D4GqlDataData
{
    [JsonPropertyName("spaces")]
    public Spaces? Spaces { get; set; }
}



public class PointsD4GqlData
{
    [JsonPropertyName("data")]
    public PointsD4GqlDataData? Data { get; set; }
}

public class PointsD4GqlDataData
{
    [JsonPropertyName("points")]
    public Points? Points { get; set; }
}