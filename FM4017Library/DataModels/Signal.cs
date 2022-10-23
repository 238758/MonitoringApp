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
        public string? MetaData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Value { get; set; }
        public DateTime Timestamp { get; set; }

        // derived from metadata
        /// <summary>
        /// Received Signal Strength Indicator
        /// </summary>
        public string? ReceivedSignalStrengthIndicator { get; set; }
        /// <summary>
        /// Signal to Noise Ratio
        /// </summary>
        public string? Snr { get; set; }
        public string? BatteryLevel { get; set; }

    }
}
