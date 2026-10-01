using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponShopModel;


namespace WeaponShopConsole
{
    internal class Program
    {
        private static Logic _armory = new Logic();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("ОРУЖЕЙНАЯ ЛАВКА 'ВЯЛЫЙ МЕЧ'");
                Console.WriteLine("1. Весь арсенал на складе");
                Console.WriteLine("2. Выковать новое оружие");
                Console.WriteLine("3. Перековать / Улучшить параметры");
                Console.WriteLine("4. Сдать оружие в утиль");
                Console.WriteLine("5. Подобрать снаряжение для воина (по силе и золоту)");
                Console.WriteLine("6. Аналитика арсенала по типам оружия");
                Console.WriteLine("0. Покинуть лавку");
                Console.Write("\nТвой выбор, путник: ");

                var ch = Console.ReadLine();
                switch (ch)
                {
                    case "1": ShowAllWeapons(); break;
                    case "2": ForgeWeapon(); break;
                    case "3": ReforgeWeapon(); break;
                    case "4": ScrapWeapon(); break;
                    case "5": EquipWarrior(); break;
                    case "6": ShowArmoryStats(); break;
                    case "0": return;
                    default: Console.WriteLine("Ошибка ввода..."); break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadLine();
            }
        }

        private static void ShowAllWeapons()
        {
            Console.WriteLine("\nТЕКУЩИЙ АССОРТИМЕНТ ОРУЖИЯ");
            var list = _armory.GetAll();
            if (list.Count == 0) Console.WriteLine("Склад пуст! Все раскупили.");


            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }

        private static void ForgeWeapon()
        {
            Console.WriteLine("\nКОВКА НОВОГО ОРУЖИЯ");
            var w = new Weapon();

            Console.Write("Название: ");
            w.Name = Console.ReadLine();

            while (true)
            {
                Console.Write("Тип оружия (Меч/Топор/Молот/Копье/Кинжал): ");
                string input = Console.ReadLine();

                if (input == "Меч" || input == "Топор" || input == "Молот" || input == "Копье" || input == "Кинжал")
                {
                    w.WeaponType = input;
                    break;
                }

                Console.WriteLine("Ошибка! Ведите тип оружия строго из списка\n");
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

                Console.WriteLine("Ошибка! Ведите редкость строго из списка\n");
            }

            Console.Write("Урон: ");
            w.Damage = int.Parse(Console.ReadLine());

            Console.Write("Требуемая сила воина: ");
            w.RequiredStrength = int.Parse(Console.ReadLine());

            Console.Write("Вес (кг): ");
            w.Weight = double.Parse(Console.ReadLine());

            Console.Write("Цена в золоте: ");
            w.Price = decimal.Parse(Console.ReadLine());

            _armory.Create(w);
            Console.WriteLine("Оружие успешно выковано и добавлено в лавку!");
            ShowAllWeapons();

        }

        private static void ReforgeWeapon()
        {
            Console.WriteLine("\n--- ПЕРЕКОВКА (ИЗМЕНЕНИЕ) ОРУЖИЯ ---");
            Console.Write("Введите ID оружия для изменения (или 0 для отмены): ");

            // Защита от дурака: если ввели букву или 0 — выходим
            if (!int.TryParse(Console.ReadLine(), out int id) || id == 0)
            {
                Console.WriteLine("Действие отменено. Возврат в главное меню.");
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
            Console.WriteLine("3. Изменить требуемую силу");
            Console.WriteLine("4. Изменить цену");
            Console.WriteLine("0. Ничего не менять (случайно нажал)");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write($"Текущее название: '{w.Name}'. Введите новое: ");
                    string newN = Console.ReadLine();
                    if (newN != "")
                    {
                        w.Name = newN;
                        _armory.Update(w);
                        Console.WriteLine("Название успешно обновлено!");
                    }
                    else
                    {
                        Console.WriteLine("Пустое имя! Изменения отменены.");
                    }
                    break;

                case "2":
                    Console.Write($"Текущий урон: {w.Damage}. Введите новый: ");
                    if (int.TryParse(Console.ReadLine(), out int newD) && newD > 0)
                    {
                        w.Damage = newD;
                        _armory.Update(w);
                        Console.WriteLine("Урон успешно обновлен!");
                    }
                    else
                    {
                        Console.WriteLine("Некорректное число! Урон не изменен.");
                    }
                    break;

                case "3":
                    Console.Write($"Текущая сила: {w.RequiredStrength}. Введите новую: ");
                    if (int.TryParse(Console.ReadLine(), out int newS) && newS >= 0)
                    {
                        w.RequiredStrength = newS;
                        _armory.Update(w);
                        Console.WriteLine("Требование к силе успешно обновлено!");
                    }
                    else
                    {
                        Console.WriteLine("Некорректное число! Сила не изменена.");
                    }
                    break;

                case "4":
                    Console.Write($"Текущая цена: {w.Price}. Введите новую цену: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newP) && newP >= 0)
                    {
                        w.Price = newP;
                        _armory.Update(w);
                        Console.WriteLine("Цена успешно обновлена!");
                    }
                    else
                    {
                        Console.WriteLine("Некорректная цена! Цена не изменена.");
                    }
                    break;

                case "0":
                    Console.WriteLine("Никаких изменений не внесено.");
                    break;

                default:
                    Console.WriteLine("Неверный пункт. Редактирование отменено.");
                    break;
            }
        }

        private static void ScrapWeapon()
        {
            ShowAllWeapons();
            Console.Write("\nВведите ID оружия для переплавки в лом: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (_armory.Delete(id))
                    Console.WriteLine("Оружие переплавлено и убрано из ассортимента.");
                else
                    Console.WriteLine("Оружие с таким ID не найдено.");
            }
        }

        private static void EquipWarrior()
        {
            Console.WriteLine("\nПОДБОР СНАРЯЖЕНИЯ ДЛЯ ВОИНА");
            Console.Write("Сила воина (характеристика): ");
            int str = int.Parse(Console.ReadLine());

            Console.Write("Сколько золота в кошельке: ");
            decimal gold = decimal.Parse(Console.ReadLine());

            var matches = _armory.RecommendWeapons(str, gold);

            Console.WriteLine($"\nДоступных к покупке и ношению клинков: {matches.Count}");
            foreach (var i in matches)
            {
                Console.WriteLine($"-> {i}");
            }
        }

        private static void ShowArmoryStats()
        {
            Console.WriteLine("\nАНАЛИТИКА АРСЕНАЛА ПО КАТЕГОРИЯМ");
            var stats = _armory.GetWeaponTypeStatistics();
            foreach (var i in stats)
            {
                Console.WriteLine($"Тип:{i.WeaponType}  Кол-во:{i.TotalCount}  Ср. урон:{i.AverageDamage}  Ср. цена:{i.AveragePrice} зол.");
            }
        }
    }
}
