using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WeaponShopCore;

namespace WeaponShopWinForms
{
    public partial class WeaponEditForm : Form
    {
        public Weapon WeaponData { get; private set; }

        public WeaponEditForm(Weapon weaponToEdit = null)
        {
            InitializeComponent();

            if (weaponToEdit != null)
            {
                this.Text = "Перековка оружия";

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
                cmbType.SelectedItem = WeaponData.WeaponType;
                cmbRarity.SelectedItem = WeaponData.Rarity;

                numDamage.Value = WeaponData.Damage;
                numStrength.Value = WeaponData.RequiredStrength;
                numWeight.Value = (decimal)WeaponData.Weight;
                numPrice.Value = WeaponData.Price;
            }
            else
            {
                this.Text = "Ковка нового оружия";
                WeaponData = new Weapon();
                cmbType.SelectedIndex = 0;
                cmbRarity.SelectedItem = "Обычное";
                numDamage.Value = 50;
                numStrength.Value = 25;
                numWeight.Value = 3.5m;
                numPrice.Value = 500;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Оружие обязано иметь название!", "Внимание кузнеца");
                return;
            }

            WeaponData.Name = txtName.Text;
            WeaponData.WeaponType = cmbType.SelectedItem.ToString(); 
            WeaponData.Rarity = cmbRarity.SelectedItem.ToString();
            WeaponData.Damage = (int)numDamage.Value;
            WeaponData.RequiredStrength = (int)numStrength.Value;
            WeaponData.Weight = (double)numWeight.Value;
            WeaponData.Price = numPrice.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
