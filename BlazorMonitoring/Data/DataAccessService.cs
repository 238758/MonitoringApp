using FM4017Library.DataAccess;
using FM4017Library.Dtos;
using Syncfusion.Blazor.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;

namespace BlazorMonitoring.Data;

public class DataAccessService : INotifyPropertyChanged
{
    private int _pollRateMinutes = 3;

    private System.Timers.Timer? _updateTimer;
    private List<SpaceNode>? _spaceNodes;

    public List<SpaceNode>? SpaceNodes
    {
        get => _spaceNodes;
        set
        {
            if (value != _spaceNodes)
            {
                _spaceNodes = value;
                NotifyPropertyChanged();
            }
        }
    }

    // Dependency injection
    private readonly IDataAccess _d4DataService;

    public DataAccessService(IDataAccess d4DataService)
    {
        _d4DataService = d4DataService;

        GetAllSpacesPointsSignalsAsync();

        _updateTimer = new System.Timers.Timer(1000 * 60 * _pollRateMinutes) { Enabled = true };
        _updateTimer.Elapsed += UpdateTimer_Elapsed;
    }


    private void UpdateTimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        GetAllSpacesPointsSignalsAsync();
    }

    public async void GetAllSpacesPointsSignalsAsync()
    {
        SpaceNodes = await _d4DataService.GetAllSpacesPointsSignals();




        //Todo

        // for each signal with min 100
        DateTime? dt = DateTime.UtcNow;
        List<SignalNode>? signalNodes = new();

        for (int i = 0; i < 3; i++)
        {
            if (dt is not null)
            {
                var signals = await _d4DataService.GetSignalsInPointBeforeDateTime("63230e49eac7b9be6beb2983", dt.Value, DateTime.UtcNow.AddYears(-1));
                dt = signals?.FirstOrDefault()?.Timestamp;

                // add signals to list if not null
                if (signals is not null)
                {
                    signalNodes.AddRange(signals);
                }
            }
        }
        // Order the list
        signalNodes = signalNodes.OrderBy(x => x.Timestamp).ToList();

        foreach (var item in signalNodes)
        {
            Debug.WriteLine($"signalNodes2: {item.Timestamp}");
        }

        


        // 

    }

    #region PropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}
