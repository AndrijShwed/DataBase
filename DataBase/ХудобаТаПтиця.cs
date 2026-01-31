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
    public partial class ХудобаТаПтиця : Form
    {
        public ХудобаТаПтиця()
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
            ХудобаТаПтицяПошук form = new ХудобаТаПтицяПошук();
            Program.OpenForm(this, form);
        }

        private void rjButtonДодати_Click(object sender, EventArgs e)
        {
            ХудобаТаПтицяДодати form = new ХудобаТаПтицяДодати();
            Program.OpenForm(this, form);
        }

        private void Statistic_Click(object sender, EventArgs e)
        {
            ХудобаТаПтицяСтатистика form = new ХудобаТаПтицяСтатистика();
            Program.OpenForm(this, form);
        }
    }
}
