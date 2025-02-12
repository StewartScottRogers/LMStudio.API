public interface IXBaseRepository<T> where T : class
{
    void Add(T entity);
    void Remove(T entity);
    IEnumerable<T> GetAll();
    // Other methods for querying, updating, etc.
}