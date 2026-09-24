using System.Collections.Generic;

namespace WeaponShopCore
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
        /// /// <param name="weapon">Новое оружие.</param>
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
        List<WeaponTypeStat> GetWeaponTypeStatistics();
    }
}