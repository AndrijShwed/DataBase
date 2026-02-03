namespace DataBase
{
    partial class Plot
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
            this.земляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rjButton1 = new DataBase.RJButton();
            this.Пошук = new DataBase.RJButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // головнаToolStripMenuItem
            // 
            this.головнаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.головнаToolStripMenuItem.Name = "головнаToolStripMenuItem";
            this.головнаToolStripMenuItem.Size = new System.Drawing.Size(121, 35);
            this.головнаToolStripMenuItem.Text = "Головна/";
            this.головнаToolStripMenuItem.Click += new System.EventHandler(this.головнаToolStripMenuItem_Click);
            // 
            // земляToolStripMenuItem
            // 
            this.земляToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.земляToolStripMenuItem.Name = "земляToolStripMenuItem";
            this.земляToolStripMenuItem.Size = new System.Drawing.Size(98, 35);
            this.земляToolStripMenuItem.Text = "Земля";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнаToolStripMenuItem,
            this.земляToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1294, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(127, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Додати земельну ділянку";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(646, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 38);
            this.label2.TabIndex = 6;
            this.label2.Text = "Знайти земельну ділянку";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundImage = Properties.Resources.Додати__Земельну_ділянку;
            this.rjButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(194, 96);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(214, 160);
            this.rjButton1.TabIndex = 4;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // Пошук
            // 
            this.Пошук.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Пошук.BackgroundImage = Properties.Resources.Пошук_Землі;
            this.Пошук.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Пошук.FlatAppearance.BorderSize = 0;
            this.Пошук.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Пошук.ForeColor = System.Drawing.Color.White;
            this.Пошук.Location = new System.Drawing.Point(716, 96);
            this.Пошук.Name = "Пошук";
            this.Пошук.Size = new System.Drawing.Size(224, 160);
            this.Пошук.TabIndex = 3;
            this.Пошук.UseVisualStyleBackColor = false;
            this.Пошук.Click += new System.EventHandler(this.Пошук_Click);
            // 
            // Plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(1294, 528);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.Пошук);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Plot";
            this.Text = "Plot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem головнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem земляToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private RJButton Пошук;
        private RJButton rjButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}