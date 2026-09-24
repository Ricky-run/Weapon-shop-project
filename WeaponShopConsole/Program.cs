using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponShopCore;


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
                Console.WriteLine("2. Выковать новое оружие (Создать)");
                Console.WriteLine("3. Перековать / Улучшить параметры (Изменить)");
                Console.WriteLine("4. Сдать оружие в утиль (Удалить)");
                Console.WriteLine("5. [Бизнес-функция 1] Подобрать снаряжение для воина (по силе и золоту)");
                Console.WriteLine("6. [Бизнес-функция 2] Аналитика арсенала по типам оружия");
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

                Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }
        }

        private static void ShowAllWeapons()
        {
            Console.WriteLine("\n--- ТЕКУЩИЙ АССОРТИМЕНТ ОРУЖИЯ ---");
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
        }

        private static void ReforgeWeapon()
        {
            Console.Write("\nВведите ID оружия для перековки: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var w = _armory.GetById(id);
                if (w == null)
                {
                    Console.WriteLine("Оружие с таким ID не найдено!");
                    return;
                }

                Console.WriteLine($"Перековываем '{w.Name}'. Нажмите Enter, чтобы оставить старое значение.");

                Console.Write($"Новое название [{w.Name}]: ");
                string name = Console.ReadLine();

                if (name != "")  {w.Name = name; }


                Console.Write($"Новый урон [{w.Damage}]: ");
                string dmg = Console.ReadLine();
                if (int.TryParse(dmg, out int d)) w.Damage = d;

                Console.Write($"Новая цена [{w.Price}]: ");
                string price = Console.ReadLine();


                if (decimal.TryParse(price, out decimal p)) w.Price = p;

                _armory.Update(w);
                Console.WriteLine("Оружие успешно перековано!");
            }
        }

        private static void ScrapWeapon()
        {
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
