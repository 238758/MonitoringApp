using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages;

public partial class D4Points
{
    [Inject]
    ID4DataService? D4DataService { get; set; }

    private List<D4PointDto>? points;


    protected override async Task OnInitializedAsync()
    {
        points = await D4DataService.GetAllPoints();

    }

}
