using System.Data.Entity;
using WeaponShopModel;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("WeaponShopConnection")
        {

        }

        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Blacksmith> Blacksmiths { get; set; }
    }
}