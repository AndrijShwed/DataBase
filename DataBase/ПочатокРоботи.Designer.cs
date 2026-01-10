namespace DataBase
{
    partial class ПочатокРоботи
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ДодатиВТаблицю = new System.Windows.Forms.Button();
            this.НазваНасПункту = new System.Windows.Forms.TextBox();
            this.НазваВулиці = new System.Windows.Forms.TextBox();
            this.dataGridViewПочатокРоботи = new System.Windows.Forms.DataGridView();
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.початокРоботиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повернутисьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewПочатокРоботи)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введіть назву населеного пункту";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(513, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введіть назву вулиці";
            // 
            // ДодатиВТаблицю
            // 
            this.ДодатиВТаблицю.BackColor = System.Drawing.Color.IndianRed;
            this.ДодатиВТаблицю.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ДодатиВТаблицю.Location = new System.Drawing.Point(879, 109);
            this.ДодатиВТаблицю.Name = "ДодатиВТаблицю";
            this.ДодатиВТаблицю.Size = new System.Drawing.Size(315, 42);
            this.ДодатиВТаблицю.TabIndex = 3;
            this.ДодатиВТаблицю.Text = "Додати в таблицю";
            this.ДодатиВТаблицю.UseVisualStyleBackColor = false;
            this.ДодатиВТаблицю.Click += new System.EventHandler(this.ДодатиВТаблицю_Click);
            // 
            // НазваНасПункту
            // 
            this.НазваНасПункту.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.НазваНасПункту.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.НазваНасПункту.Location = new System.Drawing.Point(12, 115);
            this.НазваНасПункту.Name = "НазваНасПункту";
            this.НазваНасПункту.Size = new System.Drawing.Size(392, 34);
            this.НазваНасПункту.TabIndex = 4;
            // 
            // НазваВулиці
            // 
            this.НазваВулиці.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.НазваВулиці.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.НазваВулиці.Location = new System.Drawing.Point(446, 115);
            this.НазваВулиці.Name = "НазваВулиці";
            this.НазваВулиці.Size = new System.Drawing.Size(392, 34);
            this.НазваВулиці.TabIndex = 5;
            // 
            // dataGridViewПочатокРоботи
            // 
            this.dataGridViewПочатокРоботи.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewПочатокРоботи.Location = new System.Drawing.Point(18, 184);
            this.dataGridViewПочатокРоботи.Name = "dataGridViewПочатокРоботи";
            this.dataGridViewПочатокРоботи.RowHeadersWidth = 51;
            this.dataGridViewПочатокРоботи.RowTemplate.Height = 24;
            this.dataGridViewПочатокРоботи.Size = new System.Drawing.Size(1500, 750);
            this.dataGridViewПочатокРоботи.TabIndex = 6;
            this.dataGridViewПочатокРоботи.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewПочатокРоботи_CellContentClick);
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(104, 27);
            this.головнаToolStripMenuItem.Text = "Головна /";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // початокРоботиToolStripMenuItem
            // 
            this.початокРоботиToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.початокРоботиToolStripMenuItem.Name = "початокРоботиToolStripMenuItem";
            this.початокРоботиToolStripMenuItem.Size = new System.Drawing.Size(165, 27);
            this.початокРоботиToolStripMenuItem.Text = "Початок роботи";
            // 
            // повернутисьToolStripMenuItem
            // 
            this.повернутисьToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.повернутисьToolStripMenuItem.Name = "повернутисьToolStripMenuItem";
            this.повернутисьToolStripMenuItem.Size = new System.Drawing.Size(161, 27);
            this.повернутисьToolStripMenuItem.Text = "<< Повернутись";
            this.повернутисьToolStripMenuItem.Click += new System.EventHandler(this.повернутисьToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(74, 27);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.початокРоботиToolStripMenuItem,
            this.повернутисьToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1464, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ПочатокРоботи
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 929);
            this.Controls.Add(this.dataGridViewПочатокРоботи);
            this.Controls.Add(this.НазваВулиці);
            this.Controls.Add(this.НазваНасПункту);
            this.Controls.Add(this.ДодатиВТаблицю);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ПочатокРоботи";
            this.Text = "ПочатокРоботи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewПочатокРоботи)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ДодатиВТаблицю;
        private System.Windows.Forms.TextBox НазваНасПункту;
        private System.Windows.Forms.TextBox НазваВулиці;
        private System.Windows.Forms.DataGridView dataGridViewПочатокРоботи;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem початокРоботиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повернутисьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}