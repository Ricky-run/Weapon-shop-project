using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeaponShopCore
{
    public class Logic : ILogic
    {
        private readonly List<Weapon> _weapons = new List<Weapon>();
        private int _nextId = 1;

        public Logic()
        {
            
            Create(new Weapon { Name = "Двуручник Паладина", WeaponType = "Меч", Damage = 85, RequiredStrength = 40, Weight = 4.5, Price = 1200, Rarity = "Эпическое" });
            Create(new Weapon { Name = "Секира Кровавого Прилива", WeaponType = "Топор", Damage = 110, RequiredStrength = 55, Weight = 6.0, Price = 1800, Rarity = "Легендарное" });
            Create(new Weapon { Name = "Пехотное копье стражи", WeaponType = "Копье", Damage = 45, RequiredStrength = 20, Weight = 2.8, Price = 250, Rarity = "Обычное" });
            Create(new Weapon { Name = "Орочий Тесак", WeaponType = "Меч", Damage = 55, RequiredStrength = 25, Weight = 3.2, Price = 400, Rarity = "Редкое" });
            Create(new Weapon { Name = "Молот Громовержца", WeaponType = "Молот", Damage = 130, RequiredStrength = 65, Weight = 9.0, Price = 2500, Rarity = "Легендарное" });
            Create(new Weapon { Name = "Охотничий кинжал", WeaponType = "Кинжал", Damage = 25, RequiredStrength = 10, Weight = 0.8, Price = 90, Rarity = "Обычное" });
        }
        
        
        public Weapon Create(Weapon weapon)
        {
            if (weapon == null || weapon.Name == "")
            {
                return null;
            }

            weapon.Id = _nextId++;
            _weapons.Add(weapon);
            return weapon;
        }
       
        public List<Weapon> GetAll()
        {
            return new List<Weapon>(_weapons);
        }

        
        public Weapon GetById(int id)
        {
            return _weapons.FirstOrDefault(w => w.Id == id);
        }

        
        public bool Update(Weapon updatedWeapon)
        {
            if (updatedWeapon == null) return false;

            var existing = GetById(updatedWeapon.Id);
            if (existing == null) return false;

            existing.Name = updatedWeapon.Name;
            existing.WeaponType = updatedWeapon.WeaponType;
            existing.Damage = updatedWeapon.Damage;
            existing.RequiredStrength = updatedWeapon.RequiredStrength;
            existing.Weight = updatedWeapon.Weight;
            existing.Price = updatedWeapon.Price;
            existing.Rarity = updatedWeapon.Rarity;

            return true;
        }
        
        public bool Delete(int id)
        {
            var weapon = GetById(id);
            if (weapon != null)
            {
                return _weapons.Remove(weapon);
            }
            return false;
        }




        //БИЗНЕС-ФУНКЦИИ        
        public List<Weapon> RecommendWeapons(int warriorStrength, decimal maxGold)
        {
            return _weapons
                .Where(w => w.RequiredStrength <= warriorStrength && w.Price <= maxGold)
                .OrderByDescending(w => w.Damage)
                .ToList();
        }


        
        public List<WeaponTypeStat> GetWeaponTypeStatistics()
        {
            var result = new List<WeaponTypeStat>();
            var groups = _weapons.GroupBy(w => w.WeaponType);


            foreach (var group in groups)
            {
                var stat = new WeaponTypeStat();
                stat.WeaponType = group.Key;
                stat.TotalCount = group.Count();
                stat.AverageDamage = Math.Round(group.Average(w => w.Damage), 1);
                stat.AveragePrice = Math.Round(group.Average(w => w.Price),2);

                result.Add(stat);
            }

            return result;
        }
    }
}