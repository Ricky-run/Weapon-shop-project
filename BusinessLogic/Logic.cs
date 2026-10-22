using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using WeaponShopModel;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public Logic(bool useDapper = false)
        {
            
            _unitOfWork = new UnitOfWork(useDapper);

            if (!_unitOfWork.Weapons.ReadAll().Any())
            {
                Create(new Weapon { Name = "Двуручник Паладина", WeaponType = "Меч", Damage = 85, RequiredStrength = 40, Weight = 4.5, Price = 1200, Rarity = "Эпическое" });
                Create(new Weapon { Name = "Секира Кровавого Прилива", WeaponType = "Топор", Damage = 110, RequiredStrength = 55, Weight = 6.0, Price = 1800, Rarity = "Легендарное" });
                Create(new Weapon { Name = "Пехотное копье стражи", WeaponType = "Копье", Damage = 45, RequiredStrength = 20, Weight = 2.8, Price = 250, Rarity = "Обычное" });
                Create(new Weapon { Name = "Орочий Тесак", WeaponType = "Меч", Damage = 55, RequiredStrength = 25, Weight = 3.2, Price = 400, Rarity = "Редкое" });
                Create(new Weapon { Name = "Молот Громовержца", WeaponType = "Молот", Damage = 130, RequiredStrength = 65, Weight = 9.0, Price = 2500, Rarity = "Легендарное" });
                Create(new Weapon { Name = "Охотничий кинжал", WeaponType = "Кинжал", Damage = 25, RequiredStrength = 10, Weight = 0.8, Price = 90, Rarity = "Обычное" });
            }
        }
        public Weapon Create(Weapon weapon)
        {
            if (weapon == null || weapon.Name == "")
            {
                return null;
            }

            _unitOfWork.Weapons.Add(weapon);
            _unitOfWork.Save();

            return weapon;
        }

        public List<Weapon> GetAll()
        {
            return _unitOfWork.Weapons.ReadAll().ToList();
        }

        public Weapon GetById(int id)
        {
            return _unitOfWork.Weapons.ReadById(id);
        }


        public bool Update(Weapon updatedWeapon)
        {
            if (updatedWeapon == null) return false;

            _unitOfWork.Weapons.Update(updatedWeapon);
            _unitOfWork.Save();

            return true;
        }

        public bool Delete(int id)
        {
            var weapon = GetById(id);
            if (weapon != null)
            {

                _unitOfWork.Weapons.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }


        public List<Weapon> RecommendWeapons(int warriorStrength, decimal maxGold)
        {

            return GetAll().Where(w => w.RequiredStrength <= warriorStrength && w.Price <= maxGold).OrderByDescending(w => w.Damage).ToList();
        }

        public List<WeaponTypeStat> GetWeaponTypeStatistics()
        {
            var result = new List<WeaponTypeStat>();

            var groups = GetAll().GroupBy(w => w.WeaponType);

            foreach (var group in groups)
            {
                var stat = new WeaponTypeStat();
                stat.WeaponType = group.Key;
                stat.TotalCount = group.Count();
                stat.AverageDamage = Math.Round(group.Average(w => w.Damage), 1);
                stat.AveragePrice = Math.Round(group.Average(w => w.Price), 2);

                result.Add(stat);
            }

            return result;
        }
        public List<Blacksmith> GetAllBlacksmiths()
        {
            return _unitOfWork.Blacksmiths.ReadAll().ToList();
        }

        public List<Blacksmith> FindBlacksmiths(string specialization, int minSkill)
        {
            return GetAllBlacksmiths().Where(b => b.Specialization == specialization && b.SkillLevel >= minSkill).ToList();
        }

        public Blacksmith GetBlacksmithById(int id)
        {
            return _unitOfWork.Blacksmiths.ReadById(id);
        }

        public decimal CalculateForgingPrice(decimal basePrice, int blacksmithId)
        {
            var blacksmith = GetBlacksmithById(blacksmithId);
            if (blacksmith == null)
            {
                throw new ArgumentException("Кузнец с таким ID не найден!");
            }

            return basePrice * blacksmith.PriceMultiplier;
        }

        public Blacksmith CreateBlacksmith(Blacksmith blacksmith)
        {
            if (blacksmith == null || string.IsNullOrEmpty(blacksmith.Name))
            {
                return null;
            }

            _unitOfWork.Blacksmiths.Add(blacksmith);
            _unitOfWork.Save();
            return blacksmith;
        }

        public bool UpdateBlacksmith(Blacksmith blacksmith)
        {
            if (blacksmith == null) return false;

            _unitOfWork.Blacksmiths.Update(blacksmith);
            _unitOfWork.Save();
            return true;
        }

        public bool DeleteBlacksmith(int id)
        {
            var blacksmith = GetBlacksmithById(id);
            if (blacksmith != null)
            {
                _unitOfWork.Blacksmiths.Delete(id);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
