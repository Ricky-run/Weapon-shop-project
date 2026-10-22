namespace WeaponShopWinForms
{
    partial class WeaponEditForm
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
            this.numDamage = new System.Windows.Forms.NumericUpDown();
            this.numStrength = new System.Windows.Forms.NumericUpDown();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbRarity = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // numDamage
            // 
            this.numDamage.Location = new System.Drawing.Point(215, 166);
            this.numDamage.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numDamage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDamage.Name = "numDamage";
            this.numDamage.Size = new System.Drawing.Size(120, 22);
            this.numDamage.TabIndex = 3;
            this.numDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numStrength
            // 
            this.numStrength.Location = new System.Drawing.Point(215, 195);
            this.numStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStrength.Name = "numStrength";
            this.numStrength.Size = new System.Drawing.Size(120, 22);
            this.numStrength.TabIndex = 4;
            this.numStrength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(215, 237);
            this.numWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(120, 22);
            this.numWeight.TabIndex = 5;
            this.numWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(215, 278);
            this.numPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 22);
            this.numPrice.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(148, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(167, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Тип оружия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Редкость";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Урон";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Сила";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Вес";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Цена";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(215, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 22);
            this.txtName.TabIndex = 0;
            // 
            // cmbRarity
            // 
            this.cmbRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRarity.FormattingEnabled = true;
            this.cmbRarity.Items.AddRange(new object[] {
            "Обычное",
            "Редкое",
            "Эпическое",
            "Легендарное"});
            this.cmbRarity.Location = new System.Drawing.Point(215, 129);
            this.cmbRarity.Name = "cmbRarity";
            this.cmbRarity.Size = new System.Drawing.Size(121, 24);
            this.cmbRarity.TabIndex = 15;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Меч",
            "Молот",
            "Копье",
            "Топор",
            "Кинжал"});
            this.cmbType.Location = new System.Drawing.Point(214, 93);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 16;
            // 
            // WeaponEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 420);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbRarity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.numStrength);
            this.Controls.Add(this.numDamage);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WeaponEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeaponEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.numDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numDamage;
        private System.Windows.Forms.NumericUpDown numStrength;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbRarity;
        private System.Windows.Forms.ComboBox cmbType;
    }
}