using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponShopModel;

namespace WeaponShopModel
{
    /// <summary>
    /// Вторая сущность: Мастер-кузнец лавки.
    /// </summary>
    public class Blacksmith : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int SkillLevel { get; set; }
        public decimal PriceMultiplier { get; set; }

        public override string ToString()
        {
            return $"[{Id}] Кузнец {Name} (Спец: {Specialization}, Мастерство: {SkillLevel} ур., Наценка: x{PriceMultiplier})";
        }
    }
}