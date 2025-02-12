public class XBaseTable
{
    public string TableName { get; }
    private readonly List<XBaseField> Fields;
    private readonly List<XBaseRecord> Records;

    public XBaseTable(string tableName)
    {
        TableName = tableName;
        Fields = new List<XBaseField>();
        Records = new List<XBaseRecord>();
    }

    // Add Field to Table
    public void AddField(XBaseField field)
    {
        Fields.Add(field);
    }

    // Add Record to Table
    public void AddRecord(XBaseRecord record)
    {
        if (record.Fields.Count != Fields.Count) throw new ArgumentException("Number of fields in the record do not match the table.");
        Records.Add(record);
    }

    // Query Records using SQL-like queries
    public IEnumerable<XBaseRecord> QueryRecords(string query)
    {
        // Implement Simple SQL-like parser and execution logic
        return from record in Records 
               where MatchesQuery(record, query) 
               select record;
    }
    
    private bool MatchesQuery(XBaseRecord record, string query)
    {
        // Placeholder for query matching logic
        return true;
    }

    // Other methods like Update, Delete, etc.
}