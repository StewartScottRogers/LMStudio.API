namespace XBaseLibrary.Interfaces
{
    using Records;
    using System.Collections.Generic;

    public interface IXBaseDatabase
    {
        bool CreateTable(string tableName);
        bool DeleteTable(string tableName);
        IEnumerable<XBaseRecord> Query(string query);
        bool Insert(XBaseRecord record, string intoTable);
        bool Update(XBaseRecord record, string inTable);
        bool Delete(XBaseRecord record, string fromTable);
    }
}