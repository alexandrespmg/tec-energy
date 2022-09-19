using DownloadCsvOverHttp.repository;
using DownloadCsvOverHttp.services;

Console.WriteLine("Program | Starting App...");

var energyTransferService = new EnergyTransferService();

var operationallyAvailableCapacity = await energyTransferService.GetOperationallyAvailableCapacityFromDateRange(
    DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1));

var validatedData = Validator.Validate(operationallyAvailableCapacity);

var repository = new OperationallyAvailableCapacityRepository();

await repository.Save(validatedData.Valid);

Console.WriteLine("Program | App Finishing...");
