using DownloadCsvOverHttp.models;

namespace DownloadCsvOverHttp.services;

public static class Validator
{
    public static Validated<OperationallyAvailableCapacityTw> Validate(List<OperationallyAvailableCapacityTw> operationallyAvailableCapacityTws)
    {
        var valid = operationallyAvailableCapacityTws.FindAll(op => op.QtyReason == "");
        var invalid = operationallyAvailableCapacityTws.FindAll(op => op.QtyReason != "");

        var validation = new Validated<OperationallyAvailableCapacityTw>
        {
            Valid = valid,
            Invalid = invalid
        };

        return validation;
    }
}
