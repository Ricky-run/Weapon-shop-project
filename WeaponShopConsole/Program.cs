using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using WeaponShopModel;

namespace WeaponShopConsole
{
    internal class Program
    {
        private static ILogic _armory;

        static void Main(string[] args)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("   ОРУЖЕЙНАЯ ЛАВКА «ВЯЛЫЙ МЕЧ»");
            Console.WriteLine("==================================");
            Console.WriteLine("Выберите технологию доступа к данным:");
            Console.WriteLine("1 - Entity Framework (Классическая ORM)");
            Console.WriteLine("2 - Dapper (Микро-ORM / Ручной SQL)");
            Console.Write("\nВаш выбор, путник: ");

            string choice = Console.ReadLine();
            bool useDapper = false;

            if (choice == "2")
            {
                useDapper = true;
            }

            _armory = new Logic(useDapper);

            while (true)
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine("   ОРУЖЕЙНАЯ ЛАВКА «ВЯЛЫЙ МЕЧ»");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Оружейная лавка");
                Console.WriteLine("2. Кузнечная мастерская");
                Console.WriteLine("0. Покинуть лавку");
                Console.Write("\nТвой выбор, путник: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        WeaponMenu();
                        break;

                    case "2":
                        BlacksmithMenu();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неизвестный пункт меню. Нажмите Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void WeaponMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== ОРУЖЕЙНАЯ ЛАВКА ===");
                Console.WriteLine("1. Весь арсенал на складе");
                Console.WriteLine("2. Выковать новое оружие");
                Console.WriteLine("3. Перековать / улучшить оружие");
                Console.WriteLine("4. Сдать оружие в утиль");
                Console.WriteLine("5. Подобрать снаряжение для воина");
                Console.WriteLine("6. Аналитика арсенала");
                Console.WriteLine("0. Назад");
                Console.Write("\nТвой выбор: ");

                switch (Console.ReadLine())
                {
                    case "1": ShowAllWeapons(); break;
                    case "2": ForgeWeapon(); break;
                    case "3": ReforgeWeapon(); break;
                    case "4": ScrapWeapon(); break;
                    case "5": EquipWarrior(); break;
                    case "6": ShowArmoryStats(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Неизвестный пункт меню.");
                        break;
                }

                Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }
        }

        private static void BlacksmithMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== КУЗНЕЧНАЯ МАСТЕРСКАЯ ===");
                Console.WriteLine("1. Список кузнецов");
                Console.WriteLine("2. Найти кузнеца по специализации");
                Console.WriteLine("3. Рассчитать стоимость ковки");
                Console.WriteLine("4. Нанять кузнеца");
                Console.WriteLine("5. Изменить данные кузнеца");
                Console.WriteLine("6. Уволить кузнеца");
                Console.WriteLine("0. Назад");
                Console.Write("\nТвой выбор: ");

                switch (Console.ReadLine())
                {
                    case "1": ShowAllBlacksmiths(); break;
                    case "2": FindBlacksmith(); break;
                    case "3": CalculateForgingPrice(); break;
                    case "4": HireBlacksmith(); break;
                    case "5": EditBlacksmith(); break;
                    case "6": FireBlacksmith(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Неизвестный пункт меню.");
                        break;
                }

                Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }
        }

        private static void ShowAllWeapons()
        {
            Console.WriteLine("\nТЕКУЩИЙ АССОРТИМЕНТ ОРУЖИЯ");
            var list = _armory.GetAll();
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Склад пуст! Все раскупили.");
                return;
            }

            foreach (var i in list)
            {
                Console.WriteLine($"ID: {i.Id} | {i.Name} ({i.WeaponType}) — Урон: {i.Damage}, Цена: {i.Price} зол. [Редкость: {i.Rarity}, Вес: {i.Weight}кг]");
            }
        }

        private static void ForgeWeapon()
        {
            Console.WriteLine("\nКОВКА НОВОГО ОРУЖИЯ");
            var w = new Weapon();

            while (true)
            {
                Console.Write("Название: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    w.Name = input.Trim();
                    break;
                }
                Console.WriteLine("Ошибка! Название не может быть пустым.\n");
            }

            while (true)
            {
                Console.Write("Тип оружия (Меч/Топор/Молот/Копье/Кинжал): ");
                string input = Console.ReadLine();

                if (input == "Меч" || input == "Топор" || input == "Молот" || input == "Копье" || input == "Кинжал")
                {
                    w.WeaponType = input;
                    break;
                }
                Console.WriteLine("Ошибка! Введите тип оружия строго из списка.\n");
            }

            while (true)
            {
                Console.Write("Редкость (Обычное/Редкое/Эпическое/Легендарное): ");
                string input = Console.ReadLine();

                if (input == "Обычное" || input == "Редкое" || input == "Эпическое" || input == "Легендарное")
                {
                    w.Rarity = input;
                    break;
                }
                Console.WriteLine("Ошибка! Введите редкость строго из списка.\n");
            }

            while (true)
            {
                Console.Write("Урон: ");
                if (int.TryParse(Console.ReadLine(), out int damage) && damage >= 0)
                {
                    w.Damage = damage;
                    break;
                }
                Console.WriteLine("Ошибка! Введите корректное положительное целое число для урона.\n");
            }

            while (true)
            {
                Console.Write("Требуемая сила воина: ");
                if (int.TryParse(Console.ReadLine(), out int strength) && strength >= 0)
                {
                    w.RequiredStrength = strength;
                    break;
                }
                Console.WriteLine("Ошибка! Введите корректное положительное целое число для силы.\n");
            }

            while (true)
            {
                Console.Write("Вес (кг): ");
                if (double.TryParse(Console.ReadLine(), out double weight) && weight >= 0)
                {
                    w.Weight = weight;
                    break;
                }
                Console.WriteLine("Ошибка! Введите корректное число для веса.\n");
            }

            while (true)
            {
                Console.Write("Цена в золоте: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                {
                    w.Price = price;
                    break;
                }
                Console.WriteLine("Ошибка! Введите корректное число для цены.\n");
            }

            _armory.Create(w);
            Console.WriteLine("Оружие успешно выковано и добавлено в лавку!");
            ShowAllWeapons();
        }

        private static void ReforgeWeapon()
        {
            Console.WriteLine("\n--- ПЕРЕКОВКА (ИЗМЕНЕНИЕ) ОРУЖИЯ ---");
            ShowAllWeapons();
            Console.Write("\nВведите ID оружия для изменения (или 0 для отмены): ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id == 0)
            {
                Console.WriteLine("Действие отменено. Возврат в меню.");
                return;
            }

            var w = _armory.GetById(id);
            if (w == null)
            {
                Console.WriteLine("Оружие с таким ID не найдено!");
                return;
            }

            Console.WriteLine($"\nВыбрано: {w.Name} (Урон: {w.Damage}, Сила: {w.RequiredStrength}, Цена: {w.Price})");
            Console.WriteLine("Что именно вы хотите изменить?");
            Console.WriteLine("1. Изменить название");
            Console.WriteLine("2. Изменить урон");
            Console.WriteLine("3. Изменить цену");
            Console.WriteLine("0. Ничего не менять");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write($"Текущее название: '{w.Name}'. Введите новое: ");
                    string newN = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newN))
                        
{
                        w.Name = newN.Trim();
                        _armory.Update(w);
                        Console.WriteLine("Название успешно обновлено!");
                    }
                    break;
                case "2":
                    while (true)
                    {
                        Console.Write($"Текущий урон: {w.Damage}. Введите новый: ");
                        if (int.TryParse(Console.ReadLine(), out int newD) && newD >= 0)
                        {
                            w.Damage = newD;
                            _armory.Update(w);
                            Console.WriteLine("Урон успешно обновлен!");
                            break;
                        }
                        Console.WriteLine("Ошибка! Введите положительное целое число.");
                    }
                    break;
                case "3":
                    while (true)
                    {
                        Console.Write($"Текущая цена: {w.Price}. Введите новую цену: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newP) && newP >= 0)
                        {
                            w.Price = newP;
                            _armory.Update(w);
                            Console.WriteLine("Цена успешно обновлена!");
                            break;
                        }
                        Console.WriteLine("Ошибка! Введите положительное число.");
                    }
                    break;
            }
        }
        private static void ScrapWeapon()
        {
            ShowAllWeapons();
            Console.Write("\nВведите ID оружия для переплавки в лом (или 0 для отмены): ");
            if (int.TryParse(Console.ReadLine(), out int id) && id != 0)
            {
                if (_armory.Delete(id))
                    Console.WriteLine("Оружие переплавлено и убрано из ассортимента.");
                else
                    Console.WriteLine("Оружие с таким ID не найдено.");
            }
            else
            {
                Console.WriteLine("Действие отменено.");
            }
        }
        private static void EquipWarrior()
        {
            Console.WriteLine("\nПОДБОР СНАРЯЖЕНИЯ ДЛЯ ВОИНА");
            int str;
            decimal gold;
            while (true)
            {
                Console.Write("Сила воина (характеристика): ");
                if (int.TryParse(Console.ReadLine(), out str) && str >= 0) break;
                Console.WriteLine("Ошибка! Введите положительное целое число.");
            }
            while (true)
            {
                Console.Write("Сколько золота в кошельке: ");
                if (decimal.TryParse(Console.ReadLine(), out gold) && gold >= 0) break;
                Console.WriteLine("Ошибка! Введите корректное число золота.");
            }
            var matches = _armory.RecommendWeapons(str, gold);
            if (matches == null || matches.Count == 0)
            {
                Console.WriteLine("\nНет подходящего оружия под эти характеристики.");
                return;
            }
            Console.WriteLine($"\nДоступных к покупке и ношению клинков: {matches.Count}");
            foreach (var i in matches)
            {
                Console.WriteLine($"-> {i.Name} ({i.WeaponType}) | Урон: {i.Damage} | Цена: {i.Price}");
            }
        }
        private static void ShowArmoryStats()
        {
            Console.WriteLine("\nАНАЛИТИКА АРСЕНАЛА ПО КАТЕГОРИЯМ");
            var stats = _armory.GetWeaponTypeStatistics();
            if (stats == null || stats.Count == 0)
            {
                Console.WriteLine("Статистика недоступна. База данных пуста.");
                return;
            }
            foreach (var i in stats)
            {
                Console.WriteLine($"Тип: {i.WeaponType} | Кол-во: {i.TotalCount} | Ср. урон: {i.AverageDamage} | Ср. цена: {i.AveragePrice} зол.");
            }
        }
        private static void ShowAllBlacksmiths()
        {
            Console.WriteLine("\nКУЗНЕЦЫ ОРУЖЕЙНОЙ ЛАВКИ");
            var blacksmiths = _armory.GetAllBlacksmiths();
            if (blacksmiths == null || blacksmiths.Count == 0)
            {
                Console.WriteLine("В лавке пока нет кузнецов.");
                return;
            }
            foreach (var b in blacksmiths)
            {
                Console.WriteLine($"ID: {b.Id} | {b.Name} — Специализация: {b.Specialization} [Уровень: {b.SkillLevel}, Наценка: x{b.PriceMultiplier}]");
            }
        }
        private static void FindBlacksmith()
        {
            Console.WriteLine("\nПОИСК КУЗНЕЦА");
            string specialization;
            while (true)
            {
                Console.Write("Специализация (Мечи/Топоры/Молоты/Копья/Кинжалы): ");
                specialization = Console.ReadLine();
                if (specialization == "Мечи" || specialization == "Топоры" || specialization == "Молоты" || specialization == "Копья" || specialization == "Кинжалы")
                    break;
                Console.WriteLine("Такой специализации нет! Введите строго из списка.");
            }
            int skill;
            while (true)
            {
                Console.Write("Минимальный уровень мастерства: ");
                if (int.TryParse(Console.ReadLine(), out skill) && skill >= 0)
                    break;
                Console.WriteLine("Введите целое число не меньше 0!");
            }
            
                var result = _armory.FindBlacksmiths(specialization, skill);
                if (result == null || result.Count == 0)
                {
                    Console.WriteLine("Подходящие кузнецы не найдены.");
                    return;
                }
                Console.WriteLine("\nНайденные кузнецы:");
                foreach (var b in result)
                {
                    Console.WriteLine($"ID: {b.Id} | {b.Name} ({b.Specialization}) мастер: {b.SkillLevel}");
                }
            }
            
        
        private static void CalculateForgingPrice()
        {
            Console.WriteLine("\nРАСЧЕТ СТОИМОСТИ КОВКИ");
            ShowAllBlacksmiths();
            int id;
            while (true)
            {
                Console.Write("\nВведите ID кузнеца: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0) break;
                Console.WriteLine("Ошибка! ID должен быть положительным числом.");
            }
            decimal basePrice;
            while (true)
            {
                Console.Write("Базовая стоимость ковки: ");
                if (decimal.TryParse(Console.ReadLine(), out basePrice) && basePrice >= 0) break;
                Console.WriteLine("Ошибка! Стоимость не может быть отрицательной.");
            }
            try
            {
                var blacksmith = _armory.GetBlacksmithById(id);
                if (blacksmith == null)
                {
                    Console.WriteLine("Кузнец с таким ID не существует.");
                    return;
                }
                decimal finalPrice = _armory.CalculateForgingPrice(basePrice, id);
                Console.WriteLine($"Кузнец: {blacksmith.Name}");
                Console.WriteLine($"Итоговая стоимость: {finalPrice} золота");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void HireBlacksmith()
        {
            Console.WriteLine("\nНАЙМ КУЗНЕЦА");
            var blacksmith = new Blacksmith();
            while (true)
            {
                Console.Write("Имя кузнеца: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    blacksmith.Name = input.Trim();
                    break;
                }
                Console.WriteLine("Ошибка! Имя не может быть пустым.");
            }
            while (true)
            {
                Console.Write("Специализация (Мечи/Топоры/Молоты/Копья/Кинжалы): ");
                string spec = Console.ReadLine();
                if (spec == "Мечи" || spec == "Топоры" || spec == "Молоты" || spec == "Копья" || spec == "Кинжалы")
                {
                    blacksmith.Specialization = spec;
                    break;
                }
                Console.WriteLine("Ошибка! Выберите специализацию строго из вариантов.");
            }
            while (true)
            {
                Console.Write("Уровень мастерства: ");
                if (int.TryParse(Console.ReadLine(), out int skill) && skill >= 0)
                {
                    blacksmith.SkillLevel = skill;
                    break;
                }
                Console.WriteLine("Ошибка! Уровень мастерства должен быть положительным целым числом.");
            }
            while (true)
            {
                Console.Write("Коэффициент наценки (например, 1.2): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal mult) && mult >= 0)
                {
                    blacksmith.PriceMultiplier = mult;
                    break;
                }
                Console.WriteLine("Ошибка! Введите корректное дробное или целое число.");
            }
            var created = _armory.CreateBlacksmith(blacksmith);
            if (created != null)
            {
                Console.WriteLine($"Кузнец {created.Name} принят на работу! ID: {created.Id}");
            }
            else
            {
                Console.WriteLine("Не удалось нанять кузнеца. Ошибка валидации в логике.");
            }
        }
        private static void EditBlacksmith()
        {
            Console.WriteLine("\nИЗМЕНЕНИЕ ДАННЫХ КУЗНЕЦА");
            ShowAllBlacksmiths();
            Console.Write("\nВведите ID кузнеца: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ID.");
                return;
            }
            var b = _armory.GetBlacksmithById(id);
            if (b == null)
            {
                Console.WriteLine("Кузнец не найден.");
                return;
            }
            Console.Write($"Новое имя ({b.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) b.Name = name.Trim();
            while (true)
            {
                Console.Write($"Новая специализация ({b.Specialization}) [Оставьте пустым для отмены]: ");
                string spec = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(spec)) break;
                if (spec == "Мечи" || spec == "Топоры" || spec == "Молоты" || spec == "Копья" || spec == "Кинжалы")
                {
                    b.Specialization = spec;
                    break;
                }
                Console.WriteLine("Ошибка! Специализация должна быть строго из списка (Мечи/Топоры/Молоты/Копья/Кинжалы).");
            }
            _armory.UpdateBlacksmith(b);
            Console.WriteLine("Данные кузнеца обновлены.");
        }
        private static void FireBlacksmith()
        {
            Console.WriteLine("\nУВОЛЬНЕНИЕ КУЗНЕЦА");
            ShowAllBlacksmiths();
            Console.Write("\nВведите ID кузнеца для увольнения (или 0 для отмены): ");
            if (int.TryParse(Console.ReadLine(), out int id) && id != 0)
            {
                if (_armory.DeleteBlacksmith(id))
                    Console.WriteLine("Кузнец уволен.");
                else
                    Console.WriteLine("Кузнец с таким ID не найден.");
            }
            else
            {
                Console.WriteLine("Действие отменено.");
            }
        }
    }
}