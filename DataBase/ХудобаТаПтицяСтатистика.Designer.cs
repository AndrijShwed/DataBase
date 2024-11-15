namespace DataBase
{
    partial class ХудобаТаПтицяСтатистика
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вийтиЗПрограмиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewBer = new System.Windows.Forms.DataGridView();
            this.Бережниця = new System.Windows.Forms.Label();
            this.ОновитиДані = new DataBase.RJButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGreen;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пошукToolStripMenuItem,
            this.головнаToolStripMenuItem,
            this.додатиToolStripMenuItem,
            this.статистикаToolStripMenuItem,
            this.вийтиЗПрограмиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1550, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(111, 32);
            this.пошукToolStripMenuItem.Text = "Головна/";
            this.пошукToolStripMenuItem.Click += new System.EventHandler(this.пошукToolStripMenuItem_Click);
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(101, 32);
            this.головнаToolStripMenuItem.Text = "Пошук /";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // додатиToolStripMenuItem
            // 
            this.додатиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            this.додатиToolStripMenuItem.Size = new System.Drawing.Size(106, 32);
            this.додатиToolStripMenuItem.Text = "Додати /";
            this.додатиToolStripMenuItem.Click += new System.EventHandler(this.додатиToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(146, 32);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // вийтиЗПрограмиToolStripMenuItem
            // 
            this.вийтиЗПрограмиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.вийтиЗПрограмиToolStripMenuItem.Name = "вийтиЗПрограмиToolStripMenuItem";
            this.вийтиЗПрограмиToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.вийтиЗПрограмиToolStripMenuItem.Text = "Вийти з програми";
            this.вийтиЗПрограмиToolStripMenuItem.Click += new System.EventHandler(this.вийтиЗПрограмиToolStripMenuItem_Click);
            // 
            // dataGridViewBer
            // 
            this.dataGridViewBer.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.dataGridViewBer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBer.Location = new System.Drawing.Point(12, 75);
            this.dataGridViewBer.Name = "dataGridViewBer";
            this.dataGridViewBer.RowHeadersWidth = 51;
            this.dataGridViewBer.RowTemplate.Height = 24;
            this.dataGridViewBer.Size = new System.Drawing.Size(1510, 300);
            this.dataGridViewBer.TabIndex = 1;
            // 
            // Бережниця
            // 
            this.Бережниця.AutoSize = true;
            this.Бережниця.Font = new System.Drawing.Font("Segoe Script", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Бережниця.Location = new System.Drawing.Point(20, 36);
            this.Бережниця.Name = "Бережниця";
            this.Бережниця.Size = new System.Drawing.Size(264, 38);
            this.Бережниця.TabIndex = 6;
            this.Бережниця.Text = "Домашні тварини";
            // 
            // ОновитиДані
            // 
            this.ОновитиДані.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ОновитиДані.FlatAppearance.BorderSize = 0;
            this.ОновитиДані.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ОновитиДані.Font = new System.Drawing.Font("Segoe Script", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ОновитиДані.ForeColor = System.Drawing.Color.Black;
            this.ОновитиДані.Location = new System.Drawing.Point(419, 34);
            this.ОновитиДані.Name = "ОновитиДані";
            this.ОновитиДані.Size = new System.Drawing.Size(234, 40);
            this.ОновитиДані.TabIndex = 13;
            this.ОновитиДані.Text = "Оновити дані";
            this.ОновитиДані.UseVisualStyleBackColor = false;
            this.ОновитиДані.Click += new System.EventHandler(this.ОновитиДані_Click);
            // 
            // ХудобаТаПтицяСтатистика
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1550, 400);
            this.Controls.Add(this.ОновитиДані);
            this.Controls.Add(this.Бережниця);
            this.Controls.Add(this.dataGridViewBer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ХудобаТаПтицяСтатистика";
            this.Text = "ХудобаТаПтицяСтатистика";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewBer;
        private System.Windows.Forms.Label Бережниця;
        private System.Windows.Forms.ToolStripMenuItem вийтиЗПрограмиToolStripMenuItem;
        private RJButton ОновитиДані;
    }
}