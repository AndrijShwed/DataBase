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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBoxHayField1Number = new System.Windows.Forms.TextBox();
            this.textBoxHayField2Number = new System.Windows.Forms.TextBox();
            this.textBoxPlowedLandNumber = new System.Windows.Forms.TextBox();
            this.textBoxPlotNumber = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
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
            this.menuStrip2.Size = new System.Drawing.Size(1389, 39);
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
            this.dataGridViewВікноПошуку.Location = new System.Drawing.Point(12, 260);
            this.dataGridViewВікноПошуку.Name = "dataGridViewВікноПошуку";
            this.dataGridViewВікноПошуку.RowHeadersWidth = 51;
            this.dataGridViewВікноПошуку.RowTemplate.Height = 24;
            this.dataGridViewВікноПошуку.Size = new System.Drawing.Size(1365, 249);
            this.dataGridViewВікноПошуку.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBoxHayField1Number);
            this.groupBox1.Controls.Add(this.textBoxHayField2Number);
            this.groupBox1.Controls.Add(this.textBoxPlowedLandNumber);
            this.groupBox1.Controls.Add(this.textBoxPlotNumber);
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
            this.groupBox1.Size = new System.Drawing.Size(1365, 146);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметри пошуку";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(448, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 27);
            this.label5.TabIndex = 15;
            this.label5.Text = "Орендар";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(157, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 27);
            this.label4.TabIndex = 14;
            this.label4.Text = "Населений пункт";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(453, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 30);
            this.textBox1.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(162, 110);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(257, 30);
            this.textBox3.TabIndex = 12;
            // 
            // textBoxHayField1Number
            // 
            this.textBoxHayField1Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHayField1Number.Location = new System.Drawing.Point(1042, 43);
            this.textBoxHayField1Number.Name = "textBoxHayField1Number";
            this.textBoxHayField1Number.Size = new System.Drawing.Size(143, 30);
            this.textBoxHayField1Number.TabIndex = 11;
            // 
            // textBoxHayField2Number
            // 
            this.textBoxHayField2Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHayField2Number.Location = new System.Drawing.Point(1204, 43);
            this.textBoxHayField2Number.Name = "textBoxHayField2Number";
            this.textBoxHayField2Number.Size = new System.Drawing.Size(138, 30);
            this.textBoxHayField2Number.TabIndex = 10;
            // 
            // textBoxPlowedLandNumber
            // 
            this.textBoxPlowedLandNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlowedLandNumber.Location = new System.Drawing.Point(906, 43);
            this.textBoxPlowedLandNumber.Name = "textBoxPlowedLandNumber";
            this.textBoxPlowedLandNumber.Size = new System.Drawing.Size(121, 30);
            this.textBoxPlowedLandNumber.TabIndex = 9;
            // 
            // textBoxPlotNumber
            // 
            this.textBoxPlotNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlotNumber.Location = new System.Drawing.Point(764, 43);
            this.textBoxPlotNumber.Name = "textBoxPlotNumber";
            this.textBoxPlotNumber.Size = new System.Drawing.Size(131, 30);
            this.textBoxPlotNumber.TabIndex = 8;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFullName.Location = new System.Drawing.Point(162, 43);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(566, 30);
            this.textBoxFullName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(759, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 27);
            this.label7.TabIndex = 6;
            this.label7.Text = "Номер поля";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(901, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 27);
            this.label6.TabIndex = 5;
            this.label6.Text = "Номер ріллі";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1199, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сінокіс2_Номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1037, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сінокіс1_Номер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(187, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПІП";
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
            // 
            // PlotSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(1389, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewВікноПошуку);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PlotSearch";
            this.Text = "PlotSearch";
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
        private System.Windows.Forms.TextBox textBoxHayField1Number;
        private System.Windows.Forms.TextBox textBoxHayField2Number;
        private System.Windows.Forms.TextBox textBoxPlowedLandNumber;
        private System.Windows.Forms.TextBox textBoxPlotNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClear;
    }
}