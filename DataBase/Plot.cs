using System;
using System.Linq;
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
            Головна form = Application.OpenForms.OfType<Головна>().FirstOrDefault();
            if(form != null)
            {
                form.BringToFront();
                form.Focus();
            }
            else
            {
                form = new Головна();
                form.Show();
            }
            this.Close();
        }

        private void Пошук_Click(object sender, EventArgs e)
        {
            PlotSearch form = new PlotSearch();
            Program.OpenForm(this, form);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            AddPlot form = new AddPlot();
            Program.OpenForm(this, form);
        }
    }
}
