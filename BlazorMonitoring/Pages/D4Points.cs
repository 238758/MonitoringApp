using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorMonitoring.Pages;

public partial class D4Points
{
    [Inject]
    ID4DataService? D4DataService { get; set; }

    private List<PointNode>? pointNodes;
    private List<SignalNode>? signalNodes;



    protected override async Task OnInitializedAsync()
    {
        pointNodes = await D4DataService.GetAllPoints();

        signalNodes = pointNodes?.FirstOrDefault()?.Signals?.SignalNodes;
        
    }

}
