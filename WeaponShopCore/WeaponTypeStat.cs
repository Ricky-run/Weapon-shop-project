using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponShopCore
{
    public class WeaponTypeStat
    {
        public string WeaponType { get; set; }
        public int TotalCount { get; set; }
        public double AverageDamage { get; set; }
        public decimal AveragePrice { get; set; }
    }
}