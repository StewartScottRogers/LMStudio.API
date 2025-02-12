using System.Collections.Generic;
using XBaseLibrary.Entities;

namespace XBaseLibrary.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly List<Record> _records = new();

        public IEnumerable<Record> GetAllRecords() => _records;

        public Record GetRecordById(int id) => _records.Find(r => r.Id == id);

        public void AddRecord(Record record) => _records.Add(record);

        public void UpdateRecord(Record record)
        {
            var index = _records.FindIndex(r => r.Id == record.Id);
            if (index != -1) _records[index] = record;
        }

        public void DeleteRecord(int id)
        {
            _records.RemoveAll(r => r.Id == id);
        }
    }
}