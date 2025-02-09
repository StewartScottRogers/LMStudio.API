public interface IXBaseOperations<T>
{
    void CreateRecord(T record);
    T ReadRecord(Guid id);
    IEnumerable<T> QueryRecords(string query);
    void UpdateRecord(Guid id, T updatedRecord);
    void DeleteRecord(Guid id);
}