namespace DataBase
{
    partial class Додати
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Додати));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.населенняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ДодатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переглядДанихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідЗПрограмиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonДодатиРядок = new System.Windows.Forms.Button();
            this.buttonЗберегти_В_Таблицю = new System.Windows.Forms.Button();
            this.dataGridViewДодати = new System.Windows.Forms.DataGridView();
            this.ButtonПовернутись = new DataBase.RJButton();
            this.comboBoxVillage = new System.Windows.Forms.ComboBox();
            this.comboBoxStreets = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewДодати)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.населенняToolStripMenuItem,
            this.ДодатиToolStripMenuItem,
            this.переглядДанихToolStripMenuItem,
            this.вихідЗПрограмиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 36);
            this.menuStrip1.TabIndex = 0;
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
            // населенняToolStripMenuItem
            // 
            this.населенняToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.населенняToolStripMenuItem.Name = "населенняToolStripMenuItem";
            this.населенняToolStripMenuItem.Size = new System.Drawing.Size(132, 32);
            this.населенняToolStripMenuItem.Text = "Населення/";
            this.населенняToolStripMenuItem.Click += new System.EventHandler(this.населенняToolStripMenuItem_Click);
            // 
            // ДодатиToolStripMenuItem
            // 
            this.ДодатиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ДодатиToolStripMenuItem.Name = "ДодатиToolStripMenuItem";
            this.ДодатиToolStripMenuItem.Size = new System.Drawing.Size(99, 32);
            this.ДодатиToolStripMenuItem.Text = "Додати";
            // 
            // переглядДанихToolStripMenuItem
            // 
            this.переглядДанихToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.переглядДанихToolStripMenuItem.Name = "переглядДанихToolStripMenuItem";
            this.переглядДанихToolStripMenuItem.Size = new System.Drawing.Size(188, 32);
            this.переглядДанихToolStripMenuItem.Text = "Перегляд  даних";
            this.переглядДанихToolStripMenuItem.Click += new System.EventHandler(this.переглядДанихToolStripMenuItem_Click);
            // 
            // вихідЗПрограмиToolStripMenuItem
            // 
            this.вихідЗПрограмиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.вихідЗПрограмиToolStripMenuItem.Name = "вихідЗПрограмиToolStripMenuItem";
            this.вихідЗПрограмиToolStripMenuItem.Size = new System.Drawing.Size(199, 32);
            this.вихідЗПрограмиToolStripMenuItem.Text = "Вихід з програми";
            this.вихідЗПрограмиToolStripMenuItem.Click += new System.EventHandler(this.вихідЗПрограмиToolStripMenuItem_Click);
            // 
            // buttonЗберегти_В_Таблицю
            // 
            this.buttonЗберегти_В_Таблицю.BackColor = System.Drawing.Color.Yellow;
            this.buttonЗберегти_В_Таблицю.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonЗберегти_В_Таблицю.Location = new System.Drawing.Point(692, 51);
            this.buttonЗберегти_В_Таблицю.Name = "buttonЗберегти_В_Таблицю";
            this.buttonЗберегти_В_Таблицю.Size = new System.Drawing.Size(372, 43);
            this.buttonЗберегти_В_Таблицю.TabIndex = 7;
            this.buttonЗберегти_В_Таблицю.Text = "Зберегти в таблицю";
            this.buttonЗберегти_В_Таблицю.UseVisualStyleBackColor = false;
            this.buttonЗберегти_В_Таблицю.Click += new System.EventHandler(this.buttonЗберегти_В_Таблицю_Click);
            // 
            // dataGridViewДодати
            // 
            this.dataGridViewДодати.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewДодати.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewДодати.Location = new System.Drawing.Point(12, 220);
            this.dataGridViewДодати.Name = "dataGridViewДодати";
            this.dataGridViewДодати.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewДодати.RowHeadersWidth = 51;
            this.dataGridViewДодати.RowTemplate.Height = 24;
            this.dataGridViewДодати.Size = new System.Drawing.Size(1902, 650);
            this.dataGridViewДодати.TabIndex = 8;
            // 
            // ButtonПовернутись
            // 
            this.ButtonПовернутись.BackColor = System.Drawing.Color.Red;
            this.ButtonПовернутись.FlatAppearance.BorderSize = 0;
            this.ButtonПовернутись.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonПовернутись.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonПовернутись.ForeColor = System.Drawing.Color.White;
            this.ButtonПовернутись.Location = new System.Drawing.Point(1664, 891);
            this.ButtonПовернутись.Name = "ButtonПовернутись";
            this.ButtonПовернутись.Size = new System.Drawing.Size(250, 50);
            this.ButtonПовернутись.TabIndex = 9;
            this.ButtonПовернутись.Text = "<<<Повернутись";
            this.ButtonПовернутись.UseVisualStyleBackColor = false;
            this.ButtonПовернутись.Click += new System.EventHandler(this.ButtonПовернутись_Click_1);
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.comboBoxVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxVillage.FormattingEnabled = true;
            this.comboBoxVillage.Location = new System.Drawing.Point(26, 114);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Size = new System.Drawing.Size(524, 37);
            this.comboBoxVillage.TabIndex = 12;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // comboBoxStreets
            // 
            this.comboBoxStreets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.comboBoxStreets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStreets.FormattingEnabled = true;
            this.comboBoxStreets.Location = new System.Drawing.Point(589, 114);
            this.comboBoxStreets.Name = "comboBoxStreets";
            this.comboBoxStreets.Size = new System.Drawing.Size(442, 37);
            this.comboBoxStreets.TabIndex = 13;
            // 
            // Додати
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.comboBoxStreets);
            this.Controls.Add(this.comboBoxVillage);
            this.Controls.Add(this.ButtonПовернутись);
            this.Controls.Add(this.dataGridViewДодати);
            this.Controls.Add(this.buttonЗберегти_В_Таблицю);
            this.Controls.Add(this.buttonДодатиРядок);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Додати";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Редагувати";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewДодати)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem населенняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ДодатиToolStripMenuItem;
        private System.Windows.Forms.Button buttonДодатиРядок;
        private System.Windows.Forms.Button buttonЗберегти_В_Таблицю;
        private System.Windows.Forms.DataGridView dataGridViewДодати;
        private RJButton ButtonПовернутись;
        private System.Windows.Forms.ToolStripMenuItem вихідЗПрограмиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переглядДанихToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxVillage;
        private System.Windows.Forms.ComboBox comboBoxStreets;
    }
}