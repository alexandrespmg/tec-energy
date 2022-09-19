using System.Globalization;
using CsvHelper;
using DownloadCsvOverHttp.models;

namespace DownloadCsvOverHttp.services;

public class EnergyTransferService
{
    private readonly HttpClient _client = new();
    private readonly string _baseUri = "https://twtransfer.energytransfer.com/ipost/capacity/operationally-available";

    private Uri GetUri(DateTime date)
    {
        var uriBuilder = new UriBuilder(_baseUri);

        uriBuilder.Query = $"?gasDay={date.Month.ToString("D2")}%2F{date.Day.ToString("D2")}%2F{date.Year}&cycle={Cycles.Final.GetHashCode()}" +
                           $"&searchType=ALL&searchString=&locType=ALL&locZone=ALL&f=csv&extension=csv&asset=TW";

        return uriBuilder.Uri;
    }

    private async Task<List<OperationallyAvailableCapacityTw>> GetOperationallyAvailableCapacity(Uri uri)
    {
        Console.WriteLine($"EnergyTransferService | Starting download... URL: {uri}");

        var streamTask = await _client.GetStreamAsync(uri);

        using var reader = new StreamReader(streamTask);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<OperationallyAvailableCapacityTw>();

        Console.WriteLine("EnergyTransferService | Download finished...");

        return records.ToList();
    }

    public async Task<List<OperationallyAvailableCapacityTw>> GetOperationallyAvailableCapacityFromDateRange(DateTime initialRange, DateTime finalRange)
    {
        var operationallyAvailableCapacityTws = new List<OperationallyAvailableCapacityTw>();

        for (DateTime date = initialRange; date <= finalRange; date = date.AddDays(1))
        {
            var operationallyAvailableCapacityTw = await GetOperationallyAvailableCapacity(GetUri(date));

            operationallyAvailableCapacityTws.AddRange(operationallyAvailableCapacityTw);
        }

        return operationallyAvailableCapacityTws;
    }
}
