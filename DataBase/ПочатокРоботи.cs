using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DataBase
{
    public partial class ПочатокРоботи : Form
    {
        private List<VillageStreet> data = new List<VillageStreet> ();
       // User user = new User ();

        public ПочатокРоботи()
        {
            InitializeComponent();
            HeaderOfTable();
        }

        private void HeaderOfTable()
        {
            this.dataGridViewПочатокРоботи.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewПочатокРоботи.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            this.dataGridViewПочатокРоботи.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewПочатокРоботи.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewПочатокРоботи.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkOrange;
            this.dataGridViewПочатокРоботи.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 50;
            column1.Name = "Номер";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Населений пункт";
            column2.Width = 235;
            column2.Name = "village";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Вулиця";
            column3.Width = 235;
            column3.Name = "street";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Видалити";
            column4.Width = 95;
            column4.Name = "delete";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "id";
            column5.Width = 40;
            column5.Name = "id";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();
            column5.Visible = false;

            dataGridViewПочатокРоботи.Columns.Add(column1);
            dataGridViewПочатокРоботи.Columns.Add(column2);
            dataGridViewПочатокРоботи.Columns.Add(column3);
            dataGridViewПочатокРоботи.Columns.Add(column4);
            dataGridViewПочатокРоботи.Columns.Add(column5);
            
            dataGridViewПочатокРоботи.AllowUserToAddRows = false;
            dataGridViewПочатокРоботи.ReadOnly = true;

            VillageStreetTableInit();

        }

        private void AddDataGrid(VillageStreet row)
        {
            dataGridViewПочатокРоботи.Rows.Add(row.id, row.village, row.street, row.id);
        }

        private void VillageStreetTableInit()
        {
            dataGridViewПочатокРоботи.DataSource = null;
            dataGridViewПочатокРоботи.Rows.Clear();
            bool mess = false;
            data.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT * FROM villagestreet";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet(_reader["id"],_reader["villageId"], _reader["street"]);
                data.Add(row);

            }
            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid(data[i]);
                dataGridViewПочатокРоботи.Rows[i].Cells[0].Value = i + 1;
                dataGridViewПочатокРоботи.Rows[i].Cells[4].Value = data[i].id;
                dataGridViewПочатокРоботи.Rows[i].Cells[3].Value = "Видалити";
                dataGridViewПочатокРоботи.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.DarkRed;
                dataGridViewПочатокРоботи.Rows[i].Cells[3].Style.ForeColor = System.Drawing.Color.White;
                dataGridViewПочатокРоботи.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця пуста, заповніть дані !");
            }
            _manager.closeConnection();
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

        private void повернутисьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Hide();
            form.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ДодатиВТаблицю_Click(object sender, EventArgs e)
        {
            string village = Convert.ToString(НазваНасПункту.Text);
            string street = Convert.ToString(НазваВулиці.Text);

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();
            bool a = false;
            bool add = false;

            if(village != "")
            {
                string equal = "SELECT * FROM villages WHERE name = '" + village + "'";

                MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                _reader = search.ExecuteReader();
                a = _reader.HasRows;
                _reader.Close();

                if(!a)
                {
                    try
                    {
                        string _commandString = "INSERT INTO `villages`(`name`) VALUES ('" + village + "')";
                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());
                        if (_command.ExecuteNonQuery() == 1)
                            add = true;
                    }
                    catch
                    {
                        MessageBox.Show("Помилка роботи з базою даних !!!");
                    }
                }
                else
                {
                   
                }
                if(add == true)
                {
                    MessageBox.Show("Дані добавлено !!!");
                }
                else
                {
                    MessageBox.Show("Дані не добавлено !!!");
                }
            }
            else 
            {
                MessageBox.Show("Не всі поля заповнено !");
            }

            if (street != "")
            {
                string equal = "SELECT * FROM streets WHERE name = '" + street + "'";

                MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                _reader = search.ExecuteReader();
                a = _reader.HasRows;
                _reader.Close();

                if (!a)
                {
                    try
                    {
                        string _commandString = "INSERT INTO `streets`(`name`) VALUES ('" + street + "')";
                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());
                        if (_command.ExecuteNonQuery() == 1)
                            add = true;
                    }
                    catch
                    {
                        MessageBox.Show("Помилка роботи з базою даних !!!");
                    }
                }
                if (add == true)
                {
                    MessageBox.Show("Дані добавлено !!!");
                }
                else
                {
                    MessageBox.Show("Дані не добавлено !!!");
                }
            }
            else
            {
                MessageBox.Show("Не всі поля заповнено !");
            }

            VillageStreetTableInit();
        }

        private void dataGridViewПочатокРоботи_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // user = new User();

           // if (user.userName == "A")
            //{

                if (e.ColumnIndex == 3)
                {
                    DataGridViewRow row = dataGridViewПочатокРоботи.Rows[e.RowIndex];


                    if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["Номер"].Value), "Погоджуюсь",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ConnectionClass _manager = new ConnectionClass();
                        _manager.openConnection();

                        string com = "DELETE FROM `villagestreet` WHERE(`id` = '" + row.Cells[4].Value + "')";

                    MySqlCommand dell = new MySqlCommand(com, _manager.getConnection());


                        if (dell.ExecuteNonQuery() == 1)
                        {
                            dataGridViewПочатокРоботи.Rows.RemoveAt(row.Index);
                            MessageBox.Show("Дані успішно видалено ");
                            _manager.closeConnection();
                        }
                        else
                        {
                            MessageBox.Show("Помилка роботи з базою даних !!!");
                        }

                    }
                }
            //}
            //else
            //{
            //    MessageBox.Show("У вас немає доступу до видалення даних з таблиці !");
            //}

        }

        public void AddStreetToVillage(string village, string street)
        {

            ConnectionClass _manager = new ConnectionClass();
            _manager.openConnection();
            
            try
            {
                int villageId = 0;
                int streetId;

                // 1. Населений пункт
                string com = "SELECT Id FROM villages WHERE name = '" + village + "'";
                MySqlCommand cmd = new MySqlCommand(com, _manager.getConnection());
                
                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    com = "INSERT INTO villages (name) VALUES ('" + village + "')";

                    MySqlCommand insert = new MySqlCommand(com, _manager.getConnection());
                        
                    _manager.closeConnection();
                }
                else
                {
                    villageId = Convert.ToInt32(result);
                }



                // 2. Вулиця
                com = "SELECT Id FROM streets WHERE name = '" + street + "'";
                cmd = new MySqlCommand(com, _manager.getConnection());

                result = cmd.ExecuteScalar();

                if (result == null)
                {
                    com = "INSERT INTO streets (name) VALUES ('" + street + "')";

                    MySqlCommand insert = new MySqlCommand(com, _manager.getConnection());

                    _manager.closeConnection();
                }
                else
                {
                    streetId = Convert.ToInt32(result);
                }

                // 3. Перевірка звʼязку
                com = "SELECT COUNT(*)FROM villagestreet WHERE villageId = '" + villageId + "' AND StreetId = @streetId"
                SqlCommand cmd = new SqlCommand(@"
                    , con, tran))
                {
                    cmd.Parameters.AddWithValue("@settlementId", settlementId);
                    cmd.Parameters.AddWithValue("@streetId", streetId);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                    {
                        using (SqlCommand insert = new SqlCommand(@"
                    INSERT INTO SettlementStreets
                        (SettlementId, StreetId, IsActive, RenameDate)
                    VALUES
                        (@settlementId, @streetId, 1, NULL)", con, tran))
                        {
                            insert.Parameters.AddWithValue("@settlementId", settlementId);
                            insert.Parameters.AddWithValue("@streetId", streetId);
                            insert.ExecuteNonQuery();
                        }
                    }
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            
            
        }


    }
}
