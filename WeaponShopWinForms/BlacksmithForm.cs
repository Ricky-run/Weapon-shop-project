using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeaponShopModel;
using BusinessLogic;

namespace WeaponShopWinForms
{
    public partial class BlacksmithForm : Form
    {
        private Logic _armory;

        public BlacksmithForm(Logic armory)
        {
            InitializeComponent();
            _armory = armory;
            RefreshGrid();
        }

    
        private void RefreshGrid()
        {
            gridBlacksmiths.DataSource = null;
            gridBlacksmiths.DataSource = _armory.GetAllBlacksmiths();
        }


        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var b = new Blacksmith();

            using (var form = new BlacksmithEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    b = form.BlacksmithData;

                    var created = _armory.CreateBlacksmith(b);

                    if (created != null)
                    {
                        RefreshGrid();
                        MessageBox.Show("Кузнец успешно нанят!", "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введённые данные.", "Ошибка");
                    }
                }
            }
        }

        private void btnDelete_Click_2(object sender, EventArgs e)
        {
            if (gridBlacksmiths.CurrentRow != null &&
            gridBlacksmiths.CurrentRow.DataBoundItem is Blacksmith selected)
            {
                var result = MessageBox.Show(
                    $"Уволить кузнеца {selected.Name}?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (_armory.DeleteBlacksmith(selected.Id))
                    {
                        RefreshGrid();
                        MessageBox.Show("Кузнец уволен.", "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось уволить кузнеца.", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите кузнеца из таблицы!", "Внимание");
            }

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (gridBlacksmiths.CurrentRow != null &&
            gridBlacksmiths.CurrentRow.DataBoundItem is Blacksmith selected)
            {
                using (var form = new BlacksmithEditForm(selected))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (_armory.UpdateBlacksmith(form.BlacksmithData))
                        {
                            RefreshGrid();
                            MessageBox.Show("Данные кузнеца обновлены!", "Успех");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить данные.", "Ошибка");
                        }
                    }
                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string specialization = txtSpecialization.Text.Trim();
            int skill = (int)numSkill.Value;

            if (specialization != "Мечи" &&
                specialization != "Топоры" &&
                specialization != "Молоты" &&
                specialization != "Копья" &&
                specialization != "Кинжалы")
            {
                MessageBox.Show("Введите правильную специализацию.", "Ошибка");
                return;
            }

            var result = _armory.FindBlacksmiths(specialization, skill);

            gridBlacksmiths.DataSource = null;
            gridBlacksmiths.DataSource = result;

            MessageBox.Show($"Найдено кузнецов: {result.Count}", "Результат поиска");
        }

        private void btnPrice_Click_1(object sender, EventArgs e)
        {
            if (gridBlacksmiths.CurrentRow != null &&
          gridBlacksmiths.CurrentRow.DataBoundItem is Blacksmith selected)
            {
                decimal basePrice = numBasePrice.Value;

                decimal finalPrice = _armory.CalculateForgingPrice(
                    basePrice, selected.Id);

                MessageBox.Show(
                    $"Кузнец: {selected.Name}\n" +
                    $"Наценка: x{selected.PriceMultiplier}\n" +
                    $"Итоговая стоимость: {finalPrice} золота",
                    "Расчёт стоимости");
            }
            else
            {
                MessageBox.Show("Выберите кузнеца из таблицы!", "Внимание");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBlacksmithId.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID!");
                return;
            }

            var blacksmith = _armory.GetBlacksmithById(id);

            if (blacksmith == null)
            {
                MessageBox.Show("Кузнец не найден!");
                return;
            }

            gridBlacksmiths.DataSource = null;
            gridBlacksmiths.DataSource =
                new System.Collections.Generic.List<Blacksmith> { blacksmith };
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}


