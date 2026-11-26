using Ninject;
using Shared;
using System;
using System.Windows.Forms;
using WeaponShopWinForms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
namespace Presenter
{
    internal static class Program
    {

        public static IKernel Kernel { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Kernel = new StandardKernel(new SimpleConfigModule());

            // Инициализация БД (если пустая)
            var model = Kernel.Get<IModel>();
            model.InitializeData();

            // Стартуем главное меню
            var menuView = new MainMenuForm();
            var menuPresenter = new MainMenuPresenter(menuView);

            Application.Run(menuView);
        }
    }
}