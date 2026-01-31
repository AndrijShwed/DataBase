using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Населення : Form
    {
        public Населення()
        {
            InitializeComponent();
        }

        private void rjButtonПошук_Click(object sender, EventArgs e)
        {
            ВікноПошуку form = new ВікноПошуку();
            Program.OpenForm(this, form);
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

        private void ButtonПовернутись_Click(object sender, EventArgs e)
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

       
        private void rjButtonДодати_Click(object sender, EventArgs e)
        {
            Додати form = new Додати();
            Program.OpenForm(this, form);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
