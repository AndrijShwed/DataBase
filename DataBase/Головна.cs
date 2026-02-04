using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Головна : Form
    {
       
        public Головна()
        {
            InitializeComponent();
            //labelUsers.Text = $"{Session.CurrentUser.Login} ({Session.CurrentUser.Role})";
            //labelUser.Left = this.ClientSize.Width - labelUser.Width - 10;

            //if (Session.CurrentUser.Role != "Admin")
            //{
            //    rjButtonAdminMenue.Visible = false;
            //}
        }

        private void ButtonНаселення_MouseClick(object sender, MouseEventArgs e)
        {
            Населення form = new Населення();
            Program.OpenForm(this, form);
        }

        private void ButtonНаселеніПункти_MouseClick(object sender, MouseEventArgs e)
        {
            Населені_Пункти form = new Населені_Пункти();
            Program.OpenForm(this, form);
        }

        private void ПерейменуванняВулиць_MouseClick(object sender, MouseEventArgs e)
        {
            ПерейменуванняВулиць form = new ПерейменуванняВулиць();
            Program.OpenForm(this, form);
        }

        private void ButtonДомогосподарства_MouseClick(object sender, MouseEventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
        }

        private void rjButtonДодати_Click(object sender, EventArgs e)
        {
            ХудобаТаПтиця form = new ХудобаТаПтиця();
            Program.OpenForm(this, form);
        }

        private void rjButton1_MouseClick(object sender, MouseEventArgs e)
        {
            ПочатокРоботи form = new ПочатокРоботи();
            Program.OpenForm(this, form);
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            //ExportToDBfromExcel form = new ExportToDBfromExcel();
            //form.Show();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            Plot form = new Plot(); 
            Program.OpenForm(this, form);
        }

        private void rjButtonAdminMenue_Click(object sender, EventArgs e)
        {
            AdminMenue form = new AdminMenue();
            Program.OpenForm(this, form);
        }

        private void rjButtonВийти_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            //Авторизація login = new Авторизація();
            //login.Show();
            this.Close();
        }
    }
}

