using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages;

public partial class D4Points
{
    [Inject]
    ID4DataService? D4DataService { get; set; }

    private D4PointDto[]? nodes;


    protected override async Task OnInitializedAsync()
    {
        nodes = await D4DataService.GetAllPoints();
    }

}
