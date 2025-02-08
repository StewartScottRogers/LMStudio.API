namespace XBaseLibrary
{
    public interface IXBaseTable<T> where T : class
    {
        void Create();
        void Delete();
        var QueryRecordsTuple { get; } // Example method to return a tuple
    }

}