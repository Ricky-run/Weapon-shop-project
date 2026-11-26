using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Shared;
using Shared.Dto;
using WeaponShopModel;

namespace BusinessLogic
{
    public class Logic : ILogic, IModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LogicFunctions _businessFunctions;

        public Logic(IUnitOfWork unitOfWork, LogicFunctions businessFunctions)
        {
            _unitOfWork = unitOfWork;
            _businessFunctions = businessFunctions;
        }

        // ============ События IModel ============
        public event Action<IEnumerable<WeaponDto>> WeaponsLoaded;
        public event Action<WeaponDto> WeaponAdded;
        public event Action<WeaponDto> WeaponUpdated;
        public event Action<int> WeaponDeleted;
        public event Action<IEnumerable<BlacksmithDto>> BlacksmithsLoaded;
        public event Action<BlacksmithDto> BlacksmithAdded;
        public event Action<BlacksmithDto> BlacksmithUpdated;
        public event Action<int> BlacksmithDeleted;
        public event Action<string> ErrorOccurred;

        // ============ ILogic (как было) ============
        public void InitializeData()
        {
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
            if (weapon == null || string.IsNullOrWhiteSpace(weapon.Name)) return null;
            _unitOfWork.Weapons.Add(weapon);
            _unitOfWork.Save();
            return weapon;
        }

        public List<Weapon> GetAll() => _unitOfWork.Weapons.ReadAll().ToList();
        public Weapon GetById(int id) => _unitOfWork.Weapons.ReadById(id);

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
            if (weapon == null) return false;
            _unitOfWork.Weapons.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        public List<Weapon> RecommendWeapons(int warriorStrength, decimal maxGold)
            => _businessFunctions.RecommendWeapons(GetAll(), warriorStrength, maxGold);

        public List<WeaponTypeStat> GetWeaponTypeStatistics()
            => _businessFunctions.GetWeaponTypeStatistics(GetAll());

        public List<Blacksmith> GetAllBlacksmiths() => _unitOfWork.Blacksmiths.ReadAll().ToList();

        public List<Blacksmith> FindBlacksmiths(string specialization, int minSkill)
            => _businessFunctions.FindBlacksmiths(GetAllBlacksmiths(), specialization, minSkill);

        public Blacksmith GetBlacksmithById(int id) => _unitOfWork.Blacksmiths.ReadById(id);

        public decimal CalculateForgingPrice(decimal basePrice, int blacksmithId)
            => _businessFunctions.CalculateForgingPrice(basePrice, GetBlacksmithById(blacksmithId));

        public Blacksmith CreateBlacksmith(Blacksmith blacksmith)
        {
            if (blacksmith == null || string.IsNullOrEmpty(blacksmith.Name)) return null;
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
            if (blacksmith == null) return false;
            _unitOfWork.Blacksmiths.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        // ============ IModel (явная реализация) ============
        // Оружие
        void IModel.LoadWeapons()
        {
            try { WeaponsLoaded?.Invoke(GetAll().Select(ToDto).ToList()); }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        void IModel.AddWeapon(WeaponDto dto)
        {
            try
            {
                var created = Create(ToDomain(dto));
                if (created == null) { ErrorOccurred?.Invoke("Некорректные данные оружия."); return; }
                WeaponAdded?.Invoke(ToDto(created));
            }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        void IModel.UpdateWeapon(WeaponDto dto)
        {
            try
            {
                if (Update(ToDomain(dto))) WeaponUpdated?.Invoke(dto);
                else ErrorOccurred?.Invoke("Не удалось обновить оружие.");
            }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        void IModel.DeleteWeapon(int id)
        {
            try
            {
                if (Delete(id)) WeaponDeleted?.Invoke(id);
                else ErrorOccurred?.Invoke("Оружие не найдено.");
            }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        IReadOnlyList<WeaponDto> IModel.GetWeapons() => GetAll().Select(ToDto).ToList();

        IReadOnlyList<WeaponDto> IModel.RecommendWeapons(int strength, decimal maxGold)
            => _businessFunctions.RecommendWeapons(GetAll(), strength, maxGold).Select(ToDto).ToList();

        IReadOnlyList<WeaponTypeStatDto> IModel.GetWeaponTypeStatistics()
            => _businessFunctions.GetWeaponTypeStatistics(GetAll())
                .Select(s => new WeaponTypeStatDto
                {
                    WeaponType = s.WeaponType,
                    TotalCount = s.TotalCount,
                    AverageDamage = s.AverageDamage,
                    AveragePrice = s.AveragePrice
                }).ToList();

        // Кузнецы
        void IModel.LoadBlacksmiths()
        {
            try { BlacksmithsLoaded?.Invoke(GetAllBlacksmiths().Select(ToDto).ToList()); }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        void IModel.AddBlacksmith(BlacksmithDto dto)
        {
            try
            {
                var created = CreateBlacksmith(ToDomain(dto));
                if (created == null) { ErrorOccurred?.Invoke("Некорректные данные кузнеца."); return; }
                BlacksmithAdded?.Invoke(ToDto(created));
            }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        void IModel.UpdateBlacksmith(BlacksmithDto dto)
        {
            try
            {
                if (UpdateBlacksmith(ToDomain(dto))) BlacksmithUpdated?.Invoke(dto);
                else ErrorOccurred?.Invoke("Не удалось обновить кузнеца.");
            }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        void IModel.DeleteBlacksmith(int id)
        {
            try
            {
                if (DeleteBlacksmith(id)) BlacksmithDeleted?.Invoke(id);
                else ErrorOccurred?.Invoke("Кузнец не найден.");
            }
            catch (Exception ex) { ErrorOccurred?.Invoke(ex.Message); }
        }

        IReadOnlyList<BlacksmithDto> IModel.FindBlacksmiths(string spec, int minSkill)
            => _businessFunctions.FindBlacksmiths(GetAllBlacksmiths(), spec, minSkill).Select(ToDto).ToList();

        BlacksmithDto IModel.GetBlacksmithById(int id)
        {
            var b = GetBlacksmithById(id);
            return b == null ? null : ToDto(b);
        }

        decimal IModel.CalculateForgingPrice(decimal basePrice, int blacksmithId)
            => _businessFunctions.CalculateForgingPrice(basePrice, GetBlacksmithById(blacksmithId));

        void IModel.InitializeData() => InitializeData();

        // ============ Конвертеры ============
        private static WeaponDto ToDto(Weapon w) => new WeaponDto { Id = w.Id, Name = w.Name, WeaponType = w.WeaponType, Damage = w.Damage, RequiredStrength = w.RequiredStrength, Weight = w.Weight, Price = w.Price, Rarity = w.Rarity };
        private static Weapon ToDomain(WeaponDto d) => new Weapon { Id = d.Id, Name = d.Name, WeaponType = d.WeaponType, Damage = d.Damage, RequiredStrength = d.RequiredStrength, Weight = d.Weight, Price = d.Price, Rarity = d.Rarity };
        private static BlacksmithDto ToDto(Blacksmith b) => new BlacksmithDto { Id = b.Id, Name = b.Name, Specialization = b.Specialization, SkillLevel = b.SkillLevel, PriceMultiplier = b.PriceMultiplier };
        private static Blacksmith ToDomain(BlacksmithDto d) => new Blacksmith { Id = d.Id, Name = d.Name, Specialization = d.Specialization, SkillLevel = d.SkillLevel, PriceMultiplier = d.PriceMultiplier };
    }
}
