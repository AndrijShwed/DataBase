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
    public partial class Plot: Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Close();
            form.Show();
        }

        private void Пошук_Click(object sender, EventArgs e)
        {
            PlotSearch form = new PlotSearch();
            this.Close();
            form.Show();
        }
    }
}
