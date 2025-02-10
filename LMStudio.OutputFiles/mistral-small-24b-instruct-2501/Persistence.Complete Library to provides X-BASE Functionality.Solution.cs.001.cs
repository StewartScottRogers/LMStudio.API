using System.Collections.Generic;
using XBaseLibrary.Models;

namespace XBaseLibrary.Interfaces
{
    public interface IRecordRepository
    {
        void CreateRecord(RecordModel record);
        IEnumerable<RecordModel> QueryRecords(string sqlQuery);
        void UpdateRecord(RecordModel record);
        void DeleteRecord(string id);
    }
}