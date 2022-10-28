using FM4017Library.DataModels;
using FM4017Library.Dtos;
using System.Collections.Generic;

namespace FM4017Library.Helpers;

public static class SignalNodeHelpers
{
    /// <summary>
    /// List unique units from list of signalNodes
    /// </summary>
    /// <param name="signalNodes"></param>
    /// <returns></returns>
    public static List<string?> ListUniqueUnits(List<SignalNode>? signalNodes)
    {
        // Get list of signal with unique units
        var uniqueUnitSignalNodes = signalNodes?.DistinctBy(signal => signal.Unit).ToList();

        List<string?> uniqueUnits = new ();

        if (uniqueUnitSignalNodes is not null)
        {
            foreach (var uniqueUnitSignalNode in uniqueUnitSignalNodes)
            {
                uniqueUnits.Add(uniqueUnitSignalNode.Unit!);
            }
        }
        
        return uniqueUnits;
    }

    /// <summary>
    /// split a list of signalNodes to a list of list where each list of signalNodes have unique unit
    /// </summary>
    /// <param name="signalNodes"></param>
    /// <returns></returns>
    public static List<List<SignalNode>> SplitListToListsWithUniqueUnit(List<SignalNode>? signalNodes)
    {
        List<List<SignalNode>> result = new();

        List<string?> uniqueUnits = ListUniqueUnits(signalNodes);

        if (uniqueUnits is not null)
        {
            foreach (var uniqeUnit in uniqueUnits)
            {
                // holds result per unit
                List<SignalNode> unitResult = new();

                foreach (var signalNode in signalNodes!.Where(t => t.Unit == uniqeUnit))
                {
                    if (signalNode?.Timestamp is not null)
                    {
                        unitResult.Add(signalNode);
                    }
                }
                result.Add(unitResult);
            }
        }

        return result;
    }

    /// <summary>
    /// Return channel 1 signal nodes if channel not null
    /// else split a list of signalNodes to a list of list where each list have a unique unit
    /// </summary>
    /// <param name="signalNodes"></param>
    /// <returns></returns>
    public static List<List<SignalNode>> SplitListToListsWithUniqueChannelOrUniqueUnit(List<SignalNode>? signalNodes)
    {
        List<List<SignalNode>> result = new();
        
        // Return channel 1 signal nodes if channel not null
        if (signalNodes?.LastOrDefault()?.Metadata?.Channel is not null)
        {
            List<SignalNode>? channel1List = signalNodes?.Where(signal => signal?.Metadata?.Channel == "1").ToList();
            result.Add(channel1List!);
            return result;
        }


        List<string?> uniqueUnits = ListUniqueUnits(signalNodes);

        if (uniqueUnits is not null)
        {
            foreach (var uniqeUnit in uniqueUnits)
            {
                // holds result per unit
                List<SignalNode> unitResult = new();

                foreach (var signalNode in signalNodes!.Where(t => t.Unit == uniqeUnit))
                {
                    if (signalNode?.Timestamp is not null)
                    {
                        unitResult.Add(signalNode);
                    }
                }
                result.Add(unitResult);
            }
        }

        return result;
    }
}
