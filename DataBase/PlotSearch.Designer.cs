namespace DataBase
{
    partial class PlotSearch
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.головToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.земляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вікноПошукуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewВікноПошуку = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxTenant = new System.Windows.Forms.TextBox();
            this.textBoxPlotNumber = new System.Windows.Forms.TextBox();
            this.textBoxCadastr = new System.Windows.Forms.TextBox();
            this.textBoxPlotType = new System.Windows.Forms.TextBox();
            this.textBoxFieldNumber = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPlotAmount = new System.Windows.Forms.TextBox();
            this.textBoxTotalArea = new System.Windows.Forms.TextBox();
            this.comboBoxStreets = new System.Windows.Forms.ComboBox();
            this.comboBoxVillage = new System.Windows.Forms.ComboBox();
            this.textBoxHouseNumb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewВікноПошуку)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головToolStripMenuItem,
            this.земляToolStripMenuItem,
            this.вікноПошукуToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1534, 39);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // головToolStripMenuItem
            // 
            this.головToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головToolStripMenuItem.Name = "головToolStripMenuItem";
            this.головToolStripMenuItem.Size = new System.Drawing.Size(121, 35);
            this.головToolStripMenuItem.Text = "Головна/";
            this.головToolStripMenuItem.Click += new System.EventHandler(this.головToolStripMenuItem_Click);
            // 
            // земляToolStripMenuItem
            // 
            this.земляToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.земляToolStripMenuItem.Name = "земляToolStripMenuItem";
            this.земляToolStripMenuItem.Size = new System.Drawing.Size(99, 35);
            this.земляToolStripMenuItem.Text = "Земля/";
            this.земляToolStripMenuItem.Click += new System.EventHandler(this.земляToolStripMenuItem_Click);
            // 
            // вікноПошукуToolStripMenuItem
            // 
            this.вікноПошукуToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.вікноПошукуToolStripMenuItem.Name = "вікноПошукуToolStripMenuItem";
            this.вікноПошукуToolStripMenuItem.Size = new System.Drawing.Size(180, 35);
            this.вікноПошукуToolStripMenuItem.Text = "Вікно пошуку";
            // 
            // dataGridViewВікноПошуку
            // 
            this.dataGridViewВікноПошуку.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewВікноПошуку.Location = new System.Drawing.Point(13, 261);
            this.dataGridViewВікноПошуку.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewВікноПошуку.Name = "dataGridViewВікноПошуку";
            this.dataGridViewВікноПошуку.RowHeadersWidth = 51;
            this.dataGridViewВікноПошуку.RowTemplate.Height = 24;
            this.dataGridViewВікноПошуку.Size = new System.Drawing.Size(1510, 480);
            this.dataGridViewВікноПошуку.TabIndex = 2;
            this.dataGridViewВікноПошуку.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewВікноПошуку_CellContentClick);
            this.dataGridViewВікноПошуку.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewВікноПошуку_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxHouseNumb);
            this.groupBox1.Controls.Add(this.comboBoxVillage);
            this.groupBox1.Controls.Add(this.comboBoxStreets);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.textBoxTenant);
            this.groupBox1.Controls.Add(this.textBoxPlotNumber);
            this.groupBox1.Controls.Add(this.textBoxCadastr);
            this.groupBox1.Controls.Add(this.textBoxPlotType);
            this.groupBox1.Controls.Add(this.textBoxFieldNumber);
            this.groupBox1.Controls.Add(this.textBoxFullName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1510, 146);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметри пошуку";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.ForeColor = System.Drawing.Color.Black;
            this.buttonSearch.Location = new System.Drawing.Point(6, 108);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(133, 32);
            this.buttonSearch.TabIndex = 17;
            this.buttonSearch.Text = "Пошук";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.ForeColor = System.Drawing.Color.Brown;
            this.buttonClear.Location = new System.Drawing.Point(6, 43);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(133, 32);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Очистити";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxTenant
            // 
            this.textBoxTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTenant.Location = new System.Drawing.Point(895, 106);
            this.textBoxTenant.Name = "textBoxTenant";
            this.textBoxTenant.Size = new System.Drawing.Size(275, 30);
            this.textBoxTenant.TabIndex = 13;
            // 
            // textBoxPlotNumber
            // 
            this.textBoxPlotNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlotNumber.Location = new System.Drawing.Point(1187, 42);
            this.textBoxPlotNumber.Name = "textBoxPlotNumber";
            this.textBoxPlotNumber.Size = new System.Drawing.Size(143, 30);
            this.textBoxPlotNumber.TabIndex = 11;
            // 
            // textBoxCadastr
            // 
            this.textBoxCadastr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCadastr.Location = new System.Drawing.Point(1176, 106);
            this.textBoxCadastr.Name = "textBoxCadastr";
            this.textBoxCadastr.Size = new System.Drawing.Size(328, 30);
            this.textBoxCadastr.TabIndex = 10;
            // 
            // textBoxPlotType
            // 
            this.textBoxPlotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlotType.Location = new System.Drawing.Point(895, 42);
            this.textBoxPlotType.Name = "textBoxPlotType";
            this.textBoxPlotType.Size = new System.Drawing.Size(275, 30);
            this.textBoxPlotType.TabIndex = 9;
            // 
            // textBoxFieldNumber
            // 
            this.textBoxFieldNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFieldNumber.Location = new System.Drawing.Point(716, 43);
            this.textBoxFieldNumber.Name = "textBoxFieldNumber";
            this.textBoxFieldNumber.Size = new System.Drawing.Size(146, 30);
            this.textBoxFieldNumber.TabIndex = 8;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFullName.Location = new System.Drawing.Point(162, 43);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(537, 30);
            this.textBoxFullName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(711, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "Номер поля";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(935, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Тип ділянки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1171, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кадастровий номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1177, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номер ділянки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(187, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПІП власника";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Script", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 38);
            this.label8.TabIndex = 4;
            this.label8.Text = "К-сть ділянок:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Script", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(429, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 38);
            this.label9.TabIndex = 5;
            this.label9.Text = "Загальна площа:";
            // 
            // textBoxPlotAmount
            // 
            this.textBoxPlotAmount.Location = new System.Drawing.Point(224, 203);
            this.textBoxPlotAmount.Name = "textBoxPlotAmount";
            this.textBoxPlotAmount.Size = new System.Drawing.Size(146, 34);
            this.textBoxPlotAmount.TabIndex = 6;
            // 
            // textBoxTotalArea
            // 
            this.textBoxTotalArea.Location = new System.Drawing.Point(663, 203);
            this.textBoxTotalArea.Name = "textBoxTotalArea";
            this.textBoxTotalArea.Size = new System.Drawing.Size(176, 34);
            this.textBoxTotalArea.TabIndex = 7;
            // 
            // comboBoxStreets
            // 
            this.comboBoxStreets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStreets.FormattingEnabled = true;
            this.comboBoxStreets.Location = new System.Drawing.Point(437, 103);
            this.comboBoxStreets.Name = "comboBoxStreets";
            this.comboBoxStreets.Size = new System.Drawing.Size(262, 37);
            this.comboBoxStreets.TabIndex = 18;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxVillage.FormattingEnabled = true;
            this.comboBoxVillage.Location = new System.Drawing.Point(162, 103);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Size = new System.Drawing.Size(269, 37);
            this.comboBoxVillage.TabIndex = 19;
            this.comboBoxVillage.SelectedIndexChanged += new System.EventHandler(this.comboBoxVillage_SelectedIndexChanged);
            // 
            // textBoxHouseNumb
            // 
            this.textBoxHouseNumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHouseNumb.Location = new System.Drawing.Point(716, 102);
            this.textBoxHouseNumb.Name = "textBoxHouseNumb";
            this.textBoxHouseNumb.Size = new System.Drawing.Size(146, 34);
            this.textBoxHouseNumb.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(711, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 28);
            this.label10.TabIndex = 22;
            this.label10.Text = "Номер будинку";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(890, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 28);
            this.label4.TabIndex = 23;
            this.label4.Text = "Орендар";
            // 
            // PlotSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1534, 521);
            this.Controls.Add(this.textBoxTotalArea);
            this.Controls.Add(this.textBoxPlotAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewВікноПошуку);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PlotSearch";
            this.Text = "PlotSearch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewВікноПошуку)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem головToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem земляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вікноПошукуToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewВікноПошуку;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPlotNumber;
        private System.Windows.Forms.TextBox textBoxCadastr;
        private System.Windows.Forms.TextBox textBoxPlotType;
        private System.Windows.Forms.TextBox textBoxFieldNumber;
        private System.Windows.Forms.TextBox textBoxTenant;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPlotAmount;
        private System.Windows.Forms.TextBox textBoxTotalArea;
        private System.Windows.Forms.ComboBox comboBoxVillage;
        private System.Windows.Forms.ComboBox comboBoxStreets;
        private System.Windows.Forms.TextBox textBoxHouseNumb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
    }
}