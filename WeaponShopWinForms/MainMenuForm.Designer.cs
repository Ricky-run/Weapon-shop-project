namespace WeaponShopWinForms
{
    partial class MainMenuForm
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
            this.btnBlacksmiths = new System.Windows.Forms.Button();
            this.btnWeapons = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBlacksmiths
            // 
            this.btnBlacksmiths.Location = new System.Drawing.Point(132, 144);
            this.btnBlacksmiths.Name = "btnBlacksmiths";
            this.btnBlacksmiths.Size = new System.Drawing.Size(207, 121);
            this.btnBlacksmiths.TabIndex = 0;
            this.btnBlacksmiths.Text = "Кузнечная мастерская";
            this.btnBlacksmiths.UseVisualStyleBackColor = true;
            this.btnBlacksmiths.Click += new System.EventHandler(this.btnBlacksmiths_Click_1);
            // 
            // btnWeapons
            // 
            this.btnWeapons.Location = new System.Drawing.Point(452, 141);
            this.btnWeapons.Name = "btnWeapons";
            this.btnWeapons.Size = new System.Drawing.Size(216, 124);
            this.btnWeapons.TabIndex = 1;
            this.btnWeapons.Text = "Оружейная лавка";
            this.btnWeapons.UseVisualStyleBackColor = true;
            this.btnWeapons.Click += new System.EventHandler(this.btnWeapons_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(337, 347);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(141, 55);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWeapons);
            this.Controls.Add(this.btnBlacksmiths);
            this.Name = "MainMenuForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBlacksmiths;
        private System.Windows.Forms.Button btnWeapons;
        private System.Windows.Forms.Button btnExit;
    }
}