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
    public partial class MainMenuForm : Form
    {
        private readonly ILogic _armory;

        public MainMenuForm(ILogic armory)
        {
            InitializeComponent();
            _armory = armory;
        }
   
        private void btnWeapons_Click(object sender, EventArgs e)
        {
            using (var form = new Form1(_armory))
            {
                form.ShowDialog();
            }
        }

        private void btnBlacksmiths_Click_1(object sender, EventArgs e)
        {
            using (var form = new BlacksmithForm(_armory))
            {
                form.ShowDialog();
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
