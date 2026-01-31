using DataBase.Repositories;
using DataBase.Services;
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
        AddressService service = new AddressService();
        //private User user;


        public Домогосподарства_Пошук()
        { 
            InitializeComponent();
            service.LoadVillages(comboBoxVillage);
           
            textBoxCount.Text = "0";

            HeaderOfTheTable();
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                service.LoadStreets(comboBoxStreets, villageId);
            }
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

        private void dataGridViewДомогосподарства_Пошук_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewДомогосподарства_Пошук.Rows[e.RowIndex].Cells[0].Value);

                
                ДомогосподарстваРедагувати form = new ДомогосподарстваРедагувати(id);
                Program.OpenForm(this, form);
            }
        }
        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
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
        private void AddDataGrid(RowOfDataH row)
        {
            dataGridViewДомогосподарства_Пошук.Rows.Add(row.idhouses, row.village, row.street, row.numb_of_house, row.lastname, row.name,
                row.surname, row.totalArea, row.livingArea, row.total_of_rooms);
        }

        private void Знайти_Click(object sender, EventArgs e)
        {
            bool mess = false;
            int count = 0;

            dataGridViewДомогосподарства_Пошук.DataSource = null;
            dataGridViewДомогосподарства_Пошук.Rows.Clear();

            _dataH.Clear();

            if (comboBoxNumb.Text == "" && textBoxLastName.Text == "" && textBoxName.Text == "" && textBoxSurName.Text == ""
                && comboBoxVillage.Text == "" && comboBoxStreets.Text == "")
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

            string sql = "SELECT h.idhouses, v.name AS village, s.name AS street, h.numb_of_house, h.lastname," +
                        " h.name, h.surname, h.totalArea, h.livingArea, h.total_of_rooms" +
                        " FROM houses h" +
                        " JOIN villagestreet vs ON h.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE 1 = 1 ";
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(village) && comboBoxVillage.Text != "")
            {
                var village1 = comboBoxVillage.SelectedItem as Village;
                if (village1 == null)
                {
                    MessageBox.Show("Оберіть населений пункт !");
                    return;
                }
                int villageId = village1.Id;

                sql += " AND v.id = @villageId";
                parameters.Add(new MySqlParameter("@villageId", villageId));
            }
            if (!string.IsNullOrWhiteSpace(street) && comboBoxStreets.Text != "")
            {
                var street1 = comboBoxStreets.SelectedItem as Street;
                if (street1 == null)
                {
                    MessageBox.Show("Вкажіть вулицю !");
                    return;
                }
                int streetId = street1.Id;
                sql += " AND s.id = @streetId";
                parameters.Add(new MySqlParameter("@streetId", streetId));
            }
            if (!string.IsNullOrWhiteSpace(numb_of_house) && comboBoxNumb.Text != "")
            {
                sql += " AND LOWER(h.numb_of_house) = @house";
                parameters.Add(new MySqlParameter("@house", numb_of_house));
            }
            if (!string.IsNullOrWhiteSpace(name) && textBoxName.Text != "")
            {
                sql += " AND LOWER(h.name) LIKE @name";
                parameters.Add(new MySqlParameter("@name", name + "%"));
            }
            if (!string.IsNullOrWhiteSpace(lastname) && textBoxLastName.Text != "")
            {
                sql += " AND LOWER(h.lastname) LIKE @lastname";
                parameters.Add(new MySqlParameter("@lastname", lastname + "%"));
            }
            if (!string.IsNullOrWhiteSpace(surname) && textBoxSurName.Text != "")
            {
                sql += " AND LOWER(h.surname) LIKE @surname";
                parameters.Add(new MySqlParameter("@surname", surname + "%"));
            }

            ConnectionClass _manager = new ConnectionClass();
            try
            {
                sql += " ORDER BY v.name, s.name, h.lastname";
                _manager.openConnection();
                MySqlCommand cmd = new MySqlCommand(sql, _manager.getConnection());
                cmd.Parameters.AddRange(parameters.ToArray());

                MySqlDataReader _reader = cmd.ExecuteReader();

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
            Program.OpenForm(this, form);
        }

        private void вихідToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Очистити_Click(object sender, EventArgs e)
        {
            dataGridViewДомогосподарства_Пошук.Rows.Clear();
            comboBoxVillage.SelectedIndex = - 1;
            comboBoxStreets.SelectedIndex = - 1;
            comboBoxNumb.Text = "";
        }

       

        private void dataGridViewДомогосподарства_Пошук_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                DataGridViewRow row = dataGridViewДомогосподарства_Пошук.Rows[e.RowIndex];


                if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["idhouses"].Value), "Погоджуюсь",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();

                    string com = "DELETE FROM houses WHERE idhouses = '" + row.Cells["idhouses"].Value + "'";

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
    }
}
