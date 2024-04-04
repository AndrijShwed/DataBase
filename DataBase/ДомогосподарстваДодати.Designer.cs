namespace DataBase
{
    partial class ДомогосподарстваДодати
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ДомогосподарстваДодати));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.домогосподарстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxVillage = new System.Windows.Forms.ComboBox();
            this.comboBoxStreets = new System.Windows.Forms.ComboBox();
            this.comboBoxNumb = new System.Windows.Forms.ComboBox();
            this.comboBoxLastname = new System.Windows.Forms.ComboBox();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.comboBoxSurname = new System.Windows.Forms.ComboBox();
            this.Населений_пункт = new System.Windows.Forms.Label();
            this.Вулиця = new System.Windows.Forms.Label();
            this.Ном_буд = new System.Windows.Forms.Label();
            this.Прізвище_власника = new System.Windows.Forms.Label();
            this.Ім_я = new System.Windows.Forms.Label();
            this.Побатькові = new System.Windows.Forms.Label();
            this.dataGridViewДомогосподарства = new System.Windows.Forms.DataGridView();
            this.Знайти_власника = new DataBase.RJButton();
            this.ЗберегтиВТаблицю = new DataBase.RJButton();
            this.Додати_пустий_рядок = new DataBase.RJButton();
            this.rjButton1 = new DataBase.RJButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewДомогосподарства)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.домогосподарстваToolStripMenuItem,
            this.toolStripMenuItem1,
            this.вихідToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1482, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(122, 32);
            this.головнаToolStripMenuItem.Text = "Головна  /";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // домогосподарстваToolStripMenuItem
            // 
            this.домогосподарстваToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.домогосподарстваToolStripMenuItem.Name = "домогосподарстваToolStripMenuItem";
            this.домогосподарстваToolStripMenuItem.Size = new System.Drawing.Size(220, 32);
            this.домогосподарстваToolStripMenuItem.Text = "Домогосподарства /";
            this.домогосподарстваToolStripMenuItem.Click += new System.EventHandler(this.домогосподарстваToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(507, 32);
            this.toolStripMenuItem1.Text = "Додати                                                                    ";
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(77, 32);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxVillage.FormattingEnabled = true;
            this.comboBoxVillage.Location = new System.Drawing.Point(14, 89);
            this.comboBoxVillage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Size = new System.Drawing.Size(262, 34);
            this.comboBoxVillage.TabIndex = 1;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // comboBoxStreets
            // 
            this.comboBoxStreets.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStreets.FormattingEnabled = true;
            this.comboBoxStreets.Location = new System.Drawing.Point(286, 89);
            this.comboBoxStreets.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxStreets.Name = "comboBoxStreets";
            this.comboBoxStreets.Size = new System.Drawing.Size(280, 34);
            this.comboBoxStreets.TabIndex = 2;
            // 
            // comboBoxNumb
            // 
            this.comboBoxNumb.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxNumb.FormattingEnabled = true;
            this.comboBoxNumb.Location = new System.Drawing.Point(576, 89);
            this.comboBoxNumb.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxNumb.Name = "comboBoxNumb";
            this.comboBoxNumb.Size = new System.Drawing.Size(135, 34);
            this.comboBoxNumb.TabIndex = 3;
            // 
            // comboBoxLastname
            // 
            this.comboBoxLastname.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxLastname.FormattingEnabled = true;
            this.comboBoxLastname.Location = new System.Drawing.Point(721, 89);
            this.comboBoxLastname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxLastname.Name = "comboBoxLastname";
            this.comboBoxLastname.Size = new System.Drawing.Size(268, 34);
            this.comboBoxLastname.TabIndex = 4;
            // 
            // comboBoxName
            // 
            this.comboBoxName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(999, 89);
            this.comboBoxName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(228, 34);
            this.comboBoxName.TabIndex = 5;
            // 
            // comboBoxSurname
            // 
            this.comboBoxSurname.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSurname.FormattingEnabled = true;
            this.comboBoxSurname.Location = new System.Drawing.Point(1237, 89);
            this.comboBoxSurname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxSurname.Name = "comboBoxSurname";
            this.comboBoxSurname.Size = new System.Drawing.Size(231, 34);
            this.comboBoxSurname.TabIndex = 6;
            // 
            // Населений_пункт
            // 
            this.Населений_пункт.AutoSize = true;
            this.Населений_пункт.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Населений_пункт.Location = new System.Drawing.Point(14, 45);
            this.Населений_пункт.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Населений_пункт.Name = "Населений_пункт";
            this.Населений_пункт.Size = new System.Drawing.Size(247, 38);
            this.Населений_пункт.TabIndex = 7;
            this.Населений_пункт.Text = "Населений_пункт";
            // 
            // Вулиця
            // 
            this.Вулиця.AutoSize = true;
            this.Вулиця.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Вулиця.Location = new System.Drawing.Point(354, 45);
            this.Вулиця.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Вулиця.Name = "Вулиця";
            this.Вулиця.Size = new System.Drawing.Size(120, 38);
            this.Вулиця.TabIndex = 8;
            this.Вулиця.Text = "Вулиця";
            // 
            // Ном_буд
            // 
            this.Ном_буд.AutoSize = true;
            this.Ном_буд.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ном_буд.Location = new System.Drawing.Point(582, 45);
            this.Ном_буд.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Ном_буд.Name = "Ном_буд";
            this.Ном_буд.Size = new System.Drawing.Size(117, 38);
            this.Ном_буд.TabIndex = 9;
            this.Ном_буд.Text = "Ном_буд";
            // 
            // Прізвище_власника
            // 
            this.Прізвище_власника.AutoSize = true;
            this.Прізвище_власника.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Прізвище_власника.Location = new System.Drawing.Point(721, 45);
            this.Прізвище_власника.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Прізвище_власника.Name = "Прізвище_власника";
            this.Прізвище_власника.Size = new System.Drawing.Size(268, 38);
            this.Прізвище_власника.TabIndex = 10;
            this.Прізвище_власника.Text = "Прізвище_власника";
            // 
            // Ім_я
            // 
            this.Ім_я.AutoSize = true;
            this.Ім_я.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ім_я.Location = new System.Drawing.Point(1059, 45);
            this.Ім_я.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Ім_я.Name = "Ім_я";
            this.Ім_я.Size = new System.Drawing.Size(74, 38);
            this.Ім_я.TabIndex = 11;
            this.Ім_я.Text = "Ім_я";
            // 
            // Побатькові
            // 
            this.Побатькові.AutoSize = true;
            this.Побатькові.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Побатькові.Location = new System.Drawing.Point(1285, 45);
            this.Побатькові.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Побатькові.Name = "Побатькові";
            this.Побатькові.Size = new System.Drawing.Size(160, 38);
            this.Побатькові.TabIndex = 12;
            this.Побатькові.Text = "Побатькові";
            // 
            // dataGridViewДомогосподарства
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewДомогосподарства.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewДомогосподарства.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewДомогосподарства.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewДомогосподарства.Location = new System.Drawing.Point(14, 196);
            this.dataGridViewДомогосподарства.Name = "dataGridViewДомогосподарства";
            this.dataGridViewДомогосподарства.RowHeadersWidth = 51;
            this.dataGridViewДомогосподарства.RowTemplate.Height = 24;
            this.dataGridViewДомогосподарства.Size = new System.Drawing.Size(1468, 456);
            this.dataGridViewДомогосподарства.TabIndex = 13;
            // 
            // Знайти_власника
            // 
            this.Знайти_власника.BackColor = System.Drawing.Color.Orange;
            this.Знайти_власника.FlatAppearance.BorderSize = 0;
            this.Знайти_власника.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Знайти_власника.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Знайти_власника.ForeColor = System.Drawing.Color.White;
            this.Знайти_власника.Location = new System.Drawing.Point(21, 132);
            this.Знайти_власника.Name = "Знайти_власника";
            this.Знайти_власника.Size = new System.Drawing.Size(358, 45);
            this.Знайти_власника.TabIndex = 17;
            this.Знайти_власника.Text = "Знайти власника";
            this.Знайти_власника.UseVisualStyleBackColor = false;
            this.Знайти_власника.Click += new System.EventHandler(this.Знайти_власника_Click);
            // 
            // ЗберегтиВТаблицю
            // 
            this.ЗберегтиВТаблицю.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ЗберегтиВТаблицю.BackColor = System.Drawing.Color.Tomato;
            this.ЗберегтиВТаблицю.FlatAppearance.BorderSize = 0;
            this.ЗберегтиВТаблицю.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ЗберегтиВТаблицю.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ЗберегтиВТаблицю.ForeColor = System.Drawing.Color.White;
            this.ЗберегтиВТаблицю.Location = new System.Drawing.Point(834, 132);
            this.ЗберегтиВТаблицю.Name = "ЗберегтиВТаблицю";
            this.ЗберегтиВТаблицю.Size = new System.Drawing.Size(403, 45);
            this.ЗберегтиВТаблицю.TabIndex = 16;
            this.ЗберегтиВТаблицю.Text = "Зберегти в таблицю";
            this.ЗберегтиВТаблицю.UseVisualStyleBackColor = false;
            this.ЗберегтиВТаблицю.Click += new System.EventHandler(this.ЗберегтиВТаблицю_Click);
            // 
            // Додати_пустий_рядок
            // 
            this.Додати_пустий_рядок.BackColor = System.Drawing.Color.LightSalmon;
            this.Додати_пустий_рядок.FlatAppearance.BorderSize = 0;
            this.Додати_пустий_рядок.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Додати_пустий_рядок.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Додати_пустий_рядок.ForeColor = System.Drawing.Color.White;
            this.Додати_пустий_рядок.Location = new System.Drawing.Point(395, 133);
            this.Додати_пустий_рядок.Name = "Додати_пустий_рядок";
            this.Додати_пустий_рядок.Size = new System.Drawing.Size(424, 45);
            this.Додати_пустий_рядок.TabIndex = 15;
            this.Додати_пустий_рядок.Text = "Додати пустий рядок";
            this.Додати_пустий_рядок.UseVisualStyleBackColor = false;
            this.Додати_пустий_рядок.Click += new System.EventHandler(this.Додати_пустий_рядок_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Red;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(1159, 675);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(309, 43);
            this.rjButton1.TabIndex = 14;
            this.rjButton1.Text = "<<<  Повернутись";
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // ДомогосподарстваДодати
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.Знайти_власника);
            this.Controls.Add(this.ЗберегтиВТаблицю);
            this.Controls.Add(this.Додати_пустий_рядок);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.dataGridViewДомогосподарства);
            this.Controls.Add(this.Побатькові);
            this.Controls.Add(this.Ім_я);
            this.Controls.Add(this.Прізвище_власника);
            this.Controls.Add(this.Ном_буд);
            this.Controls.Add(this.Вулиця);
            this.Controls.Add(this.Населений_пункт);
            this.Controls.Add(this.comboBoxSurname);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.comboBoxLastname);
            this.Controls.Add(this.comboBoxNumb);
            this.Controls.Add(this.comboBoxStreets);
            this.Controls.Add(this.comboBoxVillage);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ДомогосподарстваДодати";
            this.Text = "Домогосподарства";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewДомогосподарства)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem домогосподарстваToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxVillage;
        private System.Windows.Forms.ComboBox comboBoxStreets;
        private System.Windows.Forms.ComboBox comboBoxNumb;
        private System.Windows.Forms.ComboBox comboBoxLastname;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.ComboBox comboBoxSurname;
        private System.Windows.Forms.Label Населений_пункт;
        private System.Windows.Forms.Label Вулиця;
        private System.Windows.Forms.Label Ном_буд;
        private System.Windows.Forms.Label Прізвище_власника;
        private System.Windows.Forms.Label Ім_я;
        private System.Windows.Forms.Label Побатькові;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewДомогосподарства;
        private RJButton rjButton1;
        private RJButton Додати_пустий_рядок;
        private RJButton ЗберегтиВТаблицю;
        private RJButton Знайти_власника;
    }
}