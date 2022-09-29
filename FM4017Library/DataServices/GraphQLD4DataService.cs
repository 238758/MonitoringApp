using FM4017Library.DataAccess.GraphQlQueries;
using FM4017Library.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FM4017Library.DataServices;

public class GraphQLD4DataService : ID4DataService
{
    private readonly HttpClient _httpclient;

    public GraphQLD4DataService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<List<PointNode>?> GetAllPoints()
    {
        var queryObject = new
        {
            query = GraphQlQueries.GetAllPoints,
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
            var gqlData = await JsonSerializer.DeserializeAsync<D4GqlData>
                (await response.Content.ReadAsStreamAsync());

            var result = gqlData?.Data.Points.PointNodes;

            return result;
        }
        return null;
    }
}
