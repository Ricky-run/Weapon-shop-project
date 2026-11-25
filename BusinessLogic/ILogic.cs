using System.Collections.Generic;
using WeaponShopModel;

namespace BusinessLogic
{
    /// <summary>
    /// Контракт бизнес-логики оружейной лавки.
    /// Описывает все доступные операции без их внутренней реализации.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Добавляет новое оружие в арсенал.
        /// </summary>
        /// <param name="weapon">Новое оружие.</param>
        /// <returns>Созданное оружие с id.</returns>
        Weapon Create(Weapon weapon);

        /// <summary>
        /// Возвращает весь список оружия.
        /// </summary>
        /// <returns>Список всех записей.</returns> 
        List<Weapon> GetAll();

        /// <summary>
        /// Поиск оружия по его id.
        /// </summary>
        /// <param name="id">id оружия.</param>
        /// <returns>Найденное оружие или null, если не найдено.</returns>
        Weapon GetById(int id);

        /// <summary>
        /// Обновляет параметры оружия по его id.
        /// </summary>
        /// <param name="updatedWeapon">Оружие с обновленными полями.</param>
        /// <returns>True, если запись обновлена, иначе false.</returns>
        bool Update(Weapon updatedWeapon);

        /// <summary>
        /// Удаляет оружие из списка по id.
        /// </summary>
        /// <param name="id">id удаляемого оружия.</param>
        /// <returns>True, если удаление прошло успешно, иначе false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Фильтрует оружие по силе воина и золоту с сортировкой по урону.
        /// </summary>
        /// <param name="warriorStrength">Сила воина.</param>
        /// <param name="maxGold">Бюджет в золоте.</param>
        /// <returns>Подходящее оружие от большего урона к меньшему.</returns>
        List<Weapon> RecommendWeapons(int warriorStrength, decimal maxGold);

        /// <summary>
        /// Группирует оружие по категориям и считает средний урон и цену.
        /// </summary>
        /// <returns>Список статистики по каждому типу оружия.</returns>
        /// <summary>
        /// Группирует оружие по категориям и считает средний урон и цену.
        /// </summary>
        /// <returns>Список статистики по каждому типу оружия.</returns>
        List<WeaponTypeStat> GetWeaponTypeStatistics();

        /// <summary>
        /// Возвращает полный список кузнецов.
        /// </summary>
        /// <returns>Список всех кузнецов.</returns>
        List<Blacksmith> GetAllBlacksmiths();

        /// <summary>
        /// Находит кузнецов по специализации и минимальному уровню мастерства.
        /// </summary>
        /// <param name="specialization">Специализация кузнеца (например, "Меч", "Топор").</param>
        /// <param name="minSkill">Минимальный уровень мастерства.</param>
        /// <returns>Список подходящих кузнецов.</returns>
        List<Blacksmith> FindBlacksmiths(string specialization, int minSkill);

        /// <summary>
        /// Возвращает кузнеца по его id.
        /// </summary>
        /// <param name="id">id кузнеца.</param>
        /// <returns>Найденный кузнец или null, если не найден.</returns>
        Blacksmith GetBlacksmithById(int id);

        /// <summary>
        /// Рассчитывает цену ковки с учетом наценки кузнеца.
        /// </summary>
        /// <param name="basePrice">Базовая стоимость предмета.</param>
        /// <param name="blacksmithId">id кузнеца, выполняющего работу.</param>
        /// <returns>Итоговая стоимость ковки.</returns>
        decimal CalculateForgingPrice(decimal basePrice, int blacksmithId);

        /// <summary>
        /// Добавляет нового кузнеца в список.
        /// </summary>
        /// <param name="blacksmith">Новый кузнец.</param>
        /// <returns>Созданный кузнец с id.</returns>
        Blacksmith CreateBlacksmith(Blacksmith blacksmith);

        /// <summary>
        /// Обновляет данные кузнеца.
        /// </summary>
        /// <param name="blacksmith">Кузнец с обновленными полями.</param>
        /// <returns>True, если запись обновлена, иначе false.</returns>
        bool UpdateBlacksmith(Blacksmith blacksmith);

        /// <summary>
        /// Удаляет кузнеца по его id.
        /// </summary>
        /// <param name="id">id удаляемого кузнеца.</param>
        /// <returns>True, если удаление прошло успешно, иначе false.</returns>
        bool DeleteBlacksmith(int id);

        /// <summary>
        /// Инициализирует базу данных начальными данными (если она пуста).
        /// </summary>
        void InitializeData();
    }
}