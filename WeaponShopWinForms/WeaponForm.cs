
using Shared;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeaponShopModel;

namespace WeaponShopWinForms
{
   
        public partial class WeaponForm : Form, IWeaponView
        {
            public event Action LoadWeaponsRequested;
            public event Action<WeaponDto> AddWeaponRequested;
            public event Action<WeaponDto> UpdateWeaponRequested;
            public event Action<int> DeleteWeaponRequested;
            public event Action<int, decimal, decimal> RecommendWeaponsRequested;
            public event Action StatsRequested;
            public void ShowMessage(string message)
            {
               MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void ShowError(string message)
            {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        public WeaponForm()
            {
                InitializeComponent();
                Load += (s, e) => LoadWeaponsRequested?.Invoke();
            }

            // --- UI -> Presenter ---
            private void btnAdd_Click_2(object sender, EventArgs e)
            {
                OpenWeaponDialog(null, dto => AddWeaponRequested?.Invoke(dto));
            }

            private void btnEdit_Click(object sender, EventArgs e)
            {
                if (grid.CurrentRow?.DataBoundItem is WeaponDto selected)
                    OpenWeaponDialog(selected, dto => UpdateWeaponRequested?.Invoke(dto));
            }

            private void btnDelete_Click_1(object sender, EventArgs e)
            {
                if (grid.CurrentRow?.DataBoundItem is WeaponDto selected)
                {
                    if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        DeleteWeaponRequested?.Invoke(selected.Id);
                }
                else MessageBox.Show("Выберите оружие.", "Внимание");
            }

            private void btnEquip_Click_1(object sender, EventArgs e)
                => RecommendWeaponsRequested?.Invoke((int)UserS.Value, UserG.Value, 0);

            private void btnStats_Click_1(object sender, EventArgs e)
                => StatsRequested?.Invoke();

            private void btnReset_Click_1(object sender, EventArgs e)
                => LoadWeaponsRequested?.Invoke();

            private void button1_Click(object sender, EventArgs e) => Close();

            // --- Presenter -> UI ---
            public void ShowWeapons(IEnumerable<WeaponDto> weapons)
            {
                grid.DataSource = null;
                grid.DataSource = new List<WeaponDto>(weapons);
            }

            public void ShowRecommendations(IEnumerable<WeaponDto> weapons, int strength, decimal gold)
            {
                var list = new List<WeaponDto>(weapons);
                grid.DataSource = null;
                grid.DataSource = list;
                MessageBox.Show(
                    $"Сила: {strength}, Бюджет: {gold}\nНайдено: {list.Count}",
                    "Результат подбора");
            }

            public void ShowStatistics(IEnumerable<WeaponTypeStatDto> stats)
            {
                string report = "АНАЛИТИКА АРСЕНАЛА:\n\n";
                foreach (var s in stats)
                    report += $"{s.WeaponType} | Кол-во: {s.TotalCount} | Ср. урон: {s.AverageDamage} | Ср. цена: {s.AveragePrice}\n";
                MessageBox.Show(report, "Аналитика");
            }

     
            public void OpenWeaponDialog(WeaponDto initial, Action<WeaponDto> onResult)
            {
                // Конвертация DTO ↔ Weapon для диалога (диалог работает с доменным классом)
                var domain = initial == null ? null : new WeaponShopModel.Weapon
                {
                    Id = initial.Id,
                    Name = initial.Name,
                    WeaponType = initial.WeaponType,
                    Damage = initial.Damage,
                    RequiredStrength = initial.RequiredStrength,
                    Weight = initial.Weight,
                    Price = initial.Price,
                    Rarity = initial.Rarity
                };

                using (var dlg = new WeaponEditForm(domain))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var w = dlg.WeaponData;
                        onResult?.Invoke(new WeaponDto
                        {
                            Id = w.Id,
                            Name = w.Name,
                            WeaponType = w.WeaponType,
                            Damage = w.Damage,
                            RequiredStrength = w.RequiredStrength,
                            Weight = w.Weight,
                            Price = w.Price,
                            Rarity = w.Rarity
                        });
                    }
                }
            }

        }
    
}

