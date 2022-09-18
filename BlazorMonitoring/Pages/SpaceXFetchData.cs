using FM4017Library.Dtos.SpaceX;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorMonitoring.Pages;

public partial class SpaceXFetchData
{
    [Inject]
    private HttpClient? Http { get; set; }

    private LaunchDto[]? launches;

    protected override async Task OnInitializedAsync()
    {
        //launches = await Http.GetFromJsonAsync<LaunchDto[]>("https://api.spacex.land/rest/launches");
        launches = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
    }
}
