using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WeaponShopCore
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }           
        public string WeaponType { get; set; }       
        public int Damage { get; set; }            
        public int RequiredStrength { get; set; }    
        public double Weight { get; set; }          
        public decimal Price { get; set; }        
        public string Rarity { get; set; }          

        public override string ToString()
        {
            return $"[{Id}] {Name} ({Rarity} {WeaponType}) | Урон: {Damage} | Тр. силы: {RequiredStrength} | Вес: {Weight}кг | Цена: {Price} зол.";
        }
    }
}