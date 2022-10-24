using FM4017Library.DataAccess.GraphQlQueries;
using FM4017Library.Dtos;
using System.Text;
using System.Text.Json;

namespace FM4017Library.DataServices;

public class GraphQLD4DataService : ID4DataService
{
    private readonly HttpClient _httpclient;

    public GraphQLD4DataService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<List<PointNode>?> GetAllPointsSignals()
    {
        var queryObject = new
        {
            query = GraphQlQueries.GetAllPointsSignals,
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
            var gqlData = await JsonSerializer.DeserializeAsync<PointsD4GqlData>
                (await response.Content.ReadAsStreamAsync());

            var result = gqlData?.Data?.Points?.PointNodes;

            return result;
        }
        return null;
    }

    public async Task<List<SpaceNode>?> GetAllSpacesPointsSignals()
    {
        var queryObject = new
        {
            query = GraphQlQueries.GetAllSpacesPointsSignals,
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

            var result = gqlData?.Data?.Spaces?.SpaceNodes;

            return result;
        }
        return null;
    }

    
}
