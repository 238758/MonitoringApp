using FM4017Library.DataModels;
using FM4017Library.Dtos;

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
    /// split a list of signalNodes to a list of list where each list of signalNodes are sorted by channel or if metadata.channel is null by unique unit
    /// </summary>
    /// <param name="signalNodes"></param>
    /// <returns></returns>
    public static List<List<SignalNode>> SplitListToListsWithUniqueChannelOrUniqueUnit(List<SignalNode>? signalNodes)
    {
        List<List<SignalNode>> result = new();



        if (signalNodes?.LastOrDefault()?.Metadata?.Channel is not null)
        {
            // Get list of signal with unique channel
            var uniqueChannelSignalNodes = signalNodes?.DistinctBy(signal => signal?.Metadata?.Channel).ToList();
            List<string?> uniqueChannels = new() { "1" };

            //if (uniqueChannelSignalNodes is not null)
            //{
            //    foreach (var uniqueChannelSignalNode in uniqueChannelSignalNodes)
            //    {
            //        if (uniqueChannelSignalNode?.Metadata?.Channel! is not null)
            //        {
            //            uniqueChannels.Add(uniqueChannelSignalNode?.Metadata?.Channel!);
            //        }
            //    }
            //}

            foreach (var uniqueChannel in uniqueChannels)
            {
                // holds result per unit
                List<SignalNode> channelResult = new();

                foreach (var signal in signalNodes!.Where(t => t.Metadata.Channel == uniqueChannel))
                {
                    if (signal?.Timestamp is not null)
                    {
                        channelResult.Add(signal);
                    }
                }

                result.Add(channelResult);
            }
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
