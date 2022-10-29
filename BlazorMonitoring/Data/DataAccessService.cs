using FM4017Library.DataAccess;
using FM4017Library.Dtos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace BlazorMonitoring.Data;

public class DataAccessService : INotifyPropertyChanged
{
    private int _pollRateMinutes = 1;

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
        // for each exisitng point with signal check for new signals and add in list

        // for new point and space add last 100

        SpaceNodes = await _d4DataService.GetAllSpacesPointsSignals();
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
