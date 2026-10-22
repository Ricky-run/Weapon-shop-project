using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Delete(int id);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T item);
    }
}