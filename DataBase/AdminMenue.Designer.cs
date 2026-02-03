namespace DataBase
{
    partial class AdminMenue
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
            this.rjButtonДодатиКористувача = new DataBase.RJButton();
            this.rjButton3 = new DataBase.RJButton();
            this.rjButtonВидалитиКористувача = new DataBase.RJButton();
            this.SuspendLayout();
            // 
            // rjButtonДодатиКористувача
            // 
            this.rjButtonДодатиКористувача.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtonДодатиКористувача.FlatAppearance.BorderSize = 0;
            this.rjButtonДодатиКористувача.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonДодатиКористувача.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rjButtonДодатиКористувача.ForeColor = System.Drawing.Color.White;
            this.rjButtonДодатиКористувача.Location = new System.Drawing.Point(33, 39);
            this.rjButtonДодатиКористувача.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.rjButtonДодатиКористувача.Name = "rjButtonДодатиКористувача";
            this.rjButtonДодатиКористувача.Size = new System.Drawing.Size(343, 52);
            this.rjButtonДодатиКористувача.TabIndex = 0;
            this.rjButtonДодатиКористувача.Text = "Додати користувача";
            this.rjButtonДодатиКористувача.UseVisualStyleBackColor = false;
            this.rjButtonДодатиКористувача.Click += new System.EventHandler(this.rjButtonДодатиКористувача_Click);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Location = new System.Drawing.Point(33, 120);
            this.rjButton3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(343, 51);
            this.rjButton3.TabIndex = 2;
            this.rjButton3.Text = "Редагувати користувача";
            this.rjButton3.UseVisualStyleBackColor = false;
            // 
            // rjButtonВидалитиКористувача
            // 
            this.rjButtonВидалитиКористувача.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtonВидалитиКористувача.FlatAppearance.BorderSize = 0;
            this.rjButtonВидалитиКористувача.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonВидалитиКористувача.ForeColor = System.Drawing.Color.White;
            this.rjButtonВидалитиКористувача.Location = new System.Drawing.Point(33, 200);
            this.rjButtonВидалитиКористувача.Name = "rjButtonВидалитиКористувача";
            this.rjButtonВидалитиКористувача.Size = new System.Drawing.Size(343, 50);
            this.rjButtonВидалитиКористувача.TabIndex = 3;
            this.rjButtonВидалитиКористувача.Text = "Видалити користувача";
            this.rjButtonВидалитиКористувача.UseVisualStyleBackColor = false;
            // 
            // AdminMenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(852, 446);
            this.Controls.Add(this.rjButtonВидалитиКористувача);
            this.Controls.Add(this.rjButton3);
            this.Controls.Add(this.rjButtonДодатиКористувача);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "AdminMenue";
            this.Text = "AdminMenue";
            this.ResumeLayout(false);

        }

        #endregion

        private RJButton rjButtonДодатиКористувача;
        private RJButton rjButton3;
        private RJButton rjButtonВидалитиКористувача;
    }
}