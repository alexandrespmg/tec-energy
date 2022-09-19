namespace DownloadCsvOverHttp.models;

public class Validated<T>
{
    public IEnumerable<T> valid { get; set; }
    public IEnumerable<T> invalid { get; set; }
}


