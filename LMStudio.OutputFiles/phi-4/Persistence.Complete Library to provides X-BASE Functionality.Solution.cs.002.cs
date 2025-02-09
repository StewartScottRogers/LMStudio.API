public class XBaseTable : IXBaseOperations<XBaseRecord>
{
    private readonly List<XBaseRecord> _records = new();

    public void CreateRecord(XBaseRecord record) => _records.Add(record);

    public XBaseRecord ReadRecord(Guid id)
    {
        // Implement logic to read a specific record by ID
        return _records.FirstOrDefault(r => r.GetHashCode() == id.GetHashCode());
    }

    public IEnumerable<XBaseRecord> QueryRecords(string query)
    {
        // Example SQL-like parsing (simplified for demo purposes)
        if(query.StartsWith("SELECT * FROM"))
        {
            return _records.AsEnumerable();
        }
        return Enumerable.Empty<XBaseRecord>();
    }

    public void UpdateRecord(Guid id, XBaseRecord updatedRecord)
    {
        var index = _records.FindIndex(r => r.GetHashCode() == id.GetHashCode());
        if (index != -1) _records[index] = updatedRecord;
    }

    public void DeleteRecord(Guid id)
    {
        _records.RemoveAll(r => r.GetHashCode() == id.GetHashCode());
    }
}