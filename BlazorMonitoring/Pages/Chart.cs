using FM4017Library.DataAccess;
using FM4017Library.Dtos;
using System.Diagnostics;

namespace BlazorMonitoring.Pages;

public partial class Chart
{
    private List<SignalNode>? _signalNodes = new();

    List<SignalNode>? SignalNodes
    {
        get { return _signalNodes; }
        set
        {
            _signalNodes = value;
        }
    }


    public async Task<List<SignalNode>?> GetSignals(string pointId, DateTime? startDate, int daysToChart)
    {
        DateTime? EndDt = startDate?.AddDays(daysToChart);
        DateTime? paginationStartDt = startDate;

        for (int i = 0; i < 10; i++)
        {
            if (paginationStartDt is not null && EndDt is not null)
            {
                var signals = await _d4DataService.GetFirstSignalsInPointBetween2DateTime(pointId, EndDt.Value, paginationStartDt.Value);
                paginationStartDt = signals?.LastOrDefault()?.Timestamp;

                if (signals is not null)
                {
                    SignalNodes!.AddRange(signals);
                }
            }
        }

        return SignalNodes;
    }

}
