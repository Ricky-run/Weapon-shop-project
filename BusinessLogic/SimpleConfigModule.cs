using System.Configuration; 
using Ninject.Modules;
using DataAccessLayer;
using WeaponShopModel;
using Ninject;


namespace BusinessLogic
   
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {

            //Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();



            Bind<ILogic>().To<Logic>().InSingletonScope();


            string connStr = ConfigurationManager.ConnectionStrings["WeaponShopConnection"].ConnectionString;

            Bind<IUnitOfWork>()
                  .ToMethod(context => new DapperUnitOfWork(connStr))
                  .InSingletonScope();
            Bind<LogicFunctions>().ToSelf().InSingletonScope();
            Bind<IRepository<Weapon>>()
                .ToMethod(context => context.Kernel.Get<IUnitOfWork>().Weapons)
                .InSingletonScope();
            Bind<IRepository<Blacksmith>>()
                .ToMethod(context => context.Kernel.Get<IUnitOfWork>().Blacksmiths)
                .InSingletonScope();
            
        }

    }
}