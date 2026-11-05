using System;
using System.Windows.Forms;
using BusinessLogic;

namespace WeaponShopWinForms
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }


        private void OpenMainMenu(bool useDapper)
        {
            Logic armory = new Logic(useDapper);

            this.Hide();

            using (var form = new MainMenuForm(armory))
            {
                form.ShowDialog();
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenMainMenu(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenMainMenu(false);
        }
    }
}