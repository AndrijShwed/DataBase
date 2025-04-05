using OfficeOpenXml.ConditionalFormatting;
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
    public partial class PlotSearch: Form
    {
        public PlotSearch()
        {
            InitializeComponent();
        }

        private void головToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Close();
        }

        private void земляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot form = new Plot();
            this.Close();
            form.Show();
        }

       
    }
}
