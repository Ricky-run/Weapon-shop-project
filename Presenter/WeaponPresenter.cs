using Shared;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using WeaponShopWinForms;

namespace Presenter
{
    public class WeaponPresenter
    {
        private readonly IWeaponView _view;
        private readonly IModel _model;

        public WeaponPresenter(IWeaponView view, IModel model)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));

            // 1. Подписка на события View (чистый конструктор)
            _view.LoadWeaponsRequested += OnLoadWeapons;
            _view.AddWeaponRequested += OnAddWeapon;
            _view.UpdateWeaponRequested += OnUpdateWeapon;
            _view.DeleteWeaponRequested += OnDeleteWeapon;
            _view.StatsRequested += OnStatsRequested;
            _view.RecommendWeaponsRequested += OnRecommendWeapons;

            // 2. Подписка на события Model
            _model.WeaponsLoaded += OnWeaponsLoaded;
            _model.WeaponAdded += OnWeaponAdded;
            _model.WeaponUpdated += OnWeaponUpdated;
            _model.WeaponDeleted += OnWeaponDeleted;
            _model.ErrorOccurred += OnErrorOccurred;
        }

        // ========== Обработчики событий View ==========

        private void OnLoadWeapons()
        {
            try
            {
                _model.LoadWeapons();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка загрузки: " + ex.Message);
            }
        }

        private void OnAddWeapon(WeaponDto dto)
        {
            try
            {
                _model.AddWeapon(dto);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка добавления: " + ex.Message);
            }
        }

        private void OnUpdateWeapon(WeaponDto dto)
        {
            try
            {
                _model.UpdateWeapon(dto);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка обновления: " + ex.Message);
            }
        }

        private void OnDeleteWeapon(int id)
        {
            try
            {
                _model.DeleteWeapon(id);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка удаления: " + ex.Message);
            }
        }

        private void OnStatsRequested()
        {
            try
            {
                var stats = _model.GetWeaponTypeStatistics();
                _view.ShowStatistics(stats);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка получения статистики: " + ex.Message);
            }
        }

        private void OnRecommendWeapons(int strength, decimal gold, decimal _)
        {
            try
            {
                var list = _model.RecommendWeapons(strength, gold);
                _view.ShowRecommendations(list, strength, gold);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка подбора оружия: " + ex.Message);
            }
        }

        // ========== Обработчики событий Model ==========

        private void OnWeaponsLoaded(IEnumerable<WeaponDto> list)
        {
            _view.ShowWeapons(list);
        }

        private void OnWeaponAdded(WeaponDto w)
        {
            _view.ShowMessage($"Оружие '{w.Name}' добавлено.");
            _model.LoadWeapons();
        }

        private void OnWeaponUpdated(WeaponDto w)
        {
            _view.ShowMessage($"Оружие '{w.Name}' обновлено.");
            _model.LoadWeapons();
        }

        private void OnWeaponDeleted(int id)
        {
            _view.ShowMessage($"Оружие #{id} удалено.");
            _model.LoadWeapons();
        }

        private void OnErrorOccurred(string msg)
        {
            _view.ShowMessage("Ошибка: " + msg);
        }
    }
}