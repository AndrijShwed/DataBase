namespace DataBase
{
    partial class EnterpriseAdd
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
            this.comboBoxStreets = new System.Windows.Forms.ComboBox();
            this.comboBoxVillage = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxHouseNumb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxEmployeesCount = new System.Windows.Forms.TextBox();
            this.textBoxOwnerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.земляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxEnterpriseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxStreets
            // 
            this.comboBoxStreets.FormattingEnabled = true;
            this.comboBoxStreets.Location = new System.Drawing.Point(32, 195);
            this.comboBoxStreets.Name = "comboBoxStreets";
            this.comboBoxStreets.Size = new System.Drawing.Size(401, 37);
            this.comboBoxStreets.TabIndex = 47;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.FormattingEnabled = true;
            this.comboBoxVillage.Location = new System.Drawing.Point(32, 97);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Size = new System.Drawing.Size(401, 37);
            this.comboBoxVillage.TabIndex = 46;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 29);
            this.label10.TabIndex = 45;
            this.label10.Text = "Номер будинку";
            // 
            // textBoxHouseNumb
            // 
            this.textBoxHouseNumb.Location = new System.Drawing.Point(32, 306);
            this.textBoxHouseNumb.Name = "textBoxHouseNumb";
            this.textBoxHouseNumb.Size = new System.Drawing.Size(401, 34);
            this.textBoxHouseNumb.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(27, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 29);
            this.label9.TabIndex = 43;
            this.label9.Text = "Вулиця";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkSalmon;
            this.buttonSave.Location = new System.Drawing.Point(32, 397);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(216, 40);
            this.buttonSave.TabIndex = 42;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxEmployeesCount
            // 
            this.textBoxEmployeesCount.Location = new System.Drawing.Point(466, 198);
            this.textBoxEmployeesCount.Name = "textBoxEmployeesCount";
            this.textBoxEmployeesCount.Size = new System.Drawing.Size(401, 34);
            this.textBoxEmployeesCount.TabIndex = 38;
            // 
            // textBoxOwnerName
            // 
            this.textBoxOwnerName.Location = new System.Drawing.Point(466, 299);
            this.textBoxOwnerName.Name = "textBoxOwnerName";
            this.textBoxOwnerName.Size = new System.Drawing.Size(401, 34);
            this.textBoxOwnerName.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(27, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 29);
            this.label8.TabIndex = 34;
            this.label8.Text = "Населений пункт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(461, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 29);
            this.label6.TabIndex = 32;
            this.label6.Text = "Кількість працівників";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(461, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "ПІП власника";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.земляToolStripMenuItem,
            this.додатиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 36);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(111, 32);
            this.головнаToolStripMenuItem.Text = "Головна/";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // земляToolStripMenuItem
            // 
            this.земляToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.земляToolStripMenuItem.Name = "земляToolStripMenuItem";
            this.земляToolStripMenuItem.Size = new System.Drawing.Size(161, 32);
            this.земляToolStripMenuItem.Text = "Підприємства/";
            this.земляToolStripMenuItem.Click += new System.EventHandler(this.земляToolStripMenuItem_Click);
            // 
            // додатиToolStripMenuItem
            // 
            this.додатиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            this.додатиToolStripMenuItem.Size = new System.Drawing.Size(107, 32);
            this.додатиToolStripMenuItem.Text = "Додати";
            // 
            // textBoxEnterpriseName
            // 
            this.textBoxEnterpriseName.Location = new System.Drawing.Point(466, 100);
            this.textBoxEnterpriseName.Name = "textBoxEnterpriseName";
            this.textBoxEnterpriseName.Size = new System.Drawing.Size(401, 34);
            this.textBoxEnterpriseName.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(461, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 29);
            this.label2.TabIndex = 48;
            this.label2.Text = "Назва підпиємства";
            // 
            // EnterpriseAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1156, 476);
            this.Controls.Add(this.textBoxEnterpriseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStreets);
            this.Controls.Add(this.comboBoxVillage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxHouseNumb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxEmployeesCount);
            this.Controls.Add(this.textBoxOwnerName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "EnterpriseAdd";
            this.Text = "EnterpriseAdd";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxStreets;
        private System.Windows.Forms.ComboBox comboBoxVillage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxHouseNumb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxEmployeesCount;
        private System.Windows.Forms.TextBox textBoxOwnerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem земляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxEnterpriseName;
        private System.Windows.Forms.Label label2;
    }
}