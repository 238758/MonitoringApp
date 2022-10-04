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
    private int _pollRateMinutes;
    private List<SpaceNode>? spaceNodes;
    private System.Timers.Timer? _updateTimer;
    private DateTime? _updateDateTime = DateTime.UtcNow;


    protected override async Task OnInitializedAsync()
    {
        if (D4DataService != null)
        {
            spaceNodes = await D4DataService.GetAllSpacesPointsSignals();
        }

        _updateTimer = new System.Timers.Timer(1000 * 60 * _pollRateMinutes);
        _updateTimer.Elapsed += _updateTimer_Elapsed;
        _updateTimer.AutoReset = true;
        _updateTimer.Enabled = true;
    }

    private async void _updateTimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        if (D4DataService != null)
        {
            spaceNodes = await D4DataService.GetAllSpacesPointsSignals();
        }

        _updateDateTime = DateTime.UtcNow;

        await InvokeAsync(StateHasChanged);
    }

    protected override void OnInitialized()
    {
        _d4TenantName = _config["DimensionFour:Header1Value"];
        _pollRateMinutes = int.Parse(_config["PollRateMinutes"]);
    }

    public void Dispose()
    {
        // dispose timer when leaving page
        _updateTimer?.Dispose();        
    }
}
