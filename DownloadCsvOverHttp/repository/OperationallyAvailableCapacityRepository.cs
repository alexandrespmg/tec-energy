using System.Data;
using DownloadCsvOverHttp.models;
using Npgsql;

namespace DownloadCsvOverHttp.repository;

public class OperationallyAvailableCapacityRepository
{
    private readonly NpgsqlConnection _connection;

    public OperationallyAvailableCapacityRepository()
    {
        var connectionUrl = $"Host={Environment.GetEnvironmentVariable("PROSTGRES_HOST")};" +
                            $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
                            $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")};" +
                            $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")}";
        Environment.GetEnvironmentVariable("POSTGRES_USER");
        _connection = new(connectionUrl);
    }

    public async Task Save(IEnumerable<OperationallyAvailableCapacityTw> operationallyAvailableCapacityTws)
    {
        Console.WriteLine("OperationallyAvailableCapacityRepository | Saving in Database...");
        await OpenConnection();

        foreach (var operationallyAvailableCapacityTw in operationallyAvailableCapacityTws)
        {
            await Save(operationallyAvailableCapacityTw);
        }

        Console.WriteLine("OperationallyAvailableCapacityRepository | Database insertions done...");
        await CloseConnection();
    }

    private async Task Save(OperationallyAvailableCapacityTw operationallyAvailableCapacityTw)
    {
        await OpenConnection();

        await using var cmd = new NpgsqlCommand(OperationallyAvailableCapacityQueries.Insert, _connection)
        {
            Parameters =
            {
                new() { NpgsqlValue = operationallyAvailableCapacityTw.Location },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.LocationZone },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.LocationName },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.LocationPurposeDescription },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.LocationPerQuantityTypeIndicator },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.FlowIndicator },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.DesignCapacity },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.OperatingCapacity },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.TotalScheduledQuantity },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.OperationallyAvailableCapacity },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.ITIndicator },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.AuthorizedOverrunIndicator },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.NominationCapacityExceededIndicator },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.AllQtyAvail },
                new() { NpgsqlValue = operationallyAvailableCapacityTw.QtyReason },
            }
        };

        await cmd.ExecuteNonQueryAsync();

        await CloseConnection();
    }

    private async Task OpenConnection()
    {
        if (_connection.State == ConnectionState.Closed) await _connection.OpenAsync();
    }

    private async Task CloseConnection()
    {
        if (_connection.State == ConnectionState.Open) await _connection.CloseAsync();
    }
}
