namespace Shared.Dto
{
    public class WeaponDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeaponType { get; set; }
        public int Damage { get; set; }
        public int RequiredStrength { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public string Rarity { get; set; }
    }
}