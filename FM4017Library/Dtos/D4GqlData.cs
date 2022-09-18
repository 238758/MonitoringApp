using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FM4017Library.Dtos;

public partial class D4GqlData
{
    [JsonPropertyName("data")]
    public D4GqlDataData Data { get; set; }
}

public partial class D4GqlDataData
{
    [JsonPropertyName("points")]
    public Points Points { get; set; }
}

public partial class Points
{
    [JsonPropertyName("nodes")]
    public D4PointDto[] Nodes { get; set; }
}

public partial class Signals
{
    [JsonPropertyName("nodes")]
    public SignalsNode[] Nodes { get; set; }
}

public partial class SignalsNode
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }

    [JsonPropertyName("data")]
    public NodeData Data { get; set; }
}

public partial class NodeData
{
    [JsonPropertyName("rawValue")]
    public string RawValue { get; set; }
}
