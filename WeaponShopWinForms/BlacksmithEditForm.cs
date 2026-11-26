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
using WeaponShopModel;


namespace WeaponShopWinForms
{
    public partial class BlacksmithEditForm : Form
    {
        public Blacksmith BlacksmithData { get; private set; }


        public BlacksmithEditForm()
        {
            InitializeComponent();

            cmbSpecialization.Items.AddRange(new object[]
            {
            "Мечи", "Топоры", "Молоты", "Копья", "Кинжалы"
            });

            numSkill.Minimum = 0;
            numSkill.Maximum = 100;

            numMultiplier.Minimum = 1;
            numMultiplier.Maximum = 100;
            numMultiplier.DecimalPlaces = 2;
            numMultiplier.Increment = 0.1m;

            BlacksmithData = new Blacksmith();
        }

        public BlacksmithEditForm(Blacksmith blacksmith = null) 
        {
            InitializeComponent();


            cmbSpecialization.Items.AddRange(new object[]
            {
            "Мечи", "Топоры", "Молоты", "Копья", "Кинжалы"
            });
            numSkill.Minimum = 0;
            numSkill.Maximum = 100;
            numMultiplier.Minimum = 1;
            numMultiplier.Maximum = 100;
            numMultiplier.DecimalPlaces = 2;
            numMultiplier.Increment = 0.1m;

            if (blacksmith == null)
            {
                BlacksmithData = new Blacksmith();
                return; 
            }

        
            BlacksmithData = new Blacksmith
            {
                Id = blacksmith.Id,
                Name = blacksmith.Name,
                Specialization = blacksmith.Specialization,
                SkillLevel = blacksmith.SkillLevel,
                PriceMultiplier = blacksmith.PriceMultiplier
            };

            txtName.Text = blacksmith.Name;
            cmbSpecialization.SelectedItem = blacksmith.Specialization;
            numSkill.Value = blacksmith.SkillLevel;
            numMultiplier.Value = blacksmith.PriceMultiplier;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите имя кузнеца.");
                return;
            }

            if (cmbSpecialization.SelectedItem == null)
            {
                MessageBox.Show("Выберите специализацию.");
                return;
            }

            BlacksmithData.Name = txtName.Text.Trim();
            BlacksmithData.Specialization = cmbSpecialization.SelectedItem.ToString();
            BlacksmithData.SkillLevel = (int)numSkill.Value;
            BlacksmithData.PriceMultiplier = numMultiplier.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
