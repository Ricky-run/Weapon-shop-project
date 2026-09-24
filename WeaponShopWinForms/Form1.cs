using System;
using System.Windows.Forms;
using WeaponShopCore;

namespace WeaponShopWinForms
{
    public partial class Form1 : Form
    {
        private Logic _armory = new Logic();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.Text = "Оружейная лавка 'Вялый Меч'";
            RefreshGrid();
        }
     

        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = _armory.GetAll();
        }

     

        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            using (var form = new WeaponEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _armory.Create(form.WeaponData);
                    RefreshGrid();
                    MessageBox.Show("Оружие успешно выковано и добавлено в лавку!", "Успех");
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null && grid.CurrentRow.DataBoundItem is Weapon selectedWeapon)
            {

                using (var form = new WeaponEditForm(selectedWeapon))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _armory.Update(form.WeaponData);
                        RefreshGrid();
                        MessageBox.Show("Оружие успешно перековано!", "Успех");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите оружие из таблицы для редактирования!", "Внимание");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null && grid.CurrentRow.DataBoundItem is Weapon selectedWeapon)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите переплавить '{selectedWeapon.Name}' в металлолом?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _armory.Delete(selectedWeapon.Id);
                    RefreshGrid();
                    MessageBox.Show("Оружие переплавлено и убрано из ассортимента.", "Успешно");
                }
            }
            else
            {
                MessageBox.Show("Выберите оружие для удаления!", "Внимание");
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnEquip_Click_1(object sender, EventArgs e)
        {

            int strength = (int)UserS.Value;
            decimal gold = UserG.Value;

            var matches = _armory.RecommendWeapons(strength, gold);

            grid.DataSource = null;
            grid.DataSource = matches;

            MessageBox.Show(
                "Поиск завершен!\n\n" +
                $"Проверено под силу: {strength}\n" +
                $"Бюджет: {gold} золотых\n\n" +
                $"Найдено подходящих вариантов в кузнице: {matches.Count} шт.",
                "Результат подбора"
            );
        }

        private void btnStats_Click_1(object sender, EventArgs e)
        {
            var stats = _armory.GetWeaponTypeStatistics();
            string report = "АНАЛИТИКА АРСЕНАЛА ПО КАТЕГОРИЯМ:\n\n";

            foreach (var i in stats)
            {
                report += $"Тип: {i.WeaponType} | Кол-во: {i.TotalCount} шт. | Ср. урон: {i.AverageDamage} | Ср. цена: {i.AveragePrice} зол.\n";
            }

            MessageBox.Show(report, "Аналитика кузницы");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}