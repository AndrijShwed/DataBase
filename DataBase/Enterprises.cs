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
    public partial class Enterprises : Form
    {
        public Enterprises()
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

        private void rjButtonПошук_Click(object sender, EventArgs e)
        {
            EnterpriseSearch form = new EnterpriseSearch();
            Program.OpenForm(this, form);
        }

        private void ButtonПідприємства_Click(object sender, EventArgs e)
        {
            EnterpriseAdd form = new EnterpriseAdd();
            Program.OpenForm(this, form);
        }
    }
}
