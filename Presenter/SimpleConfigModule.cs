using BusinessLogic;
using DataAccessLayer;
using Ninject.Modules;
using Ninject;
using Shared;
using WeaponShopModel;
using System.Configuration;

namespace Presenter
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["WeaponShopConnection"].ConnectionString;

            Bind<IUnitOfWork>()
                .ToMethod(ctx => new DapperUnitOfWork(connStr))
                .InSingletonScope();

            Bind<LogicFunctions>().ToSelf().InSingletonScope();
            Bind<ILogic>().To<Logic>().InSingletonScope();
            Bind<IModel>().To<Logic>().InSingletonScope();

            Bind<IRepository<Weapon>>()
                .ToMethod(ctx => ctx.Kernel.Get<IUnitOfWork>().Weapons).InSingletonScope();
            Bind<IRepository<Blacksmith>>()
                .ToMethod(ctx => ctx.Kernel.Get<IUnitOfWork>().Blacksmiths).InSingletonScope();
        }
    }
}