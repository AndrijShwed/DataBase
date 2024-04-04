using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ХудобаТаПтицяДодати : Form
    {
        private List<RowOfDataAnymals> _data = new List<RowOfDataAnymals>();
        private List<VillageStreet> data = new List<VillageStreet>();
        //private User user;

        int rowNumber = 0;

        public ХудобаТаПтицяДодати()
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

            comboBoxVillage.Text = "Виберіть населений пункт";
           
            HeaderOfTheTable();
        }

        private void AddDataGrid(VillageStreet row)
        {
            comboBoxVillage.Items.Add(row.village);
        }

        private void HeaderOfTheTable()
        {
            this.dataGridViewДодати.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewДодати.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewДодати.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewДодати.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewДодати.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            this.dataGridViewДодати.EnableHeadersVisualStyles = false;


           

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Прізвище";
            column2.Width = 130;
            column2.Name = "lastname";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Ім'я";
            column3.Width = 130;
            column3.Name = "name";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Побатькові";
            column4.Width = 130;
            column4.Name = "surname";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Населений пункт";
            column5.Width = 120;
            column5.Name = "village";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "ВРХ";
            column6.Width = 98;
            column6.Name = "anymals";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Корови";
            column7.Width = 98;
            column7.Name = "covs";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Свині";
            column8.Width = 98;
            column8.Name = "pigs";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Вівці";
            column9.Width = 98;
            column9.Name = "sheeps";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Кози";
            column10.Width = 98;
            column10.Name = "goats";
            column10.Frozen = true;
            column10.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Коні";
            column11.Width = 98;
            column11.Name = "horses";
            column11.Frozen = true;
            column11.CellTemplate = new DataGridViewTextBoxCell();

            var column12 = new DataGridViewColumn();
            column12.HeaderText = "Птиця";
            column12.Width = 98;
            column12.Name = "birds";
            column12.Frozen = true;
            column12.CellTemplate = new DataGridViewTextBoxCell();

            var column13 = new DataGridViewColumn();
            column13.HeaderText = "Кролі";
            column13.Width = 98;
            column13.Name = "rabbits";
            column13.Frozen = true;
            column13.CellTemplate = new DataGridViewTextBoxCell();

            var column14 = new DataGridViewColumn();
            column14.HeaderText = "Бджоли";
            column14.Width = 98;
            column14.Name = "beeses";
            column14.Frozen = true;
            column14.CellTemplate = new DataGridViewTextBoxCell();

           
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
          
            dataGridViewДодати.AllowUserToAddRows = false;
            dataGridViewДодати.ReadOnly = true;
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Hide();
            form.Show();
        }

        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ХудобаТаПтиця form = new ХудобаТаПтиця();
            this.Hide();
            form.Show();
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
              Application.Exit();
        }

        private void buttonДодатиРядок_Click(object sender, EventArgs e)
        {
            dataGridViewДодати.DataSource = null;
            dataGridViewДодати.ReadOnly = false;

            this.dataGridViewДодати.Rows.Add();

            //dataGridViewДодати.Rows[rowNumber].Cells[0].ReadOnly = true;
          
            dataGridViewДодати.Rows[rowNumber].Cells[3].Value = comboBoxVillage.Text.ToString();
           

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

                    string lastname = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[0].Value).Replace("'", "`").Replace('"', '`');
                    string name = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[1].Value).Replace("'", "`").Replace('"', '`');
                    string surname = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[2].Value).Replace("'", "`").Replace('"', '`');
                    string village = Convert.ToString(this.dataGridViewДодати.Rows[current].Cells[3].Value);
                   

                    if (lastname != "" && name != "" && surname != "" && village != "")
                    {
                       
                        string equal = "SELECT * FROM anymals WHERE lastname = '" + lastname + "' AND" +
                           " name = '" + name + "' AND surname = '" + surname  + "' AND village = '" + village + "'";

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
                            int anymals = 0;
                            int covs = 0;
                            int pigs = 0;
                            int sheeps = 0;
                            int goats = 0;
                            int horses = 0;
                            int birds = 0;
                            int rabbits = 0;
                            int beeses = 0;
                          

                            if (dataGridViewДодати.Rows[current].Cells[4].ToString() != "")
                            {
                                anymals = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[4].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[5].ToString() != "")
                            {
                                covs = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[5].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[6].ToString() != "")
                            {
                                pigs = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[6].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[7].ToString() != "")
                            {
                                sheeps = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[7].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[8].ToString() != "")
                            {
                                goats = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[8].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[9].ToString() != "")
                            {
                                horses = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[9].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[10].ToString() != "")
                            {
                                birds = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[10].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[11].ToString() != "")
                            {
                                rabbits = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[11].Value);
                            }
                            if (dataGridViewДодати.Rows[current].Cells[12].ToString() != "")
                            {
                                beeses = Convert.ToInt32(dataGridViewДодати.Rows[current].Cells[12].Value);
                            }
                           
                            string _commandString = "INSERT INTO `anymals`(`lastname`,`name`,`surname`,`village`,`anymals`," +
                                                                          "`covs`,`pigs`,`sheeps`,`goats`,`horses`,`birds`,`rabbits`,`beeses`)" +
                                                     "VALUES(@lastname,@name,@surname,@village,'"+anymals+"','"+covs+"','"+pigs+"','"+sheeps+"'," +
                                                                   "'"+goats+"','"+horses+"','"+birds+"','"+rabbits+"','"+beeses+"')";

                              MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                            _command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[0].Value.ToString().Replace("'", "`").Replace('"', '`');
                            _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[1].Value.ToString().Replace("'", "`").Replace('"', '`');
                            _command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[2].Value.ToString().Replace("'", "`").Replace('"', '`');
                            _command.Parameters.Add("@village", MySqlDbType.VarChar).Value = this.dataGridViewДодати.Rows[current].Cells[3].Value;


                            if (_command.ExecuteNonQuery() == 1)
                                    add = true;

                                dataGridViewДодати.Rows.RemoveAt(current);
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

       
    }
}
