
using Shared;
using Shared.Dto;
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
    public partial class BlacksmithForm : Form, IBlacksmithView
    {
        public event Action LoadBlacksmithsRequested;
        public event Action<BlacksmithDto> AddBlacksmithRequested;
        public event Action<BlacksmithDto> UpdateBlacksmithRequested;
        public event Action<int> DeleteBlacksmithRequested;
        public event Action<string, int> FindBlacksmithsRequested;
        public event Action<int, decimal> CalculateForgingPriceRequested;
        public event Action<int> GetBlacksmithByIdRequested;

        public BlacksmithForm()
        {
            InitializeComponent();
            Load += (s, e) => LoadBlacksmithsRequested?.Invoke();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
            => LoadBlacksmithsRequested?.Invoke();

        private void btnAdd_Click_1(object sender, EventArgs e)
            => OpenBlacksmithDialog(null, dto => AddBlacksmithRequested?.Invoke(dto));

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (gridBlacksmiths.CurrentRow?.DataBoundItem is BlacksmithDto selected)
                OpenBlacksmithDialog(selected, dto => UpdateBlacksmithRequested?.Invoke(dto));
        }

        private void btnDelete_Click_2(object sender, EventArgs e)
        {
            if (gridBlacksmiths.CurrentRow?.DataBoundItem is BlacksmithDto selected)
            {
                if (MessageBox.Show($"Уволить {selected.Name}?", "Подтверждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    DeleteBlacksmithRequested?.Invoke(selected.Id);
            }
            else MessageBox.Show("Выберите кузнеца.", "Внимание");
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string spec = txtSpecialization.Text.Trim();
            int skill = (int)numSkill.Value;
            FindBlacksmithsRequested?.Invoke(spec, skill);
        }

        private void btnPrice_Click_1(object sender, EventArgs e)
        {
            if (gridBlacksmiths.CurrentRow?.DataBoundItem is BlacksmithDto selected)
                CalculateForgingPriceRequested?.Invoke(selected.Id, numBasePrice.Value);
            else MessageBox.Show("Выберите кузнеца.", "Внимание");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtBlacksmithId.Text, out int id))
                GetBlacksmithByIdRequested?.Invoke(id);
            else MessageBox.Show("Некорректный ID");
        }

        private void btnExit_Click_1(object sender, EventArgs e) => Close();

        // --- Presenter -> UI ---
        public void ShowBlacksmiths(IEnumerable<BlacksmithDto> blacksmiths)
        {
            gridBlacksmiths.DataSource = null;
            gridBlacksmiths.DataSource = new List<BlacksmithDto>(blacksmiths);
        }

        public void ShowForgingPrice(string name, decimal multiplier, decimal finalPrice)
            => MessageBox.Show($"Кузнец: {name}\nНаценка: x{multiplier}\nИтог: {finalPrice} зол.",
                               "Расчёт стоимости");
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowMessage(string message)
            => MessageBox.Show(message, "Информация");

        public void OpenBlacksmithDialog(BlacksmithDto initial, Action<BlacksmithDto> onResult)
        {
            var domain = initial == null ? null : new WeaponShopModel.Blacksmith
            {
                Id = initial.Id,
                Name = initial.Name,
                Specialization = initial.Specialization,
                SkillLevel = initial.SkillLevel,
                PriceMultiplier = initial.PriceMultiplier
            };
            using (var dlg = new BlacksmithEditForm(domain))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var b = dlg.BlacksmithData;
                    onResult?.Invoke(new BlacksmithDto
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Specialization = b.Specialization,
                        SkillLevel = b.SkillLevel,
                        PriceMultiplier = b.PriceMultiplier
                    });
                }
            }
        }
    }
}


