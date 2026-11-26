using System;
using Shared;
using WeaponShopWinForms;
using Ninject;

namespace Presenter
{
    public class MainMenuPresenter
    {
        private readonly IMainMenuView _view;

        public MainMenuPresenter(IMainMenuView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.OpenWeaponsRequested += OnOpenWeapons;
            _view.OpenBlacksmithsRequested += OnOpenBlacksmiths;
        }

        private void OnOpenWeapons()
        {
            var form = new WeaponForm();
            var model = Program.Kernel.Get<IModel>();

            // Используем "выброс" (discard) _, чтобы убрать предупреждение
            _ = new WeaponPresenter(form, model);

            form.ShowDialog();
        }

        private void OnOpenBlacksmiths()
        {
            var form = new BlacksmithForm();
            var model = Program.Kernel.Get<IModel>();

            _ = new BlacksmithPresenter(form, model);

            form.ShowDialog();
        }
    }
}