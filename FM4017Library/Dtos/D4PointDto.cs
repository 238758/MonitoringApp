using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FM4017Library.Dtos;

public class Points
{
    [JsonPropertyName("nodes")]
    public List<PointNode>? PointNodes { get; set; }
}

public class PointNode
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("spaceId")]
    public string? SpaceId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("metadata")]
    public PointMetadata? Metadata { get; set; }

    [JsonPropertyName("signals")]
    public Signals? Signals { get; set; }
}

public class Signals
{
    [JsonPropertyName("nodes")]
    public List<SignalNode>? SignalNodes { get; set; }
}

public class SignalNode
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("pointId")]
    public string? PointId { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("data")]
    public Data? Data { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("metadata")]
    public SignalMetadata? Metadata { get; set; }
}

public class Data
{
    [JsonPropertyName("rawValue")]
    public string? RawValue { get; set; }
}

public class SignalMetadata
{
    [JsonPropertyName("Signal_strength")]
    public string? SignalStrength { get; set; }

    [JsonPropertyName("SNR")]
    public string? Snr { get; set; }
}

public class PointMetadata
{
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}

