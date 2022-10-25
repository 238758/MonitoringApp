using System.Text.Json.Serialization;

namespace FM4017Library.Dtos;

public class Spaces
{
    [JsonPropertyName("nodes")]
    public List<SpaceNode>? SpaceNodes { get; set; }
}

public class SpaceNode
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("metadata")]
    public SpaceMetadata? Metadata { get; set; }

    [JsonPropertyName("parent")]
    public Parent? Parent { get; set; }

    [JsonPropertyName("points")]
    public Points? Points { get; set; }
}

public class SpaceMetadata
{
    [JsonPropertyName("desc")]
    public string? Desc { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("contact person")]
    public string? ContactPerson { get; set; }

    [JsonPropertyName("e-mail")]
    public string? EMail { get; set; }

    [JsonPropertyName("office")]
    public string? Office { get; set; }

    [JsonPropertyName("tlf")]
    public string? Tlf { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}

public class Parent
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

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
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("metadata")]
    public PointMetadata? Metadata { get; set; }

    [JsonPropertyName("signals")]
    public Signals? Signals { get; set; }
}

public class PointMetadata
{
    [JsonPropertyName("DevEUI")]
    public string? DevEui { get; set; }

    [JsonPropertyName("measurement")]
    public List<Measurement>? Measurement { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}

public class Measurement
{
    [JsonPropertyName("parameter")]
    public string? Parameter { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
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
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("metadata")]
    public SignalMetadata? Metadata { get; set; }

    [JsonPropertyName("data")]
    public SignalData? Data { get; set; }
}

public partial class SignalData
{
    [JsonPropertyName("rawValue")]
    public string? RawValue { get; set; }

    [JsonPropertyName("numericValue")]
    public double? NumericValue { get; set; }
}

public partial class SignalMetadata
{
    [JsonPropertyName("Signal_strength")]
    public string? SignalStrength { get; set; }

    [JsonPropertyName("SNR")]
    public string? Snr { get; set; }
}