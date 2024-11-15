using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ВивідДаних : Form
    {
         
        // private User user;

        public ВивідДаних()
        {
            
            InitializeComponent();
        }

        private void HeaderOfTheTable()
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            this.dataGridView1.EnableHeadersVisualStyles = false;


            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 55;
            column1.Name = "people_id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Прізвище";
            column2.Width = 120;
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
            column6.Width = 120;
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
            column8.Width = 120;
            column8.Name = "street";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Номер будинку";
            column9.Width = 100;
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
            column11.Width = 100;
            column11.Name = "id_kod";
            column11.Frozen = true;
            column11.CellTemplate = new DataGridViewTextBoxCell();

            var column12 = new DataGridViewColumn();
            column12.HeaderText = "Номер телефону";
            column12.Width = 120;
            column12.Name = "phone_numb";
            column12.Frozen = true;
            column12.CellTemplate = new DataGridViewTextBoxCell();

            var column13 = new DataGridViewColumn();
            column13.HeaderText = "Статус";
            column13.Width = 100;
            column13.Name = "status";
            column13.Frozen = true;
            column13.CellTemplate = new DataGridViewTextBoxCell();

            var column14 = new DataGridViewColumn();
            column14.HeaderText = "Ел. пошта";
            column14.Width = 120;
            column14.Name = "email";
            column14.Frozen = true;
            column14.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            dataGridView1.Columns.Add(column6);
            dataGridView1.Columns.Add(column7);
            dataGridView1.Columns.Add(column8);
            dataGridView1.Columns.Add(column9);
            dataGridView1.Columns.Add(column10);
            dataGridView1.Columns.Add(column11);
            dataGridView1.Columns.Add(column12);
            dataGridView1.Columns.Add(column13);
            dataGridView1.Columns.Add(column14);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void AddDataGrid(RowOfData row)
        {
            dataGridView1.Rows.Add(row.people_id, row.lastname, row.name, row.surname, row.sex,
                row.date_of_birth, row.village, row.street, row.numb_of_house, row.passport,
                row.id_kod, row.phone_numb, row.status, row.registr, row.M_Year);
        }

        private void ВивідДаних_Shown(object sender, EventArgs e)
        {
            //user = new User();

            HeaderOfTheTable();
            List<RowOfData> _data = new List<RowOfData>();
            ConnectionClass _manager = new ConnectionClass();
            MySqlCommand _command = new MySqlCommand("SELECT * FROM `people`", _manager.getConnection());
            MySqlDataReader _reader;

            _manager.openConnection();
            _reader = _command.ExecuteReader();

            try
            {
                
                while(_reader.Read())
                {
                    RowOfData row = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                        _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                        _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                        _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"]);
                    _data.Add(row);
                }

                for (int i = 0; i < _data.Count; i++)
                {
                    AddDataGrid(_data[i]);
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
            textBoxCountOfRows.Text = Convert.ToString(_data.Count);
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void вихідУВікноРеєстраціїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Реєстрація form = new Реєстрація();
            this.Hide();
            form.Show();
        }

        private void вихідУВікноВходуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Авторизація form = new Авторизація();
            this.Hide();
            form.Show();
        }


        private void оновитиДаніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //user = new User();

            HeaderOfTheTable();
            List<RowOfData> _data = new List<RowOfData>();
            ConnectionClass _manager = new ConnectionClass();
            MySqlCommand _command = new MySqlCommand("SELECT * FROM `people`", _manager.getConnection());
            MySqlDataReader _reader;


            _manager.openConnection();
            _reader = _command.ExecuteReader();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            try
            {

                while (_reader.Read())
                {
                    RowOfData row = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                        _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                        _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                        _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"]);
                    _data.Add(row);
                }

                for (int i = 0; i < _data.Count; i++)
                {
                    AddDataGrid(_data[i]);
                }
                MessageBox.Show("Дані в таблиці оновлені !");
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

        private void перейтиУВікноПошукуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ВікноПошуку form = new ВікноПошуку();
            this.Hide();
            form.Show();
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

        private void buttonПовернутись_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
        }
    }
}
