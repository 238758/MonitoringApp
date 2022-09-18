using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FM4017Library.Dtos.SpaceX;

public partial class GqlData
{
    [JsonPropertyName("data")]
    public SpaceXData Data { get; set; }
}

public partial class SpaceXData
{
    [JsonPropertyName("launches")]
    public LaunchDto[] Launches { get; set; }
}
