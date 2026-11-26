using Shared;
using Shared.Dto;
using System;
using WeaponShopWinForms;

namespace Presenter
{
    public class BlacksmithPresenter
    {
        private readonly IBlacksmithView _view;
        private readonly IModel _model;

        public BlacksmithPresenter(IBlacksmithView view, IModel model)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));

            // 1. Подписка на события View (чистый конструктор)
            _view.LoadBlacksmithsRequested += OnLoadBlacksmiths;
            _view.AddBlacksmithRequested += OnAddBlacksmith;
            _view.UpdateBlacksmithRequested += OnUpdateBlacksmith;
            _view.DeleteBlacksmithRequested += OnDeleteBlacksmith;
            _view.FindBlacksmithsRequested += OnFindBlacksmiths;
            _view.CalculateForgingPriceRequested += OnCalculateForgingPrice;
            _view.GetBlacksmithByIdRequested += OnGetBlacksmithById;

            // 2. Подписка на события Model
            _model.BlacksmithsLoaded += OnBlacksmithsLoaded;
            _model.BlacksmithAdded += OnBlacksmithAdded;
            _model.BlacksmithUpdated += OnBlacksmithUpdated;
            _model.BlacksmithDeleted += OnBlacksmithDeleted;
            _model.ErrorOccurred += OnErrorOccurred;
        }

        // ========== Обработчики событий View ==========

        private void OnLoadBlacksmiths()
        {
            try
            {
                _model.LoadBlacksmiths();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка: " + ex.Message);
            }
        }

        private void OnAddBlacksmith(BlacksmithDto dto)
        {
            try
            {
                _model.AddBlacksmith(dto);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка: " + ex.Message);
            }
        }

        private void OnUpdateBlacksmith(BlacksmithDto dto)
        {
            try
            {
                _model.UpdateBlacksmith(dto);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка: " + ex.Message);
            }
        }

        private void OnDeleteBlacksmith(int id)
        {
            try
            {
                _model.DeleteBlacksmith(id);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка: " + ex.Message);
            }
        }

        private void OnFindBlacksmiths(string spec, int skill)
        {
            try
            {
                var list = _model.FindBlacksmiths(spec, skill);
                _view.ShowBlacksmiths(list);
                _view.ShowMessage($"Найдено кузнецов: {list.Count}");
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка поиска: " + ex.Message);
            }
        }

        private void OnCalculateForgingPrice(int id, decimal basePrice)
        {
            try
            {
                var b = _model.GetBlacksmithById(id);
                if (b == null)
                {
                    _view.ShowMessage("Кузнец не найден.");
                    return;
                }
                var price = _model.CalculateForgingPrice(basePrice, id);
                _view.ShowForgingPrice(b.Name, b.PriceMultiplier, price);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка: " + ex.Message);
            }
        }

        private void OnGetBlacksmithById(int id)
        {
            try
            {
                var b = _model.GetBlacksmithById(id);
                _view.ShowBlacksmiths(b == null ? Array.Empty<BlacksmithDto>() : new[] { b });
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка: " + ex.Message);
            }
        }

        // ========== Обработчики событий Model ==========

        private void OnBlacksmithsLoaded(System.Collections.Generic.IEnumerable<BlacksmithDto> list)
        {
            _view.ShowBlacksmiths(list);
        }

        private void OnBlacksmithAdded(BlacksmithDto b)
        {
            _view.ShowMessage($"Кузнец '{b.Name}' принят.");
            _model.LoadBlacksmiths();
        }

        private void OnBlacksmithUpdated(BlacksmithDto b)
        {
            _view.ShowMessage($"Кузнец '{b.Name}' обновлён.");
            _model.LoadBlacksmiths();
        }

        private void OnBlacksmithDeleted(int id)
        {
            _view.ShowMessage($"Кузнец #{id} уволен.");
            _model.LoadBlacksmiths();
        }

        private void OnErrorOccurred(string msg)
        {
            _view.ShowMessage("Ошибка: " + msg);
        }
    }
}