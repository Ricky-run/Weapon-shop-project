using System;
using System.Configuration;
using WeaponShopModel;

namespace DataAccessLayer
{
    /// <summary>
    /// Реализация Unit of Work для работы с базой данных через Dapper.
    /// </summary>
    public class DapperUnitOfWork : IUnitOfWork
    {
        public IRepository<Weapon> Weapons { get; }
        public IRepository<Blacksmith> Blacksmiths { get; }

        public DapperUnitOfWork(string connectionString = null)
        {
            string connStr = connectionString ?? ConfigurationManager.ConnectionStrings["WeaponShopConnection"]?.ConnectionString;

            Weapons = new DapperWeaponRepository(connStr);
            Blacksmiths = new DapperBlacksmithRepository(connStr);
        }

        /// <summary>
        /// В Dapper-репозиториях запросы отправляются в БД сразу при вызове Add/Update/Delete.
        /// Метод присутствует для сохранения единого контракта с EFUnitOfWork.
        /// </summary>
        public void Save()
        {
        }

        /// <summary>
        /// В Dapper каждое подключение открывается и закрывается внутри репозитория (using var connection).
        /// Метод реализует IDisposable для совместимости с общепринятым интерфейсом IUnitOfWork.
        /// </summary>
        public void Dispose()
        {
        }
    }
}