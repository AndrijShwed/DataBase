using System;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace DataBase
{
    public partial class Реєстрація : Form
    {
        public Реєстрація()
        {
            InitializeComponent();

            textBoxLogin.Text = "Введіть логін";
            textBoxLogin.ForeColor = Color.Gray;

            textBoxPassword.Text = "Введіть пароль";
            textBoxPassword.ForeColor = Color.Gray;

            textBoxRole.Text = "Введіть роль";
            textBoxRole.ForeColor = Color.Gray;
           
        }

       
        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if(textBoxLogin.Text == "Введіть логін")
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.Black;
            }
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Введіть логін";
                textBoxLogin.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if(textBoxPassword.Text == "Введіть пароль")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Введіть пароль";
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxRole_Enter(object sender, EventArgs e)
        {
            if (textBoxRole.Text == "Введіть роль")
            {
                textBoxRole.Text = "";
                textBoxRole.ForeColor = Color.Black;
            }
        }

        private void textBoxRole_Leave(object sender, EventArgs e)
        {
            if (textBoxRole.Text == "")
            {
                textBoxRole.Text = "Введіть роль";
                textBoxRole.ForeColor = Color.Black;
            }
        }
        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            string hash = SecurityHelper.HashPassword(textBoxPassword.Text);

            string query = "INSERT INTO users(login,password_hash,role) VALUES(@l,@p,@r)";

            using (ConnectionClass conn = new ConnectionClass())
            {
                conn.openConnection();
                MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                cmd.Parameters.AddWithValue("@l", textBoxLogin.Text);
                cmd.Parameters.AddWithValue("@p", hash);
                cmd.Parameters.AddWithValue("@r", textBoxRole.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Користувача створено");
        }

        
    }
}
