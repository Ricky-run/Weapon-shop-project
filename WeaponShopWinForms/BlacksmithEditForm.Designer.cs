namespace WeaponShopWinForms
{
    partial class BlacksmithEditForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numMultiplier = new System.Windows.Forms.NumericUpDown();
            this.numSkill = new System.Windows.Forms.NumericUpDown();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(295, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(177, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Выйти";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_2);
            // 
            // numMultiplier
            // 
            this.numMultiplier.Location = new System.Drawing.Point(295, 272);
            this.numMultiplier.Name = "numMultiplier";
            this.numMultiplier.Size = new System.Drawing.Size(177, 22);
            this.numMultiplier.TabIndex = 2;
            // 
            // numSkill
            // 
            this.numSkill.Location = new System.Drawing.Point(295, 223);
            this.numSkill.Name = "numSkill";
            this.numSkill.Size = new System.Drawing.Size(177, 22);
            this.numSkill.TabIndex = 3;
            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.Location = new System.Drawing.Point(295, 158);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(177, 24);
            this.cmbSpecialization.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(295, 110);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(177, 22);
            this.txtName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Специализация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Уровень";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Наценка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(329, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Кузнец";
            // 
            // BlacksmithEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.numSkill);
            this.Controls.Add(this.numMultiplier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Name = "BlacksmithEditForm";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numMultiplier;
        private System.Windows.Forms.NumericUpDown numSkill;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}