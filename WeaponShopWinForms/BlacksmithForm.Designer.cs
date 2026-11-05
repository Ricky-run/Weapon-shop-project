namespace WeaponShopWinForms
{
    partial class BlacksmithForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridBlacksmiths = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrice = new System.Windows.Forms.Button();
            this.txtSpecialization = new System.Windows.Forms.TextBox();
            this.txtBlacksmithId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numBasePrice = new System.Windows.Forms.NumericUpDown();
            this.numSkill = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlacksmiths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBlacksmiths
            // 
            this.gridBlacksmiths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBlacksmiths.Location = new System.Drawing.Point(26, 28);
            this.gridBlacksmiths.Name = "gridBlacksmiths";
            this.gridBlacksmiths.RowHeadersWidth = 51;
            this.gridBlacksmiths.RowTemplate.Height = 24;
            this.gridBlacksmiths.Size = new System.Drawing.Size(828, 290);
            this.gridBlacksmiths.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(42, 336);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 47);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Нанять";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(198, 336);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 47);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Уволить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_2);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(198, 399);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(121, 44);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(42, 399);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 44);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(356, 336);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(219, 47);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Искать";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(760, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Найти по ID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnPrice
            // 
            this.btnPrice.Location = new System.Drawing.Point(601, 339);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(140, 47);
            this.btnPrice.TabIndex = 7;
            this.btnPrice.Text = "Рассчитать цену";
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click_1);
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Location = new System.Drawing.Point(356, 421);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(100, 22);
            this.txtSpecialization.TabIndex = 8;
            // 
            // txtBlacksmithId
            // 
            this.txtBlacksmithId.Location = new System.Drawing.Point(760, 421);
            this.txtBlacksmithId.Name = "txtBlacksmithId";
            this.txtBlacksmithId.Size = new System.Drawing.Size(100, 22);
            this.txtBlacksmithId.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Специализация:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Минимальный \r\n     уровень";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Базовая цена";
            // 
            // numBasePrice
            // 
            this.numBasePrice.Location = new System.Drawing.Point(616, 422);
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(102, 22);
            this.numBasePrice.TabIndex = 13;
            // 
            // numSkill
            // 
            this.numSkill.Location = new System.Drawing.Point(475, 422);
            this.numSkill.Name = "numSkill";
            this.numSkill.Size = new System.Drawing.Size(100, 22);
            this.numSkill.TabIndex = 14;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(42, 478);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // BlacksmithForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 512);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.numSkill);
            this.Controls.Add(this.numBasePrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBlacksmithId);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.btnPrice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridBlacksmiths);
            this.Name = "BlacksmithForm";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.gridBlacksmiths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBlacksmiths;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrice;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.TextBox txtBlacksmithId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.NumericUpDown numSkill;
        private System.Windows.Forms.Button btnExit;
    }
}