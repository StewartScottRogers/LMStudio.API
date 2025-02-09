namespace XBaseLibrary.Classes
{
    using Interfaces;
    using Records;
    using System.Collections.Generic;

    public class XBaseDatabase : IXBaseDatabase
    {
        private readonly Dictionary<string, List<XBaseRecord>> tables = new();

        public bool CreateTable(string tableName)
        {
            if (tables.ContainsKey(tableName)) return false;
            tables.Add(tableName, new List<XBaseRecord>());
            return true;
        }

        public bool DeleteTable(string tableName)
        {
            return tables.Remove(tableName);
        }

        public IEnumerable<XBaseRecord> Query(string query)
        {
            // Simple implementation for demonstration
            if (query.StartsWith("SELECT"))
                throw new System.NotImplementedException("Query execution not implemented yet.");
            
            throw new System.ArgumentException("Invalid query");
        }

        public bool Insert(XBaseRecord record, string intoTable)
        {
            if (!tables.ContainsKey(intoTable)) return false;
            tables[intoTable].Add(record);
            return true;
        }

        public bool Update(XBaseRecord record, string inTable)
        {
            if (!tables.TryGetValue(inTable, out var tableRecords)) return false;

            foreach (var tableRecord in tableRecords)
            {
                if (tableRecord.RecordId == record.RecordId)
                {
                    tableRecord.Fields = record.Fields;
                    return true;
                }
            }

            return false;
        }

        public bool Delete(XBaseRecord record, string fromTable)
        {
            if (!tables.TryGetValue(fromTable, out var tableRecords)) return false;

            return tableRecords.RemoveAll(x => x.RecordId == record.RecordId) > 0;
        }
    }
}