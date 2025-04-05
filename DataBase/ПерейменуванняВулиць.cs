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
    public partial class ПерейменуванняВулиць : Form
    {
        private List<VillageStreet> data = new List<VillageStreet>();
        //private User user;

        public ПерейменуванняВулиць()
        {
            InitializeComponent();
            bool mess = false;
            data.Clear();
            comboBoxНаселенийПункт.Items.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT DISTINCT village FROM villagestreet";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet(_reader["village"]);
                data.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid(data[i]);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Помилка роботи з базою даних !");
            }
            _manager.closeConnection();

        }

        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
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

        private void ЗамінитиІЗберегти_Click(object sender, EventArgs e)
        {
           // user = new User();

           // if (user.userName == "A")
           // {

                string NewName = Convert.ToString(НоваНазва.Text);

                string village = comboBoxНаселенийПункт.Text;

                string OldName = Convert.ToString(comboBoxСтараНазваВулиці.Text);

                ConnectionClass _manager = new ConnectionClass();


                if (OldName == "" || НоваНазва.Text == "" || village == "")
                {
                    MessageBox.Show("Заповніть будь ласка дані !");

                }
                else
                {
                    string _commandString = "UPDATE people SET street = '" + NewName + "'" +
                        " WHERE street = '" + OldName + "' AND village = '" + village + "'";

                    string _commandString1 = "UPDATE villagestreet SET street = '" + NewName + "'" +
                       " WHERE street = '" + OldName + "' AND village = '" + village + "'";

                    string _commandString2 = "UPDATE houses SET street = '" + NewName + "'" +
                       " WHERE street = '" + OldName + "' AND village = '" + village + "'";

                    MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());
                    MySqlCommand _command1 = new MySqlCommand(_commandString1, _manager.getConnection());
                    MySqlCommand _command2 = new MySqlCommand(_commandString2, _manager.getConnection());

                    try
                    {
                        _manager.openConnection();
                        _command.ExecuteNonQuery();
                        _command1.ExecuteNonQuery();
                        _command2.ExecuteNonQuery();

                        if (_command.ExecuteNonQuery() != 1)

                            MessageBox.Show("Назву вулиці замінено успішно !");

                    }
                    catch
                    {
                        MessageBox.Show("Помилка роботи з базою даних !");
                    }
                    _manager.closeConnection();
                }

            //}
            //else
            //    MessageBox.Show("У вас немає доступу до зміни даних в таблиці !");
        }

        private void AddDataGrid(VillageStreet row)
        {
            comboBoxНаселенийПункт.Items.Add(row.village);
        }


        private void AddDataGrid_1(VillageStreet row)
        {
            comboBoxСтараНазваВулиці.Items.Add(row.village);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void comboBoxНаселенийПункт_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxСтараНазваВулиці.Items.Clear();
            data.Clear();
            bool mess = false;
            string village = comboBoxНаселенийПункт.Text;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT street FROM villagestreet WHERE village = '" + village + "'";
            MySqlCommand _search1 = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search1.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet(_reader["street"]);
                data.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid_1(data[i]);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Помилка роботи з базою даних  !");
            }
            _manager.closeConnection();
        }
    }
}
