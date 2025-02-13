using System.Collections.Generic;

namespace XBaseLibrary.Interfaces
{
    public interface IXBaseRepository<T>
    {
        void CreateRecord(T record);
        var ReadRecordsTuple();
        T UpdateRecord(int recordId, Dictionary<string, object> fields);
        void DeleteRecord(int recordId);
        // Other methods for table operations.
    }
}