using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Домогосподарства_Пошук : Form
    {
        private List<RowOfDataH> _dataH = new List<RowOfDataH>();
        private List<Village> dataVillage = new List<Village>();
        private List<Street> dataStreet = new List<Street>();
        //private User user;
       

        public Домогосподарства_Пошук()
        { 
            InitializeComponent();
            comboBoxVillage.Text = "Виберіть населений пункт";
            bool mess = false;
            dataVillage.Clear();
            comboBoxVillage.Items.Clear();
            textBoxCount.Text = "0";

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

            HeaderOfTheTable();
        }

        private void AddDataGrid(Village row)
        {
            comboBoxVillage.Items.Add(row.Name);
        }
        private void AddDataGrid_1(Street row)
        {
            comboBoxStreets.Items.Add(row.Name);
        }
        private void HeaderOfTheTable()
        {
            this.dataGridViewДомогосподарства_Пошук.DefaultCellStyle.Font = new System.Drawing.Font("TimeNewRoman", 12);
            this.dataGridViewДомогосподарства_Пошук.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            this.dataGridViewДомогосподарства_Пошук.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewДомогосподарства_Пошук.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, FontStyle.Italic);
            this.dataGridViewДомогосподарства_Пошук.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewДомогосподарства_Пошук.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;

            this.dataGridViewДомогосподарства_Пошук.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Id";
            column1.Width = 55;
            column1.Name = "idhouses";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();
            

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Населений пункт";
            column2.Width = 180;
            column2.Name = "village";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Вулиця";
            column3.Width = 190;
            column3.Name = "street";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Номер будинку";
            column4.Width = 80;
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
            column6.Width = 190;
            column6.Name = "name";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Побатькові";
            column7.Width = 190;
            column7.Name = "surname";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Загальна площа, м.кв.";
            column8.Width = 100;
            column8.Name = "totalArea";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Житлова площа, м.кв";
            column9.Width = 100;
            column9.Name = "livingArea";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Кількість кімнат";
            column10.Width = 100;
            column10.Name = "total_of_rooms";
            column10.Frozen = true;
            column10.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Видалити";
            column11.Width = 90;
            column11.Name = "delete";
            column11.Frozen = true;
            column11.CellTemplate = new DataGridViewTextBoxCell();

            dataGridViewДомогосподарства_Пошук.Columns.Add(column1);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column2);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column3);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column4);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column5);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column6);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column7);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column8);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column9);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column10);
            dataGridViewДомогосподарства_Пошук.Columns.Add(column11);
          



            dataGridViewДомогосподарства_Пошук.AllowUserToAddRows = false;
            dataGridViewДомогосподарства_Пошук.ReadOnly = true;
        }
        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
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

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxStreets.Items.Clear();

            string village = comboBoxVillage.Text;
            comboBoxStreets.Text = "Виберіть вулицю";
            dataStreet.Clear();
            bool mess = false;

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
        private void AddDataGrid(RowOfDataH row)
        {
            dataGridViewДомогосподарства_Пошук.Rows.Add(row.idhouses, row.village, row.street, row.numb_of_house, row.lastname, row.name,
                row.surname, row.totalArea, row.livingArea, row.total_of_rooms);
        }

        private void Знайти_Click(object sender, EventArgs e)
        {
            bool mess = false;
            int count = 0;
            bool first = true;

            dataGridViewДомогосподарства_Пошук.DataSource = null;
            dataGridViewДомогосподарства_Пошук.Rows.Clear();

            _dataH.Clear();

            SQLCommand c = new SQLCommand();

            if (comboBoxNumb.Text == "" && textBoxLastName.Text == "" && textBoxName.Text == "" && textBoxSurName.Text == ""
                && comboBoxVillage.Text == "Виберіть населений пункт" && comboBoxStreets.Text == "")
            {
                MessageBox.Show("Жодне поле пошуку не заповнено !");
                return;
            }

            string village = Convert.ToString(comboBoxVillage.Text);
            string street = Convert.ToString(comboBoxStreets.Text);
            string numb_of_house = Convert.ToString(comboBoxNumb.Text);
            string lastname = Convert.ToString(textBoxLastName.Text);
            string name = Convert.ToString(textBoxName.Text);
            string surname = Convert.ToString(textBoxSurName.Text);

            c.com = "SELECT * FROM houses ";

            if (comboBoxVillage.Text != "Виберіть населений пункт")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE village = '" + village + "'";
                }
                else
                {
                    c.com = c.com + " AND village = '" + village + "'";
                }
            }
            if (comboBoxStreets.Text != "" && comboBoxStreets.Text != "Виберіть вулицю")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE street = '" + street + "'";
                }
                else
                {
                    c.com = c.com + " AND street = '" + street + "'";
                }
            }
            if (comboBoxNumb.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE numb_of_house = '" + numb_of_house + "'";
                }
                else
                {
                    c.com = c.com + " AND numb_of_house = '" + numb_of_house + "'";
                }
            }

            if (textBoxName.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(name) LIKE '" + name + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(name) LIKE '" + name + "%'";
                }
            }

            if (textBoxLastName.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(lastname) LIKE '" + lastname + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(lastname) LIKE '" + lastname + "%'";
                }
            }

            if (textBoxSurName.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(surname) LIKE '" + surname + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(surname) LIKE '" + surname + "%'";
                }
            }
            
           

            ConnectionClass _manager = new ConnectionClass();
                   MySqlDataReader _reader;
          
            try
            {
                _manager.openConnection();

                MySqlCommand _command = new MySqlCommand(c.com, _manager.getConnection());

                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    RowOfDataH row = new RowOfDataH(_reader["idhouses"], _reader["village"], _reader["street"], _reader["numb_of_house"], 
                        _reader["lastname"], _reader["name"], _reader["surname"],
                        _reader["totalArea"], _reader["livingArea"], _reader["total_of_rooms"]);
                    _dataH.Add(row);
                }
                _reader.Close();
                count = _dataH.Count;
                textBoxCount.Text = count.ToString();

                for (int i = 0; i < _dataH.Count; i++)
                {
                    AddDataGrid(_dataH[i]);
                    dataGridViewДомогосподарства_Пошук.Rows[i].Cells[10].Value = "Видалити";
                    dataGridViewДомогосподарства_Пошук.Rows[i].Cells[10].Style.BackColor = System.Drawing.Color.DarkRed;
                    dataGridViewДомогосподарства_Пошук.Rows[i].Cells[10].Style.ForeColor = System.Drawing.Color.White;
                   
                   
                    mess = true;
                   
                }

                if (mess == false)
                {
                    MessageBox.Show("Запис не знайдено !");
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

        }

        private void домогосподарстваToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }

        private void вихідToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Очистити_Click(object sender, EventArgs e)
        {
            dataGridViewДомогосподарства_Пошук.Rows.Clear();
            comboBoxVillage.Text = "Виберіть населений пункт";
            comboBoxStreets.Text = "";
            comboBoxNumb.Text = "";
        }

       

        private void dataGridViewДомогосподарства_Пошук_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            { 
                DataGridViewRow row = dataGridViewДомогосподарства_Пошук.Rows[e.RowIndex];
               

                if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["idhouses"].Value), "Погоджуюсь", 
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();

                    string com = "DELETE FROM houses WHERE idhouses = '" + row.Cells["idhouses"].Value +"'";

                    MySqlCommand dell = new MySqlCommand(com, _manager.getConnection());
                   

                    if (dell.ExecuteNonQuery() == 1)
                    {
                        dataGridViewДомогосподарства_Пошук.Rows.RemoveAt(row.Index);
                        MessageBox.Show("Дані успішно видалено ");
                        _manager.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Помилка роботи з базою даних !!!");
                    }

                }
            }
           
        }

        private void Зберегти_зміни_Click(object sender, EventArgs e)
        {

            string idhouses = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[0].Value);
            string village = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[1].Value);
            string street = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[2].Value);
            string numb_of_house = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[3].Value);
            string lastname = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[4].Value).Replace("'", "`").Replace('"', '`');
            string name = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[5].Value).Replace("'", "`").Replace('"', '`');
            string surname = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[6].Value).Replace("'", "`").Replace('"', '`');
            string totalArea = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[7].Value);
            totalArea = totalArea.Replace(',', '.');
            string livingArea = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[8].Value);
            livingArea = livingArea.Replace(",", ".");
            string total_of_rooms = Convert.ToString(this.dataGridViewДомогосподарства_Пошук.Rows[0].Cells[9].Value);
          

            string change = "UPDATE houses SET village = '" + village + "', street = '" + street + "', " +
                " numb_of_house = '" + numb_of_house + "', lastname = '" + lastname + "', name = '" + name + "'," +
                "surname = '" + surname + "',totalArea = '" + totalArea + "', livingArea = '" + livingArea + "'," +
                "total_of_rooms = '" + total_of_rooms + "' WHERE idhouses = '"+ idhouses+"'";

            if(MessageBox.Show(string.Format("Ви дійсно бажаєте зберегти зміни ?", 0), "Погоджуюсь",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ConnectionClass _manager = new ConnectionClass();
                _manager.openConnection();
                MySqlCommand ch = new MySqlCommand(change, _manager.getConnection());


                if (ch.ExecuteNonQuery() == 1)
                {
                    dataGridViewДомогосподарства_Пошук.Rows.RemoveAt(0);
                    MessageBox.Show("Дані успішно змінено ");
                    _manager.closeConnection();
                }
                else
                {
                    MessageBox.Show("Помилка роботи з базою даних !!!");
                }


            }
            dataGridViewДомогосподарства_Пошук.ReadOnly = true;


        }

        private void Редагувати_Click(object sender, EventArgs e)
        {
           // user = new User();

            //if (user.userName == "A")
           // {
                dataGridViewДомогосподарства_Пошук.ReadOnly = false;
           // }
            //else
            //{
            //    MessageBox.Show("У вас немає доступу до редагування даних !!!");
            //}
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }
    }
}
