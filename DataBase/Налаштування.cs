using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Налаштування : Form
    {
        List<ConnectionClass> options = new List<ConnectionClass>();

        public Налаштування()
        {
            InitializeComponent();
            HeaderOfTheTable();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = Application.OpenForms.OfType<Головна>().FirstOrDefault();
            if (form != null)
            {
                form.BringToFront();
                form.Focus();
            }
            else
            {
                form = new Головна();
                form.Show();
            }
            Close();
        }

        private void HeaderOfTheTable()
        {
            this.dataGridViewProp.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewProp.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewProp.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewProp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewProp.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;

            this.dataGridViewProp.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 55;
            column1.Name = "id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Сервер";
            column2.Width = 110;
            column2.Name = "server";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Користувач";
            column3.Width = 100;
            column3.Name = "user";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "База дааних";
            column4.Width = 120;
            column4.Name = "database";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Пароль";
            column5.Width = 60;
            column5.Name = "password";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            dataGridViewProp.Columns.Add(column1);
            dataGridViewProp.Columns.Add(column2);
            dataGridViewProp.Columns.Add(column3);
            dataGridViewProp.Columns.Add(column4);
            dataGridViewProp.Columns.Add(column5);
           
            dataGridViewProp.AllowUserToAddRows = false;
            dataGridViewProp.ReadOnly = true;
        }

        private void Зберегти_Click(object sender, EventArgs e)
        {
            string server = textBoxСервер.Text;
            string user = textBoxКористувач.Text;
            string database = textBoxБаза_даних.Text;
            string password = textBoxПароль.Text;

            ConnectionClass manager = new ConnectionClass();

            if(server != null && user != null && database != null && password != null)
            {
                try
                {
                    manager.openConnection();
                    string addOpt = " INSERT INTO `options`(`server`,`user`,`database`,`password`)VALUES" +
                        "('" + server + "','" + user + "','" + database + "','" + password + "') ";
                    MySqlCommand command = new MySqlCommand(addOpt, manager.getConnection());
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Помилка роботи з базою даних !");
                }
            }
            else
            {
                MessageBox.Show("Спочатку заповніть усі поля !");
            }


        }
    }
}
