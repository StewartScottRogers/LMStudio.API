// Example of XBaseRecord as a Record
public record XBaseRecord(int Id, string Data);

// Example of XBaseTable as a Class
public class XBaseTable
{
    public string Name { get; set; }
    public List<XBaseRecord> Records { get; set; } = new();
}

// Index structure
public record Index(string Field, bool IsUnique);