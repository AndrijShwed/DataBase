using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Головна : Form
    {
       
        public Головна()
        {
            InitializeComponent();
        }

        private void ButtonНаселення_MouseClick(object sender, MouseEventArgs e)
        {
            Населення form = new Населення();
            //this.Hide();
            form.Show();
        }

        private void ButtonНаселеніПункти_MouseClick(object sender, MouseEventArgs e)
        {
            Населені_Пункти form = new Населені_Пункти();
            //this.Hide();
            form.Show();
        }

        private void ПерейменуванняВулиць_MouseClick(object sender, MouseEventArgs e)
        {
            ПерейменуванняВулиць form = new ПерейменуванняВулиць();
            //this.Hide();
            form.Show();
        }

        private void ButtonДомогосподарства_MouseClick(object sender, MouseEventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            //this.Hide();
            form.Show();
        }

        private void rjButtonДодати_Click(object sender, EventArgs e)
        {
            ХудобаТаПтиця form = new ХудобаТаПтиця();
            //this.Hide();
            form.Show();
        }

        private void rjButton1_MouseClick(object sender, MouseEventArgs e)
        {
            ПочатокРоботи form = new ПочатокРоботи();
            //this.Hide();
            form.Show();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            //ExportToDBfromExcel form = new ExportToDBfromExcel();
            //form.Show();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            Plot form = new Plot(); 
            form.Show();
        }
    }
}

