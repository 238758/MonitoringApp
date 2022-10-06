using FM4017Library.DataServices;
using FM4017Library.Dtos;
using Microsoft.AspNetCore.Components;
using System.Timers;

namespace BlazorMonitoring.Pages
{
    public partial class D4Points
    {
        [Inject]
        ID4DataService? D4DataService { get; set; }

        private List<PointNode> _pointList = new();
        private int _pollRateMinutes;
        private System.Timers.Timer? _updateTimer;


        protected override async Task OnInitializedAsync()
        {
            if (D4DataService != null)
            {
                if (D4DataService != null)
                {
                    _pointList = await D4DataService.GetAllPointsSignals();
                }
            }

            _updateTimer = new System.Timers.Timer(1000 * 60 * _pollRateMinutes);
            _updateTimer.Elapsed += _updateTimer_Elapsed;
            _updateTimer.AutoReset = true;
            _updateTimer.Enabled = true;

        }

        protected override void OnInitialized()
        {
            _pollRateMinutes = int.Parse(_config["PollRateMinutes"]);
        }

        private async void _updateTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (D4DataService != null)
            {
                _pointList = await D4DataService.GetAllPointsSignals();
            }


            await InvokeAsync(StateHasChanged);
        }

    }
}
