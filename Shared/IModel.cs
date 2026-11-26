using System;
using System.Collections.Generic;
using Shared.Dto;

namespace Shared
{
    /// <summary>
    /// Контракт бизнес-логики (Модели).
    /// Предоставляет Presenter команды для изменения данных,
    /// запросы для получения данных и события о результатах операций.
    /// </summary>
    public interface IModel
    {
        // ========== События ==========
        event Action<IEnumerable<WeaponDto>> WeaponsLoaded;
        event Action<WeaponDto> WeaponAdded;
        event Action<WeaponDto> WeaponUpdated;
        event Action<int> WeaponDeleted;

        event Action<IEnumerable<BlacksmithDto>> BlacksmithsLoaded;
        event Action<BlacksmithDto> BlacksmithAdded;
        event Action<BlacksmithDto> BlacksmithUpdated;
        event Action<int> BlacksmithDeleted;

        event Action<string> ErrorOccurred;

        // ========== Команды для оружия ==========
        void LoadWeapons();
        void AddWeapon(WeaponDto dto);
        void UpdateWeapon(WeaponDto dto);
        void DeleteWeapon(int id);

        // ========== Команды для кузнецов ==========
        void LoadBlacksmiths();
        void AddBlacksmith(BlacksmithDto dto);
        void UpdateBlacksmith(BlacksmithDto dto);
        void DeleteBlacksmith(int id);

        // ========== Запросы (возвращают результат сразу) ==========
        IReadOnlyList<WeaponDto> GetWeapons();
        IReadOnlyList<WeaponDto> RecommendWeapons(int strength, decimal maxGold);
        IReadOnlyList<WeaponTypeStatDto> GetWeaponTypeStatistics();
        IReadOnlyList<BlacksmithDto> FindBlacksmiths(string spec, int minSkill);
        BlacksmithDto GetBlacksmithById(int id);
        decimal CalculateForgingPrice(decimal basePrice, int blacksmithId);

        /// <summary>
        /// Инициализирует базу данных начальными данными (если она пуста).
        /// </summary>
        void InitializeData();
    }
}