using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DataAccessLayer;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
            //Bind<IUnitOfWork>().To<DapperUnitOfWork>().InSingletonScope();

            Bind<ILogic>().To<Logic>().InSingletonScope();
        }
    }
}