using System;
using System.Collections.Generic;
using Shared.Dto;

namespace Shared
{
    /// <summary>
    /// Контракт представления для главного меню.
    /// </summary>
    public interface IMainMenuView : IView
    {
        /// <summary>Запрос на открытие формы оружия.</summary>
        event Action OpenWeaponsRequested;

        /// <summary>Запрос на открытие формы кузнецов.</summary>
        event Action OpenBlacksmithsRequested;
    }

    /// <summary>
    /// Контракт представления для работы с оружием.
    /// Предоставляет Presenter события кликов и методы для отрисовки данных.
    /// </summary>
    public interface IWeaponView : IView
    {
        /// <summary>Возникает при запросе на загрузку списка всего оружия.</summary>
        event Action LoadWeaponsRequested;

        /// <summary>Возникает при запросе на добавление нового оружия.</summary>
        event Action<WeaponDto> AddWeaponRequested;

        /// <summary>Возникает при запросе на обновление данных оружия.</summary>
        event Action<WeaponDto> UpdateWeaponRequested;

        /// <summary>Возникает при запросе на удаление оружия.</summary>
        event Action<int> DeleteWeaponRequested;

        /// <summary>Возникает при запросе на подбор оружия по силе и бюджету.</summary>
        event Action<int, decimal, decimal> RecommendWeaponsRequested;

        /// <summary>Возникает при запросе на получение аналитики по типам оружия.</summary>
        event Action StatsRequested;

        /// <summary>
        /// Отображает список оружия в таблице.
        /// </summary>
        /// <param name="weapons">Список оружия для отображения.</param>
        void ShowWeapons(IEnumerable<WeaponDto> weapons);

        /// <summary>
        /// Отображает результаты подбора оружия.
        /// </summary>
        void ShowRecommendations(IEnumerable<WeaponDto> weapons, int strength, decimal gold);

        /// <summary>
        /// Отображает статистику по типам оружия.
        /// </summary>
        void ShowStatistics(IEnumerable<WeaponTypeStatDto> stats);

        /// <summary>
        /// Открывает диалоговое окно для добавления/редактирования оружия.
        /// </summary>
        void OpenWeaponDialog(WeaponDto initial, Action<WeaponDto> onResult);
    }

    /// <summary>
    /// Контракт представления для работы с кузнецами.
    /// </summary>
    public interface IBlacksmithView : IView
    {
        /// <summary>Возникает при запросе на загрузку списка кузнецов.</summary>
        event Action LoadBlacksmithsRequested;

        /// <summary>Возникает при запросе на добавление кузнеца.</summary>
        event Action<BlacksmithDto> AddBlacksmithRequested;

        /// <summary>Возникает при запросе на обновление данных кузнеца.</summary>
        event Action<BlacksmithDto> UpdateBlacksmithRequested;

        /// <summary>Возникает при запросе на удаление кузнеца.</summary>
        event Action<int> DeleteBlacksmithRequested;

        /// <summary>Возникает при запросе на поиск кузнецов по специализации и уровню.</summary>
        event Action<string, int> FindBlacksmithsRequested;

        /// <summary>Возникает при запросе на расчёт стоимости ковки.</summary>
        event Action<int, decimal> CalculateForgingPriceRequested;

        /// <summary>Возникает при запросе на получение кузнеца по ID.</summary>
        event Action<int> GetBlacksmithByIdRequested;

        /// <summary>
        /// Отображает список кузнецов в таблице.
        /// </summary>
        void ShowBlacksmiths(IEnumerable<BlacksmithDto> blacksmiths);

        /// <summary>
        /// Отображает результат расчёта стоимости ковки.
        /// </summary>
        void ShowForgingPrice(string name, decimal multiplier, decimal finalPrice);

        /// <summary>
        /// Открывает диалоговое окно для добавления/редактирования кузнеца.
        /// </summary>
        void OpenBlacksmithDialog(BlacksmithDto initial, Action<BlacksmithDto> onResult);
    }
}