using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace DataBase
{
    public partial class Реєстрація : Form
    {
        public Реєстрація()
        {
            InitializeComponent();

            textBoxName.Text = "Введіть ім'я";
            textBoxName.ForeColor = Color.Gray;

            textBoxSurname.Text = "Введіть прізвище";
            textBoxSurname.ForeColor = Color.Gray;

            textBoxLogin.Text = "Введіть логін";
            textBoxLogin.ForeColor = Color.Gray;

            textBoxPassword.Text = "Введіть пароль";
            textBoxPassword.ForeColor = Color.Gray;
        }
        private bool IsUser
        {
            get
            {
                bool been = false;

                string loginUser = textBoxLogin.Text.ToString().Replace("'", "`").Replace('"', '`');
                string nameUser = textBoxName.Text.ToString().Replace("'", "`").Replace('"', '`');
                string surnameUser = textBoxSurname.Text.ToString().Replace("'", "`").Replace('"', '`');

                ConnectionClass connectionClass = new ConnectionClass();
                DataTable _dataTable = new DataTable();
                MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `Логін`=@UserLogin AND `Ім_я`=@UserName AND `Прізвище`=@UserSurname", connectionClass.getConnection());

                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;
                _mySqlCommand.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = nameUser;
                _mySqlCommand.Parameters.Add("@UserSurname", MySqlDbType.VarChar).Value = surnameUser;

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    been = true;
                    if (MessageBox.Show("Такий користувач вже є !\nПерейти на вкладку входу ?", (MessageBoxButtons.YesNo).ToString()) == DialogResult.Yes)
                    {
                        Авторизація form = new Авторизація();
                        this.Hide();
                        form.Show();

                    }
                }
                else
                    been = false;

                return been;
            }
        }

        private bool IsLogin
        {
            get
            {
                bool been = false;
                string loginUser = textBoxLogin.Text.ToString().Replace("'", "`").Replace('"', '`');
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
                    MessageBox.Show("Такий логін вже є !\nСпробуйте інший логін !");
                }
                else
                    been = false;

                return been;

            }
        }


        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if(textBoxName.Text == "Введіть ім'я")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor= Color.Black;
            }

        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Введіть ім'я";
                textBoxName.ForeColor = Color.Gray;
            }

        }

        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if(textBoxSurname.Text == "Введіть прізвище")
            {
                textBoxSurname.Text = "";
                textBoxSurname.ForeColor = Color.Black;
            }   
        }

        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                textBoxSurname.Text = "Введіть прізвище";
                textBoxSurname.ForeColor = Color.Gray;
            }
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

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text == "Введіть ім'я" || textBoxLogin.Text == "Введіть логін"
                || textBoxSurname.Text == "Введіть прізвище" || textBoxPassword.Text == "Введіть пароль")
            {
                MessageBox.Show("Не всі поля введені !");
                return;
            }

            if(!IsUser)
            {
                if(!IsLogin)
                {
                    ConnectionClass connectionClass = new ConnectionClass();
                    MySqlCommand _mySqlCommand = new MySqlCommand("INSERT INTO `users`(`Ім_я`,`Прізвище`,`Логін`,`Пароль`)" +
                        "VALUES (@name,@surname,@login,@password)", connectionClass.getConnection());

                    try
                    {
                        _mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxName.Text.ToString().Replace("'", "`").Replace('"', '`');
                        _mySqlCommand.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSurname.Text.ToString().Replace("'", "`").Replace('"', '`');
                        _mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBoxLogin.Text.ToString().Replace("'", "`").Replace('"', '`');
                        _mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBoxPassword.Text;

                        connectionClass.openConnection();

                        if (_mySqlCommand.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Акаунт створено !");

                            Головна form = new Головна();
                            this.Hide();
                            form.Show();

                            User user = new User(textBoxLogin.Text);
                        }
                        else
                            MessageBox.Show("Помилка створення акаунта !");
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
            }
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSurname.Focus();
            }
        }

        private void textBoxSurname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxLogin.Focus();
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
