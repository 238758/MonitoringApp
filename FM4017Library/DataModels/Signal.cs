namespace FM4017Library.DataModels;

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
}
