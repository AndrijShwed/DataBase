using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ДомогосподарстваДодати : Form
    {
        private List<RowOfDataL> _dataL = new List<RowOfDataL>();
        private List<VillageStreet> data = new List<VillageStreet>();
       // private User user;
       
        int rowNumber = 0;

        public ДомогосподарстваДодати()
        {
            InitializeComponent();
            comboBoxVillage.Text = "Виберіть населений пункт";
            bool mess = false;
            data.Clear();
            comboBoxVillage.Items.Clear();

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
            this.dataGridViewДомогосподарства.DefaultCellStyle.Font = new Font("TimeNewRoman", 12);
            this.dataGridViewДомогосподарства.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewДомогосподарства.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridViewДомогосподарства.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Italic);
            this.dataGridViewДомогосподарства.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewДомогосподарства.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;

            this.dataGridViewДомогосподарства.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 55;
            column1.Name = "idhouses";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Населений пункт";
            column2.Width = 150;
            column2.Name = "village";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Вулиця";
            column3.Width = 180;
            column3.Name = "street";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Номер будинку";
            column4.Width = 120;
            column4.Name = "numb_of_house";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Прізвище";
            column5.Width = 180;
            column5.Name = "lastname";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Ім_я";
            column6.Width = 180;
            column6.Name = "name";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Побатькові";
            column7.Width = 180;
            column7.Name = "surname";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Загальна площа";
            column8.Width = 120;
            column8.Name = "totalArea";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Житлова площа";
            column9.Width = 120;
            column9.Name = "livingArea";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Кількість кімнат";
            column10.Width = 120;
            column10.Name = "total_of_rooms";
            column10.Frozen = true;
            column10.CellTemplate = new DataGridViewTextBoxCell();


            dataGridViewДомогосподарства.Columns.Add(column1);
            dataGridViewДомогосподарства.Columns.Add(column2);
            dataGridViewДомогосподарства.Columns.Add(column3);
            dataGridViewДомогосподарства.Columns.Add(column4);
            dataGridViewДомогосподарства.Columns.Add(column5);
            dataGridViewДомогосподарства.Columns.Add(column6);
            dataGridViewДомогосподарства.Columns.Add(column7);
            dataGridViewДомогосподарства.Columns.Add(column8);
            dataGridViewДомогосподарства.Columns.Add(column9);
            dataGridViewДомогосподарства.Columns.Add(column10);



            dataGridViewДомогосподарства.AllowUserToAddRows = false;
            dataGridViewДомогосподарства.ReadOnly = true;
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Hide();
            form.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxStreets.Items.Clear();

            string village = comboBoxVillage.Text;
            comboBoxStreets.Text = "Виберіть вулицю";
            data.Clear();
            bool mess = false;
           
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

        private void Знайти_власника_Click(object sender, EventArgs e)
        {
            comboBoxLastname.Items.Clear();
            comboBoxName.Items.Clear();
            comboBoxSurname.Items.Clear();
            _dataL.Clear();
            bool a = false;


            string village = Convert.ToString(comboBoxVillage.Text);
            string street = Convert.ToString(comboBoxStreets.Text);
            string numb_of_house = Convert.ToString(comboBoxNumb.Text);
           
            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            if (village == "Виберіть населений пункт" || street == "Виберіть вулицю" ||
                street == "" || numb_of_house == "")
            {

                MessageBox.Show("Не повністю заповнена адреса !");
            }
            else
            {
               try
               {
                    string equal = "SELECT * FROM houses WHERE village = '" + village + "' AND" +
                     " street = '" + street + "' AND numb_of_house = '" + numb_of_house + "'";

                   _manager.openConnection();
                   MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                   _reader = search.ExecuteReader();
                   a = _reader.HasRows;
                   _reader.Close();
                   _manager.closeConnection();
  
                  if (a)
                  {
                    MessageBox.Show("Такий запис вже існує !");
                    
                  }
                  else
                  {

                     SQLCommand c = new SQLCommand();

                     c.com = "SELECT lastname,name,surname FROM people WHERE  village = '" +
                     village + "' AND street = '" + street + "' AND numb_of_house = '" +
                     numb_of_house + "'";


                    _manager.openConnection();

                    MySqlCommand _command = new MySqlCommand(c.com, _manager.getConnection());

                    _reader = _command.ExecuteReader();



                    while (_reader.Read())
                    {
                        RowOfDataL row = new RowOfDataL(_reader["lastname"], _reader["name"], _reader["surname"]);
                        _dataL.Add(row);
                    }
                        _reader.Close();

                    for (int i = 0; i < _dataL.Count; i++)
                    {
                        comboBoxLastname.Items.Add(_dataL[i].lastname);
                        comboBoxName.Items.Add(_dataL[i].name);
                        comboBoxSurname.Items.Add(_dataL[i].surname);
                        a = true;

                    }
                    _manager.closeConnection();

                    comboBoxLastname.Text = "Виберіть прізвище";
                    string Lastname = comboBoxLastname.Text;
                    comboBoxName.Text = "Виберіть ім_я";
                    string Name = comboBoxName.Text;
                    comboBoxSurname.Text = "Виберіть побатькові";
                    string Surname = comboBoxSurname.Text;

                    if (a == false)
                    {
                        MessageBox.Show("Запис не знайдено !");
                    }
                  }

               }
               catch
               {
                  MessageBox.Show("Помилка !");
               }

            }
             
           
        }

        private void Додати_пустий_рядок_Click(object sender, EventArgs e)
        {
            if (comboBoxLastname.Text == "Виберіть прізвище" || comboBoxLastname.Text == "" ||
               comboBoxName.Text == "Виберіть ім_я" || comboBoxName.Text == "" ||
               comboBoxSurname.Text == "Виберіть побатькові" || comboBoxSurname.Text == "")
            {
                MessageBox.Show("Не вибрано або не вказано прізвище ім_я побатькові !");
            }
            else
            {

                dataGridViewДомогосподарства.DataSource = null;
                dataGridViewДомогосподарства.ReadOnly = false;

                this.dataGridViewДомогосподарства.Rows.Add();

                dataGridViewДомогосподарства.Rows[rowNumber].Cells[0].ReadOnly = true;
                dataGridViewДомогосподарства.Rows[rowNumber].Cells[1].Value = comboBoxVillage.Text.ToString();
                dataGridViewДомогосподарства.Rows[rowNumber].Cells[2].Value = comboBoxStreets.Text.ToString();
                dataGridViewДомогосподарства.Rows[rowNumber].Cells[3].Value = comboBoxNumb.Text.ToString();
                dataGridViewДомогосподарства.Rows[rowNumber].Cells[4].Value = comboBoxLastname.Text.ToString();
                dataGridViewДомогосподарства.Rows[rowNumber].Cells[5].Value = comboBoxName.Text.ToString();
                dataGridViewДомогосподарства.Rows[rowNumber].Cells[6].Value = comboBoxSurname.Text.ToString();

                rowNumber++;
            }
        }

        private void ЗберегтиВТаблицю_Click(object sender, EventArgs e)
        {
            //user = new User();

            //if (user.userName == "A")
            //{

                if (this.dataGridViewДомогосподарства.Rows[0].Cells[7].Value == null ||
                    this.dataGridViewДомогосподарства.Rows[0].Cells[8].Value == null ||
                    this.dataGridViewДомогосподарства.Rows[0].Cells[7].Value == null)
                {
                    MessageBox.Show("Заповніть дані про площу та кількість кімнат !");
                }
                else
                {
                    rowNumber = 0;
                    bool a = false;
                    bool add = false;
                    int current = 0;

                    ConnectionClass _manager = new ConnectionClass();
                    MySqlDataReader _reader;

                    int rowCount = dataGridViewДомогосподарства.RowCount;

                    for (int i = 0; i < rowCount; i++)
                    {
                        try
                        {
                            _manager.openConnection();


                            string village = Convert.ToString(this.dataGridViewДомогосподарства.Rows[current].Cells[1].Value);
                            string street = Convert.ToString(this.dataGridViewДомогосподарства.Rows[current].Cells[2].Value);
                            string numb = Convert.ToString(this.dataGridViewДомогосподарства.Rows[current].Cells[3].Value);


                            if (village != "" && street != "" && numb != "")
                            {

                                string equal = "SELECT * FROM houses WHERE village = '" + village + "' AND" +
                                   " street = '" + street + "' AND numb_of_house = '" + numb + "'";

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
                                        string _commandString = "INSERT INTO `houses`(`village`,`street`,`numb_of_house`,`lastname`,`name`,`surname`,`totalArea`,`livingArea`,`total_of_rooms`)" +
                                      "VALUES(@village,@street,@numb_of_house,@lastname,@name,@surname,@totalArea,@livingArea,@total_of_rooms)";
                                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());


                                        _command.Parameters.Add("@village", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[1].Value;
                                        _command.Parameters.Add("@street", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[2].Value;
                                        _command.Parameters.Add("@numb_of_house", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[3].Value;
                                        _command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[4].Value.ToString().Replace("'", "`").Replace('"', '`');
                                        _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[5].Value.ToString().Replace("'", "`").Replace('"', '`');
                                        _command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[6].Value.ToString().Replace("'", "`").Replace('"', '`');
                                        _command.Parameters.Add("@totalArea", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[7].Value;
                                        _command.Parameters.Add("@livingArea", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[8].Value;
                                        _command.Parameters.Add("@total_of_rooms", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[9].Value;

                                        if (_command.ExecuteNonQuery() == 1)
                                            add = true;

                                        dataGridViewДомогосподарства.Rows.RemoveAt(current);

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Помилка ! ");
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

                        if (a && dataGridViewДомогосподарства.Rows.Count > 0 && (i == rowCount - 1))

                            MessageBox.Show("Такий запис вже існує !");

                    }
                }
            //}
            //else
            //{
            //    MessageBox.Show("У вас немає доступу до бази даних");
            //}
        }

        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }
    }
}
