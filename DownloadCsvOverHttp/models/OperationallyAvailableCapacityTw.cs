using CsvHelper.Configuration.Attributes;

namespace DownloadCsvOverHttp.models;

public class OperationallyAvailableCapacityTw
{
    [Index(0)]
    public int Location { get; set; }

    [Index(1)]
    public string? LocationZone { get; set; }

    [Index(2)]
    public string? LocationName { get; set; }

    [Index(3)]
    public string? LocationPurposeDescription { get; set; }

    [Index(4)]
    public string? LocationPerQuantityTypeIndicator { get; set; }

    [Index(5)]
    public string? FlowIndicator { get; set; }

    [Index(6)]
    public int? DesignCapacity { get; set; }

    [Index(7)]
    public int? OperatingCapacity { get; set; }

    [Index(8)]
    public int? TotalScheduledQuantity { get; set; }

    [Index(9)]
    public int? OperationallyAvailableCapacity { get; set; }

    [Index(10)]
    public string? ITIndicator { get; set; }

    [Index(11)]
    public string? AuthorizedOverrunIndicator { get; set; }

    [Index(12)]
    public string? NominationCapacityExceededIndicator { get; set; }

    [Index(13)]
    public string? AllQtyAvail { get; set; }

    [Index(14)]
    public string? QtyReason { get; set; }
}
