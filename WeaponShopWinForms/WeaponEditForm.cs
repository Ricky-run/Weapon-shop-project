using System;
using System.Windows.Forms;
using WeaponShopCore;

namespace WeaponShopWinForms
{
    public partial class WeaponEditForm : Form
    {
        public Weapon WeaponData { get; private set; }

        private TextBox txtName;
        private TextBox txtType;
        private TextBox txtRarity;
        private NumericUpDown numDamage;
        private NumericUpDown numStrength;
        private NumericUpDown numWeight;
        private NumericUpDown numPrice;
        private Button btnSave;

        public WeaponEditForm(Weapon weaponToEdit = null)
        {
            BuildInterface();

            if (weaponToEdit != null)
            {
                Text = "Перековка оружия (Редактирование)";
                WeaponData = new Weapon
                {
                    Id = weaponToEdit.Id,
                    Name = weaponToEdit.Name,
                    WeaponType = weaponToEdit.WeaponType,
                    Rarity = weaponToEdit.Rarity,
                    Damage = weaponToEdit.Damage,
                    RequiredStrength = weaponToEdit.RequiredStrength,
                    Weight = weaponToEdit.Weight,
                    Price = weaponToEdit.Price
                };

                txtName.Text = WeaponData.Name;
                txtType.Text = WeaponData.WeaponType;
                txtRarity.Text = WeaponData.Rarity;
                numDamage.Value = WeaponData.Damage;
                numStrength.Value = WeaponData.RequiredStrength;
                numWeight.Value = (decimal)WeaponData.Weight;
                numPrice.Value = WeaponData.Price;
            }
            else
            {
                Text = "Ковка нового оружия";
                WeaponData = new Weapon();
            }
        }

        private void BuildInterface()
        {
            this.Size = new System.Drawing.Size(380, 420);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            var lbl1 = new Label { Text = "Название:", Top = 20, Left = 20, Width = 110 };
            txtName = new TextBox { Top = 20, Left = 140, Width = 190 };

            var lbl2 = new Label { Text = "Тип оружия:", Top = 60, Left = 20, Width = 110 };
            txtType = new TextBox { Top = 60, Left = 140, Width = 190 };

            var lbl3 = new Label { Text = "Редкость:", Top = 100, Left = 20, Width = 110 };
            txtRarity = new TextBox { Top = 100, Left = 140, Width = 190, Text = "Обычное" };

            var lbl4 = new Label { Text = "Базовый урон:", Top = 140, Left = 20, Width = 110 };
            numDamage = new NumericUpDown { Top = 140, Left = 140, Width = 80, Minimum = 1, Maximum = 1000, Value = 50 };

            var lbl5 = new Label { Text = "Тр. сила:", Top = 180, Left = 20, Width = 110 };
            numStrength = new NumericUpDown { Top = 180, Left = 140, Width = 80, Minimum = 1, Maximum = 150, Value = 25 };

            var lbl6 = new Label { Text = "Вес (кг):", Top = 220, Left = 20, Width = 110 };
            numWeight = new NumericUpDown { Top = 220, Left = 140, Width = 80, DecimalPlaces = 1, Minimum = 0.1m, Maximum = 50m, Value = 3.5m };

            var lbl7 = new Label { Text = "Цена (золото):", Top = 260, Left = 20, Width = 110 };
            numPrice = new NumericUpDown { Top = 260, Left = 140, Width = 100, Maximum = 100000, Value = 500 };

            btnSave = new Button { Text = "Сохранить в кузне", Top = 320, Left = 100, Width = 160, Height = 35 };
            btnSave.Click += BtnSave_Click;

            this.Controls.AddRange(new Control[] { lbl1, txtName, lbl2, txtType, lbl3, txtRarity, lbl4, numDamage, lbl5, numStrength, lbl6, numWeight, lbl7, numPrice, btnSave });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Оружие обязано иметь название!", "Внимание кузнеца", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WeaponData.Name = txtName.Text;
            WeaponData.WeaponType = txtType.Text;
            WeaponData.Rarity = txtRarity.Text;
            WeaponData.Damage = (int)numDamage.Value;
            WeaponData.RequiredStrength = (int)numStrength.Value;
            WeaponData.Weight = (double)numWeight.Value;
            WeaponData.Price = numPrice.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}