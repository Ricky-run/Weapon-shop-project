using BusinessLogic;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;           

namespace WeaponShopWinForms
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());

            ILogic logic = ninjectKernel.Get<ILogic>();
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            Application.Run(new MainMenuForm(logic));


        }
    }
}
