using FM4017Library.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.DataModels
{
    public class Signal
    {
        public string? Id { get; set; }
        public string? PointId { get; set; }
        public string? Unit { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? Timestamp { get; set; }
        
        public string? Value { get; set; }

        // derived from metadata
        public string? ReceivedSignalStrengthIndicator { get; set; }
        public string? Snr { get; set; }
        public string? BatteryLevel { get; set; }


        /// <summary>
        /// default constructor
        /// </summary>
        public Signal()
        {

        }

        public Signal(SignalNode signalNode)
        {
            Id = signalNode.Id;
            PointId = signalNode.PointId;
            Unit = signalNode.Unit;
            CreatedAt = signalNode.CreatedAt;
            UpdatedAt = signalNode.UpdatedAt;
            Timestamp = signalNode.Timestamp;

            Value = signalNode?.Data?.RawValue;

            ReceivedSignalStrengthIndicator = signalNode?.Metadata?.SignalStrength;
            Snr = signalNode?.Metadata?.Snr;
            //BatteryLevel = signalNode.
        }
    }
}
