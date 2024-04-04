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
            Головна form = new Головна();
            this.Hide();
            form.Show();
        }

        private void rjButtonПошук_Click(object sender, EventArgs e)
        {
            ХудобаТаПтицяПошук form = new ХудобаТаПтицяПошук();
            this.Hide();
            form.Show();
        }

        private void rjButtonДодати_Click(object sender, EventArgs e)
        {
            ХудобаТаПтицяДодати form = new ХудобаТаПтицяДодати(); 
            this.Hide();
            form.Show();
        }

        private void Statistic_Click(object sender, EventArgs e)
        {
            ХудобаТаПтицяСтатистика form = new ХудобаТаПтицяСтатистика();
            this.Hide();
            form.Show();
        }
    }
}
