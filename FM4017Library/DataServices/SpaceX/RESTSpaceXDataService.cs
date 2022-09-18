using FM4017Library.Dtos.SpaceX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.DataServices.SpaceX;

public class RESTSpaceXDataService : ISpaceXDataService
{
    private readonly HttpClient _httpclient;

    public RESTSpaceXDataService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<LaunchDto[]?> GetAllLaunches()
    {
        var result = await _httpclient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");

        return result;
    }
}

