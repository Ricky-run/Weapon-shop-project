using System;
using WeaponShopModel;

namespace DataAccessLayer
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWork(bool useDapper)
        {
            if (useDapper)
            {
                _unitOfWork = new DapperUnitOfWork();
            }
            else
            {
                _unitOfWork = new EFUnitOfWork();
            }
        }
        public IRepository<Weapon> Weapons => _unitOfWork.Weapons;
        public IRepository<Blacksmith> Blacksmiths => _unitOfWork.Blacksmiths;

        public void Save() => _unitOfWork.Save();

        public void Dispose() => _unitOfWork.Dispose();
    }
}
