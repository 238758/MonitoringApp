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

        // TODO - move to appsettings (Read only token)
        _httpclient.DefaultRequestHeaders.Add("x-tenant-id", "my-test-tenant");
        _httpclient.DefaultRequestHeaders.Add("x-tenant-key", "63694b93b08c907b3838db49");
    }

    public async Task<D4PointDto[]?> GetAllPoints()
    {
        var queryObject = new
        {
            query = @"query { 
                        points {
                            nodes{
                                name 
                                id 
                                createdAt
                                updatedAt 
                                metadata
                                signals(paginate: {last: 100}) {   
						            nodes {
							            id
							            timestamp
                                        unit
                                        data{
                                            rawValue
                     }}}}}}",
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

            var result = gqlData?.Data.Points.Nodes;

            return result;
        }
        return null;
    }
}
