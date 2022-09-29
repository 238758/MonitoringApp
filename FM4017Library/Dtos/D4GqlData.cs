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
    public D4GqlDataData? Data { get; set; }
}

public partial class D4GqlDataData
{
    [JsonPropertyName("points")]
    public Points? Points { get; set; }
}











