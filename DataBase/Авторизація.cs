using MySqlConnector;
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
    public partial class Авторизація : Form
    {
        private bool IsLogin
        {
            get
            {
                bool been = false;
                string loginUser = textBoxLogin.Text;
                string passwordUser = textBoxPassword.Text;

                ConnectionClass connectionClass = new ConnectionClass();
                DataTable _dataTable = new DataTable();
                MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `Логін`=@UserLogin AND `Пароль`=@UserPassword", connectionClass.getConnection());

                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;
                _mySqlCommand.Parameters.Add("@UserPassword", MySqlDbType.VarChar).Value = passwordUser;


                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    been = true;

                }
                else
                    been = false;

                return been;

            }
        }
        public Авторизація()
        {
            InitializeComponent();

            textBoxLogin.Text = "Введіть логін";
            textBoxLogin.ForeColor = Color.Gray;

            textBoxPassword.Text = "Введіть пароль";
            textBoxPassword.ForeColor = Color.Gray;
        }
        
        private void buttonРеєстрація_Click(object sender, EventArgs e)
        {
            Реєстрація form = new Реєстрація();
            this.Hide();
            form.Show();
        }

        private void buttonВхід_Click(object sender, EventArgs e)
        {
            string loginUser = textBoxLogin.Text;
            string passwordUser = textBoxPassword.Text;

            ConnectionClass connectionClass = new ConnectionClass();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM users WHERE Логін = @login AND Пароль = @password ", connectionClass.getConnection());

            try
            {
                _mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBoxLogin.Text;
                _mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBoxPassword.Text;

                connectionClass.openConnection();

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    Головна form = new Головна();
                    this.Hide();
                    form.Show();

                    User user = new User(loginUser);
                }
                else
                {
                    if(IsLogin)
                    {
                        MessageBox.Show("Пароль введено невірно !");
                    }
                    else
                    {
                        if(MessageBox.Show("Ви у нас вперше !\nНеобхідно зареєструватись\nЗареєструватись зараз ?",
                            (MessageBoxButtons.YesNo).ToString()) == DialogResult.Yes)
                        {
                            Реєстрація form = new Реєстрація();
                            this.Hide();
                            form.Show();
                        }
                    }
                }
                   
            }
            catch
            {
                MessageBox.Show("Помилка роботи з базою даних !");
            }
            finally
            {
                connectionClass.closeConnection();
            }
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Введіть логін")
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
            if (textBoxPassword.Text == "Введіть пароль")
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

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.Focus();
            }
        }
    }
}
