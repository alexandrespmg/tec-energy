namespace DownloadCsvOverHttp.models;

public class Validated<T>
{
    public IEnumerable<T> Valid { get; set; }
    public IEnumerable<T> Invalid { get; set; }
}


