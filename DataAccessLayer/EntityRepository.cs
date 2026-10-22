using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{

    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ReadById(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}