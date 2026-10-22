using System;
using WeaponShopModel;

namespace DataAccessLayer
{
    /// <summary>
    /// Реализация Unit of Work для работы с базой данных через Entity Framework.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Weapon> Weapons { get; }
        public IRepository<Blacksmith> Blacksmiths { get; }

        public EFUnitOfWork()
        {
            _context = new AppDbContext();
            Weapons = new EntityRepository<Weapon>(_context);
            Blacksmiths = new EntityRepository<Blacksmith>(_context);
        }

        /// <summary>
        /// Фиксирует все изменения, сделанные через Entity Framework, в файл БД.
        /// </summary>
        public void Save()
        {
            _context?.SaveChanges();
        }

        /// <summary>
        /// Освобождает занятые контекстом ресурсы.
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
