namespace DataBase
{
    partial class ExportToDBfromExcel
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
            this.buttonChoose = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.textBoxTableOfDB = new System.Windows.Forms.TextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(467, 60);
            this.buttonChoose.Margin = new System.Windows.Forms.Padding(5);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(131, 42);
            this.buttonChoose.TabIndex = 0;
            this.buttonChoose.Text = "Вибрати";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(24, 64);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(435, 34);
            this.textBoxFilePath.TabIndex = 1;
            this.textBoxFilePath.Text = "Виберіть файл Excel";
            // 
            // textBoxTableOfDB
            // 
            this.textBoxTableOfDB.Location = new System.Drawing.Point(24, 176);
            this.textBoxTableOfDB.Name = "textBoxTableOfDB";
            this.textBoxTableOfDB.Size = new System.Drawing.Size(435, 34);
            this.textBoxTableOfDB.TabIndex = 2;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(120, 297);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(166, 44);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Виконати";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вкажіть таблицю бази даних";
            // 
            // ExportToDBfromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1396, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.textBoxTableOfDB);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.buttonChoose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ExportToDBfromExcel";
            this.Text = "ExportToDBfromExcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.TextBox textBoxTableOfDB;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label label1;
    }
}