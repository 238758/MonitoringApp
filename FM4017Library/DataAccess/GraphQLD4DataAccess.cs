﻿using FM4017Library.Dtos;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace FM4017Library.DataAccess;

public class GraphQLD4DataAccess : IDataAccess
{
    private readonly HttpClient _httpclient;

    public GraphQLD4DataAccess(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task DeleteSpace(string spaceId)
    {
        var queryObject = new
        {
            query = GraphQlQueries.DeleteSpace(spaceId),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }

    public async Task DeletePoint(string pointId)
    {
        var queryObject = new
        {
            query = GraphQlQueries.DeletePoint(pointId),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }

    public async Task CreateSpace(string name, string? parentId, double? latitude, double? longitude, string? imageUrl)
    {
        var queryObject = new
        {
            query = GraphQlQueries.CreateSpace(name, parentId, latitude, longitude, imageUrl),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }

    public async Task CreatePoint(string name, string? spaceId, double? latitude, double? longitude, string? imageUrl, string? devEui = null)
    {
        var queryObject = new
        {
            query = GraphQlQueries.CreatePoint(name, spaceId, latitude, longitude, imageUrl, devEui),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }

    public async Task EditSpace(string name, string id, double? latitude, double? longitude, string? imageUrl)
    {
        var queryObject = new
        {
            query = GraphQlQueries.EditSpace(name, id, latitude, longitude, imageUrl),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }

    public async Task EditPoint(string name, string id, double? latitude, double? longitude, string? imageUrl, string? devEui)
    {
        var queryObject = new
        {
            query = GraphQlQueries.EditPoint(name, id, latitude, longitude, imageUrl, devEui),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
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

    public async Task<List<SignalNode>> GetLastSignalsInPointBetween2DateTime(string pointId, DateTime ltDateTime, DateTime gtDateTime, int n = 100)
    {
        var queryObject = new
        {
            query = GraphQlQueries.GetLastSignalsInPointBetween2DateTime(pointId, ltDateTime,gtDateTime, n),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
            var gqlData = await JsonSerializer.DeserializeAsync<SignalsD4GqlData>
                (await response.Content.ReadAsStreamAsync());

            var result = gqlData?.Data?.Signals?.SignalNodes;

            return result;
        }
        return null;
    }

    public async Task<List<SignalNode>> GetFirstSignalsInPointBetween2DateTime(string pointId, DateTime ltDateTime, DateTime gtDateTime, int n = 100)
    {
        var queryObject = new
        {
            query = GraphQlQueries.GetFirstSignalsInPointBetween2DateTime(pointId, ltDateTime, gtDateTime, n),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
            var gqlData = await JsonSerializer.DeserializeAsync<SignalsD4GqlData>
                (await response.Content.ReadAsStreamAsync());

            var result = gqlData?.Data?.Signals?.SignalNodes;

            return result;
        }
        return null;
    }

    public async Task CreateSignal(string pointId, string value, DateTime timestamp, string? unit = null)
    {
        var queryObject = new
        {
            query = GraphQlQueries.CreateSignal(pointId, value, timestamp, unit),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }

    public Task EditSignal(string signalId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteSignal(string signalId)
    {
        var queryObject = new
        {
            query = GraphQlQueries.DeleteSignal(signalId),
            variables = new { }
        };

        var query = new StringContent(
            JsonSerializer.Serialize(queryObject),
            Encoding.UTF8,
            "application/json");

        var response = await _httpclient.PostAsync("", query);

        if (response.IsSuccessStatusCode)
        {
        }
    }
}
