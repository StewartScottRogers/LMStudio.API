using System.Collections.Generic;
using XBaseLibrary.Entities;

namespace XBaseLibrary.Repositories
{
    public interface IRecordRepository
    {
        IEnumerable<Record> GetAllRecords();
        Record GetRecordById(int id);
        void AddRecord(Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(int id);
    }
}