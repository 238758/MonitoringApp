using FM4017Library.DataAccess;
using FM4017Library.Dtos;
using System.Diagnostics.Metrics;
using System.Timers;

namespace BlazorMonitoring.Data;

public class DataSimulatorService
{
    public bool SimulatorEnabled { get; set; }

    public System.Timers.Timer? _updateTimer;
    private Random _random = new();
    private int _counter = 0;

    private readonly IDataAccess _d4DataService;

	public DataSimulatorService(IDataAccess d4DataService)
	{
		_d4DataService = d4DataService;

        _updateTimer = new System.Timers.Timer(60_000) { Enabled = false };
        _updateTimer.Elapsed += UpdateTimer_Elapsed;
    }

    private void UpdateTimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        CreateSignal();
    }

    private async void CreateSignal()
    {

        //double value = _random.NextDouble();
        double value = Math.Sin(_counter * Math.PI / 180);
        await _d4DataService.CreateSignal("635d26d11fc81ba0c9e4a3a3", value.ToString("0.##"), DateTime.UtcNow, "PERCENTS");

        value = value > 0.5 ? 2 : -2;
        await _d4DataService.CreateSignal("635d26d11fc81ba0c9e4a3a3", value.ToString("0.##"), DateTime.UtcNow, "KILOGRAMS");

        value = Math.Cos(_counter * Math.PI / 180) * 3;
        await _d4DataService.CreateSignal("635d26d11fc81ba0c9e4a3a3", value.ToString("0.##"), DateTime.UtcNow, "CELSIUS_DEGREES");

        _counter +=30;
        if (_counter == 360)
        {
            _counter = 0;
        }
    }


}
