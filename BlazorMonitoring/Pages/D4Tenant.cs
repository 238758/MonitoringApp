using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using System.Timers;

namespace BlazorMonitoring.Pages;

public partial class D4Tenant
{
    [Inject]
    ID4DataService? D4DataService { get; set; }

    private string? _d4TenantName;
    private List<SpaceNode>? spaceNodes;
    private System.Timers.Timer _updateTimer;


    protected override async Task OnInitializedAsync()
    {
        spaceNodes = await D4DataService.GetAllSpacesPointsSignals();


        _updateTimer = new System.Timers.Timer(10 * 60 * 10);
        _updateTimer.Elapsed += _updateTimer_Elapsed;
        _updateTimer.Enabled = true;
    }

    private async void _updateTimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        spaceNodes = await D4DataService.GetAllSpacesPointsSignals();
        await InvokeAsync(StateHasChanged);
    }

    protected override void OnInitialized()
    {
        _d4TenantName = _config["DimensionFour:Header1Value"];
    }


    public void Dispose()
    {
        // dispose timer when leaving page
        _updateTimer?.Dispose();        
    }
}
