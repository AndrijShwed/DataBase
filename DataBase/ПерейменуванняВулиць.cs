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
        private List<Village> dataVillage = new List<Village>();
        private List<Street> dataStreet = new List<Street>();
        //private User user;

        public ПерейменуванняВулиць()
        {
            InitializeComponent();
            bool mess = false;
            dataVillage.Clear();
            comboBoxНаселенийПункт.Items.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT * FROM villages";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                Village row = new Village(_reader["name"].ToString());
                dataVillage.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < dataVillage.Count; i++)
            {
                AddDataGrid(dataVillage[i]);
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

        private void AddDataGrid(Village row)
        {
            comboBoxНаселенийПункт.Items.Add(row.Name);
        }


        private void AddDataGrid_1(Street row)
        {
            comboBoxСтараНазваВулиці.Items.Add(row.Name);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void comboBoxНаселенийПункт_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxСтараНазваВулиці.Items.Clear();
            dataStreet.Clear();
            bool mess = false;
            string village = comboBoxНаселенийПункт.Text;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT s.id, s.name FROM streets s JOIN villagestreet ss ON ss.streetId = s.id" +
                "JOIN villages st ON st.id = villageId WHERE st.name = '" + village + "' AND st.isActive = 1 ORDER BY s.name";
            MySqlCommand _search1 = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search1.ExecuteReader();

            while (_reader.Read())
            {
                Street row = new Street(_reader["name"].ToString());
                dataStreet.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < dataStreet.Count; i++)
            {
                AddDataGrid_1(dataStreet[i]);
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
