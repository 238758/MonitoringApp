using FM4017Library.Dtos;

namespace BlazorMonitoring.Pages.Components;

public partial class SignalStats
{
    public double CalcOpenPercentage(List<SignalNode>? signalNodes)
    {
        if (signalNodes is null)
        {
            return double.NaN;
        }

        TimeSpan? accumulatedOpenDuration = TimeSpan.Zero;
        TimeSpan? accumulatedClosedDuration = TimeSpan.Zero;

        DateTime? lastDt = null;
        string? lastState = null;

        foreach (var signalNode in signalNodes)
        {
            if (lastDt is not null && lastState is not null)
            {
                if (lastState == "1") // closed
                {
                    var duration = signalNode?.Timestamp!.Value - lastDt!.Value;
                    accumulatedClosedDuration = accumulatedClosedDuration + duration;

                }
                else if (lastState == "0") // open
                {
                    var duration = signalNode?.Timestamp!.Value - lastDt!.Value;
                    accumulatedOpenDuration = accumulatedOpenDuration + duration;
                }
            }

            // keep for next iteration
            lastDt = signalNode?.Timestamp;
            lastState = signalNode?.Data?.RawValue;
        }

        var totalOpenMin = accumulatedOpenDuration.Value.TotalMinutes;
        var totalClosedMin = accumulatedClosedDuration.Value.TotalMinutes;

        var percentageOpen = totalOpenMin / ( totalClosedMin + totalOpenMin) * 100;

        return percentageOpen;
    }



}
