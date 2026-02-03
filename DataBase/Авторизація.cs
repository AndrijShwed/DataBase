using DataBase.Repositories;
using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Авторизація : Form
    {
        public Авторизація()
        {
            InitializeComponent();

        }
        
        private void buttonВхід_Click(object sender, EventArgs e)
        {
            AuthRepository repo = new AuthRepository();
            var user = repo.Authenticate(textBoxLogin.Text, textBoxPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Невірний логін або пароль");
                return;
            }

            Session.CurrentUser = user;

            textBoxPassword.UseSystemPasswordChar = true;

            Головна form = new Головна();
            Program.OpenForm(this, form);

        }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.Focus();
            }
        }


        private bool passwordVisible = false;
        private void buttonEye_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            textBoxPassword.UseSystemPasswordChar = !passwordVisible;

        }
    }
}
