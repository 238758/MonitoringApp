using FM4017Library.DataAccess;
using FM4017Library.Dtos;
using System.Diagnostics;

namespace BlazorMonitoring.Pages;

public partial class Chart
{
    // for each signal with min 100
    DateTime? dt = DateTime.UtcNow;
    private List<SignalNode>? _signalNodes = new();

    List<SignalNode>? SignalNodes
    {
        get { return _signalNodes; }
        set
        {
            _signalNodes = value;
        }
    }

    public Chart()
    {

    }

    public async Task<List<SignalNode>?> GetSignals()
    {
        for (int i = 0; i < 3; i++)
        {
            if (dt is not null)
            {
                var signals = await _d4DataService.GetSignalsInPointBeforeDateTime("63230e49eac7b9be6beb2983", dt.Value, DateTime.UtcNow.AddYears(-1));
                dt = signals?.FirstOrDefault()?.Timestamp;

                if (signals is not null)
                {
                    SignalNodes!.AddRange(signals);
                }
            }
        }

        SignalNodes = SignalNodes?.OrderBy(x => x.Timestamp).ToList();

        return SignalNodes;
    }

}
