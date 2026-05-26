namespace DataBase
{
    partial class Enterprises
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enterprises));
            this.labelПошук = new System.Windows.Forms.Label();
            this.labelДодати = new System.Windows.Forms.Label();
            this.rjButtonПошук = new DataBase.RJButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.головнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.населенняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonПідприємства = new DataBase.RJButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelПошук
            // 
            this.labelПошук.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelПошук.AutoSize = true;
            this.labelПошук.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelПошук.ForeColor = System.Drawing.Color.Black;
            this.labelПошук.Location = new System.Drawing.Point(504, 343);
            this.labelПошук.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelПошук.Name = "labelПошук";
            this.labelПошук.Size = new System.Drawing.Size(507, 46);
            this.labelПошук.TabIndex = 13;
            this.labelПошук.Text = "Пошук Редагування Видалення";
            // 
            // labelДодати
            // 
            this.labelДодати.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelДодати.AutoSize = true;
            this.labelДодати.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelДодати.ForeColor = System.Drawing.Color.Black;
            this.labelДодати.Location = new System.Drawing.Point(114, 343);
            this.labelДодати.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelДодати.Name = "labelДодати";
            this.labelДодати.Size = new System.Drawing.Size(139, 46);
            this.labelДодати.TabIndex = 12;
            this.labelДодати.Text = "Додати";
            // 
            // rjButtonПошук
            // 
            this.rjButtonПошук.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rjButtonПошук.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.rjButtonПошук.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButtonПошук.BackgroundImage")));
            this.rjButtonПошук.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rjButtonПошук.FlatAppearance.BorderSize = 0;
            this.rjButtonПошук.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonПошук.ForeColor = System.Drawing.Color.White;
            this.rjButtonПошук.Location = new System.Drawing.Point(627, 181);
            this.rjButtonПошук.Margin = new System.Windows.Forms.Padding(2);
            this.rjButtonПошук.Name = "rjButtonПошук";
            this.rjButtonПошук.Size = new System.Drawing.Size(160, 160);
            this.rjButtonПошук.TabIndex = 11;
            this.rjButtonПошук.UseVisualStyleBackColor = false;
            this.rjButtonПошук.Click += new System.EventHandler(this.rjButtonПошук_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.населенняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1077, 34);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(114, 32);
            this.головнаToolStripMenuItem.Text = "Головна /";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // населенняToolStripMenuItem
            // 
            this.населенняToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.населенняToolStripMenuItem.Name = "населенняToolStripMenuItem";
            this.населенняToolStripMenuItem.Size = new System.Drawing.Size(169, 32);
            this.населенняToolStripMenuItem.Text = "Підприємства";
            // 
            // ButtonПідприємства
            // 
            this.ButtonПідприємства.BackColor = System.Drawing.Color.LightPink;
            this.ButtonПідприємства.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonПідприємства.BackgroundImage")));
            this.ButtonПідприємства.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonПідприємства.FlatAppearance.BorderSize = 0;
            this.ButtonПідприємства.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonПідприємства.ForeColor = System.Drawing.Color.White;
            this.ButtonПідприємства.Location = new System.Drawing.Point(103, 181);
            this.ButtonПідприємства.Name = "ButtonПідприємства";
            this.ButtonПідприємства.Size = new System.Drawing.Size(160, 160);
            this.ButtonПідприємства.TabIndex = 15;
            this.ButtonПідприємства.UseVisualStyleBackColor = false;
            this.ButtonПідприємства.Click += new System.EventHandler(this.ButtonПідприємства_Click);
            // 
            // Enterprises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1077, 501);
            this.Controls.Add(this.ButtonПідприємства);
            this.Controls.Add(this.labelПошук);
            this.Controls.Add(this.labelДодати);
            this.Controls.Add(this.rjButtonПошук);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Enterprises";
            this.Text = "Enterprises";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelПошук;
        private System.Windows.Forms.Label labelДодати;
        private RJButton rjButtonПошук;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem населенняToolStripMenuItem;
        private RJButton ButtonПідприємства;
    }
}