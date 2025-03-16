using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Додати : Form
    {
        private List<VillageStreet> data = new List<VillageStreet>();
       
       // private User user;

        public Додати()
        {
            InitializeComponent();

            comboBoxVillage.Text = "Виберіть населений пункт";
           

            bool mess = false;
            data.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT DISTINCT village FROM villagestreet";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet( _reader["village"]);
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
                MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            }
            _manager.closeConnection();
          
        }

        private void AddDataGrid(VillageStreet row)
        {
            comboBoxVillage.Items.Add(row.village);
        }


        private void AddDataGrid_1(VillageStreet row)
        {
            comboBoxStreets.Items.Add(row.village);
        }


        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Hide();
            form.Show();
        }

        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonПовернутись_Click_1(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
        }


        private void переглядДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ВивідДаних form = new ВивідДаних();
            this.Hide();
            form.Show();
        }



        }

        private void buttonЗберегти_В_Таблицю_Click(object sender, EventArgs e)
        {
            rowNumber = 0;
            bool a = false;
            bool add = false;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

                try
                {
                    _manager.openConnection();

                    string lastname = this.dataGridViewДодати.Rows[current].Cells[1].Value.ToString().Replace("'", "`").Replace('"', '`');
                    string name = this.dataGridViewДодати.Rows[current].Cells[2].Value.ToString().Replace("'", "`").Replace('"', '`'); 
                    string surname = this.dataGridViewДодати.Rows[current].Cells[3].Value.ToString().Replace("'", "`").Replace('"', '`'); 
                    string sex = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[4].Value);
                    string date_of_birth = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[5].Value);
                    string m_date = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[14].Value);
                    string registr = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[13].Value);
                    
                    string s1 = date_of_birth.Substring(0, 2);
                    string s2 = date_of_birth.Substring(3, 2);
                    string s3 = date_of_birth.Substring(6, 4);
                    string s4 = m_date.Substring(0, 2);
                    string s5 = m_date.Substring(3, 2);
                    string s6 = m_date.Substring(6, 4);

                    if (lastname != "" && name != "" && surname != "" && sex != "" && date_of_birth != "дд.мм.рррр" && registr !="")
                    {
                        date_of_birth = s3 + "-" + s2 + "-" + s1;
                        string equal = "SELECT * FROM people WHERE lastname = '" + lastname + "' AND" +
                           " name = '" + name + "' AND surname = '" + surname + "' AND " +
                             "date_of_birth = '" + date_of_birth + "'";

                        MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                        _reader = search.ExecuteReader();
                        a = _reader.HasRows;
                        _reader.Close();

                        if (a)
                        {
                            current++;

                        }
                        else
                        {
                            try
                            {
                                    m_date = s6 + '/' + s5 + '/' + s4;
                                    DateTime m_date1 = Convert.ToDateTime(m_date);

                                    date_of_birth = s3 + '/' + s2 + '/' + s1;
                                    DateTime date_of_birth1 = Convert.ToDateTime(date_of_birth);
                                    if (date_of_birth1 > DateTime.Now)
                                    {
                                        MessageBox.Show("Дата народження не може бути новішою за поточну дату !");
                                    }
                                    else
                                    {

                                        string _commandString = "INSERT INTO `people`(`lastname`,`name`,`surname`,`sex`,`date_of_birth`,`village`,`street`,`numb_of_house`,`passport`,`id_kod`,`phone_numb`,`status`,`registr`,`m_date`)" +
                                      "VALUES(@lastname,@name,@surname,@sex,@date_of_birth,@village,@street,@numb_of_house,@passport,@id_kod,@phone_numb,@status,@registr,@m_date)";
                                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                                       
                                        _command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[1].Value.ToString().Replace("'", "`").Replace('"', '`'); 
                                        _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[2].Value.ToString().Replace("'", "`").Replace('"', '`');
                                        _command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[3].Value.ToString().Replace("'", "`").Replace('"', '`');
                                        _command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[4].Value;
                                        _command.Parameters.Add("@date_of_birth", MySqlDbType.VarChar).Value = date_of_birth;
                                        _command.Parameters.Add("@village", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[6].Value;
                                        _command.Parameters.Add("@street", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[7].Value;
                                        _command.Parameters.Add("@numb_of_house", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[8].Value;
                                        _command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[9].Value;
                                        _command.Parameters.Add("@id_kod", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[10].Value;
                                        _command.Parameters.Add("@phone_numb", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[11].Value;
                                        _command.Parameters.Add("@status", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[12].Value;
                                        _command.Parameters.Add("@registr", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[13].Value;
                                        _command.Parameters.Add("@m_date", MySqlDbType.VarChar).Value = m_date;
                                }

                                        if (_command.ExecuteNonQuery() == 1)
                                            add = true;
                                    }
                                    }
                            catch
                            {
                                MessageBox.Show("Помилка введення дати ! Дату потрібно вводити у форматі - дд.мм.рррр ");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не всі поля заповнені !");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Помилка роботи з базою даних !");
                }

                finally
                {
                    _manager.closeConnection();
                }
                if (add && (i == rowCount - 1))
                {
                    MessageBox.Show("Дані добавлено !");

                }
                else if (!add && (i == rowCount - 1) && !a)

                    MessageBox.Show("Помилка добавлення даних !");

        }

       

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            comboBoxStreets.Items.Clear();

            string village = comboBoxVillage.Text;
            comboBoxStreets.Text = "Виберіть вулицю";

            bool mess = false;
            data.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT street FROM villagestreet WHERE `village` = '" + village + "'";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet(_reader["street"]);
                data.Add(row);

            }

            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid_1(data[i]);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            }
            _manager.closeConnection();
        }
    }
}
