namespace WeaponShopWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnEquip = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.UserS = new System.Windows.Forms.NumericUpDown();
            this.UserG = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserG)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(39, 25);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(820, 484);
            this.grid.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(895, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 53);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Выковать";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_2);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(895, 94);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(116, 51);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Перековать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(895, 162);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 52);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Переплавить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(895, 232);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 53);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Обновить";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // btnEquip
            // 
            this.btnEquip.Location = new System.Drawing.Point(895, 445);
            this.btnEquip.Name = "btnEquip";
            this.btnEquip.Size = new System.Drawing.Size(116, 48);
            this.btnEquip.TabIndex = 5;
            this.btnEquip.Text = "Подходящее оружие";
            this.btnEquip.UseVisualStyleBackColor = true;
            this.btnEquip.Click += new System.EventHandler(this.btnEquip_Click_1);
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(895, 509);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(116, 38);
            this.btnStats.TabIndex = 6;
            this.btnStats.Text = "Аналитика";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click_1);
            // 
            // UserS
            // 
            this.UserS.Location = new System.Drawing.Point(895, 346);
            this.UserS.Name = "UserS";
            this.UserS.Size = new System.Drawing.Size(120, 22);
            this.UserS.TabIndex = 7;
            // 
            // UserG
            // 
            this.UserG.Location = new System.Drawing.Point(895, 417);
            this.UserG.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.UserG.Name = "UserG";
            this.UserG.Size = new System.Drawing.Size(120, 22);
            this.UserG.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(895, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ваше золото";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(895, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ваша сила";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 622);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserG);
            this.Controls.Add(this.UserS);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.btnEquip);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnEquip;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.NumericUpDown UserS;
        private System.Windows.Forms.NumericUpDown UserG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}