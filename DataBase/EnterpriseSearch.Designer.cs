namespace DataBase
{
    partial class EnterpriseSearch
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
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.підприємстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStreets = new System.Windows.Forms.ComboBox();
            this.comboBoxVillage = new System.Windows.Forms.ComboBox();
            this.textBoxHouseNumber = new System.Windows.Forms.TextBox();
            this.textBoxHead = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonОчиститиТаблицю = new System.Windows.Forms.Button();
            this.dataGridViewВікноПошуку = new System.Windows.Forms.DataGridView();
            this.Clear = new DataBase.RJButton();
            this.Search = new DataBase.RJButton();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewВікноПошуку)).BeginInit();
            this.SuspendLayout();
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(123, 35);
            this.головнаToolStripMenuItem.Text = "Головна/";
            // 
            // підприємстваToolStripMenuItem
            // 
            this.підприємстваToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.підприємстваToolStripMenuItem.Name = "підприємстваToolStripMenuItem";
            this.підприємстваToolStripMenuItem.Size = new System.Drawing.Size(273, 35);
            this.підприємстваToolStripMenuItem.Text = "Підприємства пошук";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.підприємстваToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1321, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxStreets);
            this.groupBox1.Controls.Add(this.comboBoxVillage);
            this.groupBox1.Controls.Add(this.textBoxHouseNumber);
            this.groupBox1.Controls.Add(this.textBoxHead);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1500, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметри пошуку";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(823, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 25);
            this.label9.TabIndex = 56;
            this.label9.Text = "Номер буд.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(650, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 25);
            this.label7.TabIndex = 54;
            this.label7.Text = "ПІБ власника";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(257, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 25);
            this.label6.TabIndex = 53;
            this.label6.Text = "Назва підприємства";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(604, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 52;
            this.label5.Text = "Вулиця";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(257, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 51;
            this.label4.Text = "Населений пункт";
            // 
            // comboBoxStreets
            // 
            this.comboBoxStreets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStreets.FormattingEnabled = true;
            this.comboBoxStreets.Location = new System.Drawing.Point(513, 146);
            this.comboBoxStreets.Name = "comboBoxStreets";
            this.comboBoxStreets.Size = new System.Drawing.Size(289, 37);
            this.comboBoxStreets.TabIndex = 48;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxVillage.FormattingEnabled = true;
            this.comboBoxVillage.Location = new System.Drawing.Point(202, 146);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Size = new System.Drawing.Size(305, 37);
            this.comboBoxVillage.TabIndex = 47;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // textBoxHouseNumber
            // 
            this.textBoxHouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHouseNumber.Location = new System.Drawing.Point(809, 146);
            this.textBoxHouseNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHouseNumber.Name = "textBoxHouseNumber";
            this.textBoxHouseNumber.Size = new System.Drawing.Size(149, 34);
            this.textBoxHouseNumber.TabIndex = 42;
            // 
            // textBoxHead
            // 
            this.textBoxHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHead.Location = new System.Drawing.Point(513, 74);
            this.textBoxHead.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHead.Name = "textBoxHead";
            this.textBoxHead.Size = new System.Drawing.Size(445, 34);
            this.textBoxHead.TabIndex = 40;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(202, 74);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(306, 34);
            this.textBoxName.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введіть дані :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(425, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 32);
            this.label3.TabIndex = 22;
            this.label3.Text = "записів";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCount.Location = new System.Drawing.Point(303, 285);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(104, 38);
            this.textBoxCount.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 291);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 32);
            this.label2.TabIndex = 19;
            this.label2.Text = "Результат пошуку :";
            // 
            // buttonОчиститиТаблицю
            // 
            this.buttonОчиститиТаблицю.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(100)))), ((int)(((byte)(108)))));
            this.buttonОчиститиТаблицю.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonОчиститиТаблицю.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonОчиститиТаблицю.Location = new System.Drawing.Point(998, 276);
            this.buttonОчиститиТаблицю.Margin = new System.Windows.Forms.Padding(4);
            this.buttonОчиститиТаблицю.Name = "buttonОчиститиТаблицю";
            this.buttonОчиститиТаблицю.Size = new System.Drawing.Size(303, 44);
            this.buttonОчиститиТаблицю.TabIndex = 23;
            this.buttonОчиститиТаблицю.Text = "Очистити таблицю";
            this.buttonОчиститиТаблицю.UseVisualStyleBackColor = false;
            this.buttonОчиститиТаблицю.Click += new System.EventHandler(this.buttonОчиститиТаблицю_Click);
            // 
            // dataGridViewВікноПошуку
            // 
            this.dataGridViewВікноПошуку.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewВікноПошуку.Location = new System.Drawing.Point(12, 328);
            this.dataGridViewВікноПошуку.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewВікноПошуку.Name = "dataGridViewВікноПошуку";
            this.dataGridViewВікноПошуку.RowHeadersWidth = 51;
            this.dataGridViewВікноПошуку.RowTemplate.Height = 24;
            this.dataGridViewВікноПошуку.Size = new System.Drawing.Size(1500, 430);
            this.dataGridViewВікноПошуку.TabIndex = 24;
            this.dataGridViewВікноПошуку.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewВікноПошуку_CellContentClick);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.DarkKhaki;
            this.Clear.FlatAppearance.BorderSize = 0;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear.ForeColor = System.Drawing.Color.Black;
            this.Clear.Location = new System.Drawing.Point(6, 147);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(150, 72);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Очистити поля";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.Gold;
            this.Search.FlatAppearance.BorderSize = 0;
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.Location = new System.Drawing.Point(6, 101);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(150, 40);
            this.Search.TabIndex = 0;
            this.Search.Text = "Пошук";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // EnterpriseSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1321, 886);
            this.Controls.Add(this.dataGridViewВікноПошуку);
            this.Controls.Add(this.buttonОчиститиТаблицю);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EnterpriseSearch";
            this.Text = "EnterrpriseSearch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewВікноПошуку)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem підприємстваToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private RJButton Clear;
        private RJButton Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxStreets;
        private System.Windows.Forms.ComboBox comboBoxVillage;
        private System.Windows.Forms.TextBox textBoxHouseNumber;
        private System.Windows.Forms.TextBox textBoxHead;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonОчиститиТаблицю;
        private System.Windows.Forms.DataGridView dataGridViewВікноПошуку;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}