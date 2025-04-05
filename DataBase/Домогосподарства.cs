using System;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Домогосподарства : Form
    {
        public Домогосподарства()
        {
            InitializeComponent();
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = Application.OpenForms.OfType<Головна>().FirstOrDefault();
            if (form != null)
            {
                form.BringToFront();
                form.Focus();
            }
            else
            {
                form = new Головна();
                form.Show();
            }
            Close();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Додати_Click(object sender, EventArgs e)
        {
            ДомогосподарстваДодати form = new ДомогосподарстваДодати();
            this.Hide();
            form.Show();    
        }

        private void Пошук_Click(object sender, EventArgs e)
        {
            Домогосподарства_Пошук form = new Домогосподарства_Пошук();
            this.Hide();
            form.Show();
        }

        private void ДаніПоПлощах_Click(object sender, EventArgs e)
        {
            Площі_Будинків form = new Площі_Будинків();
            this.Hide();
            form.Show();
        }

        private void По_Кількості_кімнат_Click(object sender, EventArgs e)
        {
            ПоКількостіКімнат form = new ПоКількостіКімнат();
            this.Hide();
            form.Show();
        }
    }
}
