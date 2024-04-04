using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Додати : Form
    {
        private List<RowOfData> _data = new List<RowOfData>();
        private List<VillageStreet> data = new List<VillageStreet>();
       
       // private User user;
        int rowNumber = 0;

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
          
            HeaderOfTheTable();

        }

        private void AddDataGrid(VillageStreet row)
        {
            comboBoxVillage.Items.Add(row.village);
        }


        private void AddDataGrid_1(VillageStreet row)
        {
            comboBoxStreets.Items.Add(row.village);
        }

        private void HeaderOfTheTable()
        {
            this.dataGridViewДодати.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewДодати.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewДодати.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewДодати.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewДодати.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;

            this.dataGridViewДодати.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 55;
            column1.Name = "people_id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Прізвище";
            column2.Width = 110;
            column2.Name = "lastname";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Ім'я";
            column3.Width = 100;
            column3.Name = "name";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Побатькові";
            column4.Width = 120;
            column4.Name = "surname";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Стать";
            column5.Width = 60;
            column5.Name = "sex";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Дата народження";
            column6.Width = 110;
            column6.Name = "date_of_birth";
            column6.Frozen = true;
            column6.DefaultCellStyle.Format = "d";
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Село";
            column7.Width = 100;
            column7.Name = "village";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Вулиця";
            column8.Width = 110;
            column8.Name = "street";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Номер будинку";
            column9.Width = 90;
            column9.Name = "numb_of_house";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Паспорт";
            column10.Width = 100;
            column10.Name = "passport";
            column10.Frozen = true;
            column10.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Ідент. код";
            column11.Width = 90;
            column11.Name = "id_kod";
            column11.Frozen = true;
            column11.CellTemplate = new DataGridViewTextBoxCell();

            var column12 = new DataGridViewColumn();
            column12.HeaderText = "Номер телефону";
            column12.Width = 110;
            column12.Name = "phone_numb";
            column12.Frozen = true;
            column12.CellTemplate = new DataGridViewTextBoxCell();

            var column13 = new DataGridViewColumn();
            column13.HeaderText = "Статус";
            column13.Width = 90;
            column13.Name = "status";
            column13.Frozen = true;
            column13.CellTemplate = new DataGridViewTextBoxCell();

            var column14 = new DataGridViewColumn();
            column14.HeaderText = "Реєстрація";
            column14.Width = 110;
            column14.Name = "registr";
            column14.Frozen = true;
            column14.CellTemplate = new DataGridViewTextBoxCell();

            var column15 = new DataGridViewColumn();
            column15.HeaderText = "Дата зміни статусу";
            column15.Width = 110;
            column15.Name = "m_date";
            column15.Frozen = true;
            column15.DefaultCellStyle.Format = "d";
            column15.CellTemplate = new DataGridViewTextBoxCell();

            dataGridViewДодати.Columns.Add(column1);
            dataGridViewДодати.Columns.Add(column2);
            dataGridViewДодати.Columns.Add(column3);
            dataGridViewДодати.Columns.Add(column4);
            dataGridViewДодати.Columns.Add(column5);
            dataGridViewДодати.Columns.Add(column6);
            dataGridViewДодати.Columns.Add(column7);
            dataGridViewДодати.Columns.Add(column8);
            dataGridViewДодати.Columns.Add(column9);
            dataGridViewДодати.Columns.Add(column10);
            dataGridViewДодати.Columns.Add(column11);
            dataGridViewДодати.Columns.Add(column12);
            dataGridViewДодати.Columns.Add(column13);
            dataGridViewДодати.Columns.Add(column14);
            dataGridViewДодати.Columns.Add(column15);


            dataGridViewДодати.AllowUserToAddRows = false;
            dataGridViewДодати.ReadOnly = true;
        }


        private void Редагувати_Shown(object sender, EventArgs e)
        {
            HeaderOfTheTable();
            dataGridViewДодати.Columns[0].ReadOnly = true;
            //user = new User();

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

        private void buttonДодатиРядок_Click_1(object sender, EventArgs e)
        {
            dataGridViewДодати.DataSource = null;
            dataGridViewДодати.ReadOnly = false;

            this.dataGridViewДодати.Rows.Add();

            dataGridViewДодати.Rows[rowNumber].Cells[0].ReadOnly = true;
            dataGridViewДодати.Rows[rowNumber].Cells[5].Value = "дд.мм.рррр";
            dataGridViewДодати.Rows[rowNumber].Cells[6].Value = comboBoxVillage.Text.ToString();
            dataGridViewДодати.Rows[rowNumber].Cells[7].Value = comboBoxStreets.Text.ToString();
            dataGridViewДодати.Rows[rowNumber].Cells[14].Value = "дд.мм.рррр";

            rowNumber++;

        }

        private void buttonЗберегти_В_Таблицю_Click(object sender, EventArgs e)
        {
            rowNumber = 0;
            bool a = false;
            bool add = false;
            int current = 0;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            int rowCount = dataGridViewДодати.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
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
                                if (m_date != "дд.мм.рррр")
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

                                        if (_command.ExecuteNonQuery() == 1)
                                            add = true;

                                        dataGridViewДодати.Rows.RemoveAt(current);

                                    }
                                }
                                else
                                {

                                    date_of_birth = s3 + '/' + s2 + '/' + s1;
                                    DateTime date_of_birth1 = Convert.ToDateTime(date_of_birth);

                                    if (date_of_birth1 > DateTime.Now)
                                    {
                                        MessageBox.Show("Дата народження не може бути новішою за поточну дату !");
                                    }
                                    else
                                    {

                                        string _commandString = "INSERT INTO `people`(`lastname`,`name`,`surname`,`sex`,`date_of_birth`,`village`,`street`,`numb_of_house`,`passport`,`id_kod`,`phone_numb`,`status`,`registr`)" +
                                      "VALUES(@lastname,@name,@surname,@sex,@date_of_birth,@village,@street,@numb_of_house,@passport,@id_kod,@phone_numb,@status,@registr)";
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


                                        if (_command.ExecuteNonQuery() == 1)
                                            add = true;

                                        dataGridViewДодати.Rows.RemoveAt(current);
                                    }
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

                if (a && dataGridViewДодати.Rows.Count > 0 && (i == rowCount - 1))

                    MessageBox.Show("Такий запис вже існує !");

            }

        }

        private void переглядДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ВивідДаних form = new ВивідДаних();
            this.Hide();
            form.Show();
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
            _reader.Close();

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
