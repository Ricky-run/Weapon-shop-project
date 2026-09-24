using System;
using System.Windows.Forms;
using WeaponShopCore;

namespace WeaponShopWinForms
{
    public partial class Form1 : Form
    {
        private Logic _armory = new Logic();
        private DataGridView grid;

        public Form1()
        {
            InitializeComponent();
            InitializeManualUI();
            RefreshGrid();
        }

        private void InitializeManualUI()
        {
            this.Text = "Оружейная лавка 'Стальной Клык' (WinForms)";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Таблица арсенала
            grid = new DataGridView
            {
                Top = 20,
                Left = 20,
                Width = 710,
                Height = 430,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Кнопки CRUD
            var btnAdd = new Button { Text = "⚔️ Выковать (Создать)", Top = 20, Left = 750, Width = 160, Height = 35 };
            btnAdd.Click += (s, e) => AddWeapon();

            var btnEdit = new Button { Text = "🔨 Перековать (Изменить)", Top = 65, Left = 750, Width = 160, Height = 35 };
            btnEdit.Click += (s, e) => EditWeapon();

            var btnDelete = new Button { Text = "🗑️ В утиль (Удалить)", Top = 110, Left = 750, Width = 160, Height = 35 };
            btnDelete.Click += (s, e) => DeleteWeapon();

            var btnReset = new Button { Text = "Сброс / Весь склад", Top = 155, Left = 750, Width = 160, Height = 35 };
            btnReset.Click += (s, e) => RefreshGrid();

            // Кнопки бизнес-функций
            var btnEquip = new Button { Text = "🛡️ Подобрать экипировку", Top = 230, Left = 750, Width = 160, Height = 45 };
            btnEquip.Click += BtnEquip_Click;

            var btnStats = new Button { Text = "📊 Анализ категорий", Top = 290, Left = 750, Width = 160, Height = 45 };
            btnStats.Click += BtnStats_Click;

            this.Controls.AddRange(new Control[] { grid, btnAdd, btnEdit, btnDelete, btnReset, btnEquip, btnStats });
        }

        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = _armory.GetAll();
        }

        private void AddWeapon()
        {
            using (var form = new WeaponEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _armory.Create(form.WeaponData);
                    RefreshGrid();
                }
            }
        }

        private void EditWeapon()
        {
            if (grid.CurrentRow?.DataBoundItem is Weapon selected)
            {
                using (var form = new WeaponEditForm(selected))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _armory.Update(form.WeaponData);
                        RefreshGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите оружие из списка!");
            }
        }

        private void DeleteWeapon()
        {
            if (grid.CurrentRow?.DataBoundItem is Weapon selected)
            {
                var ans = MessageBox.Show($"Переплавить '{selected.Name}' в лом?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    _armory.Delete(selected.Id);
                    RefreshGrid();
                }
            }
        }

        private void BtnEquip_Click(object sender, EventArgs e)
        {
            int strength = 35;
            decimal gold = 1500;

            var matches = _armory.RecommendWeapons(strength, gold);
            grid.DataSource = null;
            grid.DataSource = matches;

            MessageBox.Show($"Найдено вариантов под параметры (Сила: {strength}, Золото: {gold}): {matches.Count}", "Подбор экипировки");
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {
            var stats = _armory.GetWeaponTypeStatistics();
            string msg = "📊 Сводка арсенала по типам оружия:\n\n";
            foreach (var s in stats)
            {
                msg += $"• {s.WeaponType}: {s.TotalCount} шт. | Ср. урон: {s.AverageDamage} | Ср. цена: {s.AveragePrice} зол.\n";
            }
            MessageBox.Show(msg, "Аналитика кузницы");
        }
    }
}