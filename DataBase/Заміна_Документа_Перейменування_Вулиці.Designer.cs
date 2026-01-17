namespace DataBase
{
    partial class Заміна_Документа_Перейменування_Вулиці
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
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.повернутисьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.замінадокументаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxNewDoc = new System.Windows.Forms.TextBox();
            this.rjButtonChooseNewDoc = new DataBase.RJButton();
            this.rjButton1 = new DataBase.RJButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.toolStripMenuItem1,
            this.повернутисьToolStripMenuItem,
            this.замінадокументаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1270, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(116, 32);
            this.головнаToolStripMenuItem.Text = "Головна /";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 32);
            // 
            // повернутисьToolStripMenuItem
            // 
            this.повернутисьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.повернутисьToolStripMenuItem.Name = "повернутисьToolStripMenuItem";
            this.повернутисьToolStripMenuItem.Size = new System.Drawing.Size(159, 32);
            this.повернутисьToolStripMenuItem.Text = "Повернутись /";
            this.повернутисьToolStripMenuItem.Click += new System.EventHandler(this.повернутисьToolStripMenuItem_Click);
            // 
            // замінадокументаToolStripMenuItem
            // 
            this.замінадокументаToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.замінадокументаToolStripMenuItem.Name = "замінадокументаToolStripMenuItem";
            this.замінадокументаToolStripMenuItem.Size = new System.Drawing.Size(213, 32);
            this.замінадокументаToolStripMenuItem.Text = "Заміна_документа";
            // 
            // textBoxNewDoc
            // 
            this.textBoxNewDoc.Location = new System.Drawing.Point(30, 181);
            this.textBoxNewDoc.Name = "textBoxNewDoc";
            this.textBoxNewDoc.Size = new System.Drawing.Size(799, 34);
            this.textBoxNewDoc.TabIndex = 1;
            // 
            // rjButtonChooseNewDoc
            // 
            this.rjButtonChooseNewDoc.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtonChooseNewDoc.FlatAppearance.BorderSize = 0;
            this.rjButtonChooseNewDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonChooseNewDoc.ForeColor = System.Drawing.Color.White;
            this.rjButtonChooseNewDoc.Location = new System.Drawing.Point(855, 143);
            this.rjButtonChooseNewDoc.Name = "rjButtonChooseNewDoc";
            this.rjButtonChooseNewDoc.Size = new System.Drawing.Size(378, 111);
            this.rjButtonChooseNewDoc.TabIndex = 2;
            this.rjButtonChooseNewDoc.Text = "Виберіть документ про перейменування";
            this.rjButtonChooseNewDoc.UseVisualStyleBackColor = false;
            this.rjButtonChooseNewDoc.Click += new System.EventHandler(this.rjButtonChooseNewDoc_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Red;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(332, 297);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(398, 54);
            this.rjButton1.TabIndex = 3;
            this.rjButton1.Text = "Зберегти";
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // Заміна_Документа_Перейменування_Вулиці
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1270, 426);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.rjButtonChooseNewDoc);
            this.Controls.Add(this.textBoxNewDoc);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Заміна_Документа_Перейменування_Вулиці";
            this.Text = "Заміна_Документа_Перейменування_Вулиці";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem повернутисьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem замінадокументаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxNewDoc;
        private RJButton rjButtonChooseNewDoc;
        private RJButton rjButton1;
    }
}