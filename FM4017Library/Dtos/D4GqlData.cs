using FM4017Library.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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