using System;
using WeaponShopModel;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Weapon> Weapons { get; }
        IRepository<Blacksmith> Blacksmiths { get; }
        void Save();
    }
}