using BlazorMonitoring.Pages.Components;
using FM4017Library.DataAccess;
using FM4017Library.Dtos;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlazorMonitoring.Pages;

public partial class Chart
{
    public bool GettingSignals { get; set; }

    private List<SignalNode> _signalNodes = new();

    List<SignalNode> SignalNodes
    {
        get { return _signalNodes; }
        set
        {
            _signalNodes = value;
        }
    }

    //public List<PointNode> PointsForList
    //{
    //    get
    //    {
    //        return null;
    //    }
    //}

    

    public async Task<List<PointNode>> PointNodesWithSignals()
    {
        // get all points from D4
        var points = await _d4DataService.GetAllPointsSignals();

        List<PointNode> result = new();

        if (points is not null)
        {
            foreach (var point in points)
            {
                if (point?.Signals?.SignalNodes?.FirstOrDefault() is not null)
                {
                    result.Add(point);
                }
            }
        }
        
        return result;
    }


    public async Task<List<SignalNode>?> GetSignals(string pointId, DateTime? startDate, int daysToChart)
    {
        // For UI indication
        GettingSignals = true;

        // to avoid to long loop
        int queryLimit = 25;

        SignalNodes.Clear();
        //List<SignalNode>? signalNodes = new();

        DateTime? EndDt = startDate?.AddDays(daysToChart);
        DateTime? paginationStartDt = startDate;

        for (int i = 0; i < queryLimit; i++)
        {
            

            // Return if end datetime is reached
            if (paginationStartDt > EndDt)
            {
                // For UI indication
                GettingSignals = false;
                return SignalNodes;
            }

            if (paginationStartDt is not null && EndDt is not null)
            {
                // await for next 100 (max signals)
                var signals = await _d4DataService.GetFirstSignalsInPointBetween2DateTime(pointId, EndDt.Value, paginationStartDt.Value);
                
                // set start datetime for next iteration
                paginationStartDt = signals?.LastOrDefault()?.Timestamp;

                if (signals is not null)
                {
                    SignalNodes!.AddRange(signals);

                    // end loop if less then 100/max signals received
                    if (signals.Count < 100)
                    {
                        // For UI indication
                        GettingSignals = false;
                        return SignalNodes;
                    }
                }
                

            }
        }

        // For UI indication
        GettingSignals = false;
        return SignalNodes;
    }

}
