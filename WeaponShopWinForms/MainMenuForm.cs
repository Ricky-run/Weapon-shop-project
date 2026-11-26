
using Shared;
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

namespace WeaponShopWinForms
{
    public partial class MainMenuForm : Form, IMainMenuView
    {
        public event Action OpenWeaponsRequested;
        public event Action OpenBlacksmithsRequested;

        public MainMenuForm() => InitializeComponent();

        private void btnWeapons_Click(object sender, EventArgs e)
            => OpenWeaponsRequested?.Invoke();

        private void btnBlacksmiths_Click_1(object sender, EventArgs e)
            => OpenBlacksmithsRequested?.Invoke();

        private void btnExit_Click_1(object sender, EventArgs e)
            => Close();
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}