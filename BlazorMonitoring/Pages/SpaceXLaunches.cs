using FM4017Library.DataServices.SpaceX;
using FM4017Library.Dtos.SpaceX;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages;

public partial class SpaceXLaunches
{
    [Inject]
    ISpaceXDataService? spaceXDataService { get; set; }

    private LaunchDto[]? launches;

    protected override async Task OnInitializedAsync()
    {
        launches = await spaceXDataService.GetAllLaunches();
    }
}
