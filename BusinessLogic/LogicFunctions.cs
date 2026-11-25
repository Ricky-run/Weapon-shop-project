using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponShopModel;

namespace BusinessLogic
{
    public class LogicFunctions
    {
     
        public List<Weapon> RecommendWeapons(IEnumerable<Weapon> allWeapons, int warriorStrength, decimal maxGold)
        {
            return allWeapons
                .Where(w => w.RequiredStrength <= warriorStrength && w.Price <= maxGold)
                .OrderByDescending(w => w.Damage)
                .ToList();
        }

    
        public List<WeaponTypeStat> GetWeaponTypeStatistics(IEnumerable<Weapon> allWeapons)
        {
            var result = new List<WeaponTypeStat>();
            var groups = allWeapons.GroupBy(w => w.WeaponType);

            foreach (var group in groups)
            {
                var stat = new WeaponTypeStat
                {
                    WeaponType = group.Key,
                    TotalCount = group.Count(),
                    AverageDamage = Math.Round(group.Average(w => w.Damage), 1),
                    AveragePrice = Math.Round(group.Average(w => w.Price), 2)
                };
                result.Add(stat);
            }
            return result;
        }

        
        public decimal CalculateForgingPrice(decimal basePrice, Blacksmith blacksmith)
        {
            if (blacksmith == null)
                throw new ArgumentException("Кузнец не найден!");

            return basePrice * blacksmith.PriceMultiplier;
        }

        public List<Blacksmith> FindBlacksmiths(IEnumerable<Blacksmith> allBlacksmiths, string specialization, int minSkill)
        {
            return allBlacksmiths
                .Where(b => b.Specialization == specialization && b.SkillLevel >= minSkill)
                .ToList();
        }
    }
}


