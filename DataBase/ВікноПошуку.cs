using DataBase.Repositories;
using DataBase.Services;
using Microsoft.Office.Interop.Word;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace DataBase
{
    public partial class ВікноПошуку : Form
    {
        private List<RowOfData> _data = new List<RowOfData>();
        AddressService service = new AddressService();
        // private User user;

        public ВікноПошуку()
        {
            InitializeComponent();
            HeaderOfTheTable();
            service.LoadVillages(comboBoxVillage);

            button1Пошук.Text = "Пошук  \U0001F504";
                 
            textBoxПрізвище.Text = "Прізвище";
            textBoxПрізвище.ForeColor = Color.Gray;

            textBoxІм_я.Text = "Ім'я";
            textBoxІм_я.ForeColor = Color.Gray;

            textBoxПобатькові.Text = "Побатькові";
            textBoxПобатькові.ForeColor = Color.Gray;

            comboBoxСтать.Text = "Стать";
            comboBoxСтать.ForeColor = Color.Gray;

            textBoxВікВІД.Text = "Вік від:";
            textBoxВікВІД.ForeColor = Color.Gray;

            textBoxВікДО.Text = "Вік до:";
            textBoxВікДО.ForeColor = Color.Gray;

            textBoxНомерБудинку.Text = "Номер будинку";
            textBoxНомерБудинку.ForeColor = Color.Gray;

            textBoxFileName.Text = "Назва файлу";
            textBoxFileName.ForeColor = Color.Gray;

            textBoxСтатус.Text = "Статус";
            textBoxСтатус.ForeColor = Color.Gray;

            textBoxM_Year.Text = "Рік зміни статусу";
            textBoxM_Year.ForeColor = Color.Gray;

            textBoxНомерДовідки.Text = "Вкажіть номер";
            textBoxНомерДовідки.ForeColor = Color.Gray;

            textBoxCount.Text = "0";

            РеєстраціяТак.CheckState = CheckState.Checked;
            РеєстраціяТак.BackColor = Color.AliceBlue;

            РеєстраціяНі.CheckState = CheckState.Unchecked;
            РеєстраціяНі.BackColor = Color.AliceBlue;

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
            this.dataGridViewВікноПошуку.DefaultCellStyle.Font = new System.Drawing.Font("TimeNewRoman", 10);
            this.dataGridViewВікноПошуку.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewВікноПошуку.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewВікноПошуку.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewВікноПошуку.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            this.dataGridViewВікноПошуку.EnableHeadersVisualStyles = false;


            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 50;
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
            column4.Width = 100;
            column4.Name = "surname";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Стать";
            column5.Width = 50;
            column5.Name = "sex";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Дата народження";
            column6.Width = 100;
            column6.Name = "date_of_birth";
            column6.Frozen = true;
            column6.DefaultCellStyle.Format = "d";
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Село";
            column7.Width = 90;
            column7.Name = "village";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Вулиця";
            column8.Width = 100;
            column8.Name = "street";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Ном буд";
            column9.Width = 40;
            column9.Name = "numb_of_house";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Паспорт";
            column10.Width = 90;
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
            column12.Width = 100;
            column12.Name = "phone_numb";
            column12.Frozen = true;
            column12.CellTemplate = new DataGridViewTextBoxCell();

            var column13 = new DataGridViewColumn();
            column13.HeaderText = "Статус";
            column13.Width = 80;
            column13.Name = "status";
            column13.Frozen = true;
            column13.CellTemplate = new DataGridViewTextBoxCell();

            var column14 = new DataGridViewColumn();
            column14.HeaderText = "Реєстр";
            column14.Width = 45;
            column14.Name = "registr";
            column14.Frozen = true;
            column14.CellTemplate = new DataGridViewTextBoxCell();

            var column15= new DataGridViewColumn();
            column15.HeaderText = "Рік зміни статусу";
            column15.Width = 100;
            column15.Name = "M_Year";
            column15.Frozen = true;
            column15.DefaultCellStyle.Format = "d";
            column15.CellTemplate = new DataGridViewTextBoxCell();

            var column16 = new DataGridViewColumn();
            column16.HeaderText = "Військ ID";
            column16.Width = 135;
            column16.Name = "Mil_ID";
            column16.Frozen = true;
            column16.DefaultCellStyle.Format = "d";
            column16.CellTemplate = new DataGridViewTextBoxCell();

            var column17 = new DataGridViewColumn();
            column17.HeaderText = "Видал";
            column17.Width = 50;
            column17.Name = "Видалити";
            column17.Frozen = true;
             column17.CellTemplate = new DataGridViewTextBoxCell();

            dataGridViewВікноПошуку.Columns.Add(column1);
            dataGridViewВікноПошуку.Columns.Add(column2);
            dataGridViewВікноПошуку.Columns.Add(column3);
            dataGridViewВікноПошуку.Columns.Add(column4);
            dataGridViewВікноПошуку.Columns.Add(column5);
            dataGridViewВікноПошуку.Columns.Add(column6);
            dataGridViewВікноПошуку.Columns.Add(column7);
            dataGridViewВікноПошуку.Columns.Add(column8);
            dataGridViewВікноПошуку.Columns.Add(column9);
            dataGridViewВікноПошуку.Columns.Add(column10);
            dataGridViewВікноПошуку.Columns.Add(column11);
            dataGridViewВікноПошуку.Columns.Add(column12);
            dataGridViewВікноПошуку.Columns.Add(column13);
            dataGridViewВікноПошуку.Columns.Add(column14);
            dataGridViewВікноПошуку.Columns.Add(column15);
            dataGridViewВікноПошуку.Columns.Add(column16);
            dataGridViewВікноПошуку.Columns.Add(column17);
           

            dataGridViewВікноПошуку.AllowUserToAddRows = false;
            dataGridViewВікноПошуку.ReadOnly = true;
        }

        private void ВікноПошуку_Shown(object sender, EventArgs e)
        {
            HeaderOfTheTable();
           // user = new User();
        }
       
        private void textBoxПрізвище_Enter(object sender, EventArgs e)
        {
            if (textBoxПрізвище.Text == "Прізвище")
            {
                textBoxПрізвище.Text = "";
                textBoxПрізвище.ForeColor = Color.Black;
            }
        }

        private void textBoxПрізвище_Leave(object sender, EventArgs e)
        {
            if (textBoxПрізвище.Text == "")
            {
                textBoxПрізвище.Text = "Прізвище";
                textBoxПрізвище.ForeColor = Color.Gray;
            }
        }

        private void textBoxІм_я_Enter(object sender, EventArgs e)
        {
            if (textBoxІм_я.Text == "Ім'я")
            {
                textBoxІм_я.Text = "";
                textBoxІм_я.ForeColor = Color.Black;
            }
        }

        private void textBoxІм_я_Leave(object sender, EventArgs e)
        {
            if (textBoxІм_я.Text == "")
            {
                textBoxІм_я.Text = "Ім'я";
                textBoxІм_я.ForeColor = Color.Gray;
            }
        }

        private void textBoxПобатькові_Enter(object sender, EventArgs e)
        {
            if (textBoxПобатькові.Text == "Побатькові")
            {
                textBoxПобатькові.Text = "";
                textBoxПобатькові.ForeColor = Color.Black;
            }
        }

        private void textBoxПобатькові_Leave(object sender, EventArgs e)
        {
            if (textBoxПобатькові.Text == "")
            {
                textBoxПобатькові.Text = "Побатькові";
                textBoxПобатькові.ForeColor = Color.Gray;
            }
        }

        private void textBoxВікВІД_Enter(object sender, EventArgs e)
        {
            if (textBoxВікВІД.Text == "Вік від:")
            {
                textBoxВікВІД.Text = "";
                textBoxВікВІД.ForeColor = Color.Black;
            }
        }

        private void textBoxВікВІД_Leave(object sender, EventArgs e)
        {
            if (textBoxВікВІД.Text == "")
            {
                textBoxВікВІД.Text = "Вік від:";
                textBoxВікВІД.ForeColor = Color.Gray;
            }
        }

        private void textBoxВікДО_Enter(object sender, EventArgs e)
        {
            if (textBoxВікДО.Text == "Вік до:")
            {
                textBoxВікДО.Text = "";
                textBoxВікДО.ForeColor = Color.Black;
            }
        }

        private void textBoxВікДО_Leave(object sender, EventArgs e)
        {
            if (textBoxВікДО.Text == "")
            {
                textBoxВікДО.Text = "Вік до:";
                textBoxВікДО.ForeColor = Color.Gray;
            }
        }
        private void textBoxНомерБудинку_Enter(object sender, EventArgs e)
        {
            if (textBoxНомерБудинку.Text == "Номер будинку")
            {
                textBoxНомерБудинку.Text = "";
                textBoxНомерБудинку.ForeColor = Color.Black;
            }
        }

        private void textBoxНомерБудинку_Leave(object sender, EventArgs e)
        {
            if (textBoxНомерБудинку.Text == "")
            {
                textBoxНомерБудинку.Text = "Номер будинку";
                textBoxНомерБудинку.ForeColor = Color.Gray;
            }
        }

        private void textBoxСтатус_Enter(object sender, EventArgs e)
        {
            if (textBoxСтатус.Text == "Статус")
            {
                textBoxСтатус.Text = "";
                textBoxСтатус.ForeColor = Color.Black;
            }
        }

        private void textBoxСтатус_Leave(object sender, EventArgs e)
        {
            if (textBoxСтатус.Text == "")
            {
                textBoxСтатус.Text = "Статус";
                textBoxСтатус.ForeColor = Color.Gray;
            }
        }
       
        private void textBoxM_Year_Enter(object sender, EventArgs e)
        {
            if (textBoxM_Year.Text == "Рік зміни статусу")
            {
                textBoxM_Year.Text = "";
                textBoxM_Year.ForeColor = Color.Black;
            }
        }

        private void textBoxM_Year_Leave(object sender, EventArgs e)
        {
            if (textBoxM_Year.Text == "")
            {
                textBoxM_Year.Text = "Рік зміни статусу";
                textBoxM_Year.ForeColor = Color.Gray;
            }
        }

        private void textBoxНомерДовідки_Enter(object sender, EventArgs e)
        {

            if (textBoxНомерДовідки.Text == "Вкажіть номер")
            {
                textBoxНомерДовідки.Text = "";
                textBoxНомерДовідки.ForeColor = Color.Black;
            }
        }

        private void textBoxНомерДовідки_Leave(object sender, EventArgs e)
        {
            if (textBoxНомерДовідки.Text == "")
            {
                textBoxНомерДовідки.Text = "Вкажіть номер";
                textBoxНомерДовідки.ForeColor = Color.Gray;
            }
        }

        private void buttonОчиститиПоля_Click(object sender, EventArgs e)
        {
            textBoxПрізвище.Text = "Прізвище";
            textBoxПрізвище.ForeColor = Color.Gray;

            textBoxІм_я.Text = "Ім'я";
            textBoxІм_я.ForeColor = Color.Gray;

            textBoxПобатькові.Text = "Побатькові";
            textBoxПобатькові.ForeColor = Color.Gray;

            comboBoxСтать.Text = "Стать";
            comboBoxСтать.ForeColor = Color.Gray;

            comboBoxStreets.SelectedIndex = -1;

            comboBoxVillage.SelectedIndex = -1;

            textBoxВікВІД.Text = "Вік від:";
            textBoxВікВІД.ForeColor = Color.Gray;

            textBoxВікДО.Text = "Вік до:";
            textBoxВікДО.ForeColor = Color.Gray;


            textBoxСтатус.Text = "Статус";
            textBoxСтатус.ForeColor = Color.Gray;

            textBoxM_Year.Text = "Рік зміни статусу";
            textBoxСтатус.ForeColor = Color.Gray;

            textBoxНомерБудинку.Text = "Номер будинку";
            textBoxНомерБудинку.ForeColor = Color.Gray;

            textBoxFileName.Text = "Назва файлу";
            textBoxFileName.ForeColor = Color.Gray;

            textBoxНомерДовідки.Text = "Вкажіть номер";
            textBoxНомерДовідки.ForeColor = Color.Gray;
        }

        private void AddDataGrid(RowOfData row)
        {
            dataGridViewВікноПошуку.Rows.Add(row.people_id, row.lastname, row.name, row.surname, row.sex,
                row.date_of_birth, row.village, row.street, row.numb_of_house, row.passport,
                row.id_kod, row.phone_numb, row.status, row.registr, row.M_Year, row.Mil_ID);
        }

        private void button1Пошук_Click(object sender, EventArgs e)
        {
            // Очистка DataGridView
            dataGridViewВікноПошуку.DataSource = null;
            dataGridViewВікноПошуку.Rows.Clear();
            _data.Clear();

            // Перевірка, що хоча б одне поле заповнене
            if (textBoxПрізвище.Text == "Прізвище" &&
                textBoxІм_я.Text == "Ім'я" &&
                textBoxПобатькові.Text == "Побатькові" &&
                comboBoxVillage.Text == "" &&
                string.IsNullOrWhiteSpace(comboBoxStreets.Text) &&
                comboBoxСтать.Text == "Стать" &&
                textBoxВікВІД.Text == "Вік від:" &&
                textBoxВікДО.Text == "Вік до:" &&
                textBoxНомерБудинку.Text == "Номер будинку" &&
                textBoxСтатус.Text == "Статус" &&
                textBoxM_Year.Text == "Рік зміни статусу")
            {
                MessageBox.Show("Жодне поле пошуку не заповнено !");
                return;
            }

            // Підготовка параметрів пошуку
            string lastname = textBoxПрізвище.Text.ToLower().Replace("'", "`").Trim();
            string name = textBoxІм_я.Text.ToLower().Replace("'", "`").Trim();
            string surname = textBoxПобатькові.Text.ToLower().Replace("'", "`").Trim();
            string sex = comboBoxСтать.SelectedItem?.ToString();
            string village = comboBoxVillage.Text.ToLower();
            string street = comboBoxStreets.Text.ToLower();
            string numb_of_house = textBoxНомерБудинку.Text.ToLower().Trim();
            string status = textBoxСтатус.Text.ToLower();
            string registr = (РеєстраціяТак.CheckState == CheckState.Unchecked) ? "ні" : "так";

            // Побудова SQL з WHERE 1=1
            string sql = "SELECT p.people_id, p.lastname, p.name, p.surname, p.sex, p.date_of_birth, v.name AS village, s.name AS street," +
                        " p.numb_of_house, p.passport, p.id_kod, p.phone_numb, p.status, p.registr, p.m_date, p.mil_ID" +
                        " FROM people p" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE 1 = 1 ";

            var parameters = new List<MySqlParameter>();

            if (РеєстраціяТак.CheckState == CheckState.Unchecked)
            {
                РеєстраціяНі.Checked = true;
            }

            if (РеєстраціяНі.CheckState == CheckState.Checked && РеєстраціяТак.CheckState == CheckState.Checked)
            {
            }
            else
            {
                sql += " AND LOWER(registr) = @registr";
                parameters.Add(new MySqlParameter("@registr", registr));
            }

            if (!string.IsNullOrWhiteSpace(status) && textBoxСтатус.Text != "Статус")
            {
                sql += " AND LOWER(status) LIKE @status";
                parameters.Add(new MySqlParameter("@status", "%" + status + "%"));
            }
            if (!string.IsNullOrWhiteSpace(textBoxM_Year.Text) && textBoxM_Year.Text != "Рік зміни статусу")
            {
                if (int.TryParse(textBoxM_Year.Text, out int year))
                {
                    sql += " AND YEAR(m_date) = @year";
                    parameters.Add(new MySqlParameter("@year", year));
                }
            }
            if (!string.IsNullOrWhiteSpace(lastname) && textBoxПрізвище.Text != "Прізвище")
            {
                sql += " AND LOWER(lastname) LIKE @lastname";
                parameters.Add(new MySqlParameter("@lastname", lastname + "%"));
            }
            if (!string.IsNullOrWhiteSpace(name) && textBoxІм_я.Text != "Ім'я")
            {
                sql += " AND LOWER(p.name) LIKE @name";
                parameters.Add(new MySqlParameter("@name", name + "%"));
            }
            if (!string.IsNullOrWhiteSpace(surname) && textBoxПобатькові.Text != "Побатькові")
            {
                sql += " AND LOWER(surname) LIKE @surname";
                parameters.Add(new MySqlParameter("@surname", surname + "%"));
            }
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
            if (!string.IsNullOrWhiteSpace(sex) && textBoxСтать.Text != "Стать")
            {
                sql += " AND LOWER(sex) LIKE @sex";
                parameters.Add(new MySqlParameter("@sex", sex.ToLower() + "%"));
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
            if (!string.IsNullOrWhiteSpace(numb_of_house) && textBoxНомерБудинку.Text != "Номер будинку")
            {
                sql += " AND LOWER(numb_of_house) = @house";
                parameters.Add(new MySqlParameter("@house", numb_of_house));
            }

            int minAge = 0;
            int maxAge = 150; // максимально можливий вік

            if (textBoxВікВІД.Text != "Вік від:" && !string.IsNullOrWhiteSpace(textBoxВікВІД.Text))
            {
                if (!int.TryParse(textBoxВікВІД.Text, out minAge))
                {
                    MessageBox.Show("Неправильний вік у полі 'Вік від'");
                    return;
                }
            }

            if (textBoxВікДО.Text != "Вік до:" && !string.IsNullOrWhiteSpace(textBoxВікДО.Text))
            {
                if (!int.TryParse(textBoxВікДО.Text, out maxAge))
                {
                    MessageBox.Show("Неправильний вік у полі 'Вік до'");
                    return;
                }
            }
            // Фільтр за віком
           
            DateTime today = DateTime.Today;
            DateTime earliestBirth = today.AddYears(-maxAge); // найстарший
            DateTime latestBirth = today.AddYears(-minAge);   // наймолодший
            sql += " AND date_of_birth BETWEEN @earliest AND @latest";
            parameters.Add(new MySqlParameter("@earliest", earliestBirth));
            parameters.Add(new MySqlParameter("@latest", latestBirth));
            

            // Виконання запиту
            ConnectionClass _manager = new ConnectionClass();
            try
            {
                sql += " ORDER BY v.name, s.name, p.lastname";
                _manager.openConnection();
                MySqlCommand cmd = new MySqlCommand(sql, _manager.getConnection());
                cmd.Parameters.AddRange(parameters.ToArray());

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RowOfData row = new RowOfData(
                        reader["people_id"], reader["lastname"], reader["name"],
                        reader["surname"], reader["sex"], reader["date_of_birth"],
                        reader["village"], reader["street"], reader["numb_of_house"],
                        reader["passport"], reader["id_kod"], reader["phone_numb"],
                        reader["status"], reader["registr"], reader["m_date"], reader["mil_ID"]);
                    _data.Add(row);
                }
            }
            catch
            {
                MessageBox.Show("Помилка роботи з базою даних !");
                return;
            }
            finally
            {
                _manager.closeConnection();
            }

            // Заповнення DataGridView
            foreach (var row in _data)
            {
                AddDataGrid(row);
                var gridRow = dataGridViewВікноПошуку.Rows[dataGridViewВікноПошуку.Rows.Count - 1];

                // Виділення померлих
                
                if (!string.IsNullOrEmpty(row.registr.ToString()) && row.registr.ToString().ToLower() == "ні")
                {
                    gridRow.DefaultCellStyle.BackColor = Color.LightCoral;
                    gridRow.DefaultCellStyle.ForeColor = Color.Black;
                    if (!string.IsNullOrEmpty(row.status.ToString()) && row.status.ToString().ToLower().Contains("помер"))
                    {
                        gridRow.DefaultCellStyle.BackColor = Color.Black;
                        gridRow.DefaultCellStyle.ForeColor = Color.White;
                    }
                }

                // Кнопка видалення
                gridRow.Cells[16].Value = "🗑️";
                gridRow.Cells[16].Style.BackColor = Color.DarkRed;
                gridRow.Cells[16].Style.ForeColor = Color.White;

                gridRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Підрахунок записів
            textBoxCount.Text = _data.Count.ToString();

            if (_data.Count == 0)
            {
                MessageBox.Show("Запис не знайдено !");
            }
        }


        private void buttonОчиститиТаблицю_Click(object sender, EventArgs e)
        {
            dataGridViewВікноПошуку.Rows.Clear();
            textBoxCount.Text = "0";
        }

        private void textBoxFileName_Enter(object sender, EventArgs e)
        {
            if (textBoxFileName.Text == "Назва файлу")
            {
                textBoxFileName.Text = "";
                textBoxFileName.ForeColor = Color.Black;
            }
        }

        private void textBoxFileName_Leave(object sender, EventArgs e)
        {
            if (textBoxFileName.Text == "")
            {
                textBoxFileName.Text = "Назва файлу";
                textBoxFileName.ForeColor = Color.Gray;
            }
        }

        private void buttonExportInExcel_Click(object sender, EventArgs e)
        {
            if (textBoxFileName.Text != "Назва файлу")
            {
                string fileName = Convert.ToString(textBoxFileName.Text);

                if (fileName == "")
                {
                    MessageBox.Show("Введіть назву файлу ! ");
                }
                else
                {
                    string path = "C:\\База Даних\\" + fileName + ".xlsx";

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(@"C:\База Даних"))
                    {
                        Directory.CreateDirectory(@"C:\База Даних");
                    }

                    Excel.Application exApp = new Excel.Application();
                    Excel.Workbook workbook = exApp.Workbooks.Add();
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                    worksheet.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells.Font.Size = 14;
                    worksheet.Rows[1].Columns[1] = "П/н";
                    worksheet.Rows[1].Columns[2] = "Прізвище";
                    worksheet.Rows[1].Columns[3] = "Ім'я";
                    worksheet.Rows[1].Columns[4] = "Побатькові";
                    worksheet.Rows[1].Columns[5] = "";
                    worksheet.Rows[1].Columns[6] = "Дата нар.";
                    worksheet.Rows[1].Columns[7] = "Село";
                    worksheet.Rows[1].Columns[8] = "Вулиця";
                    worksheet.Rows[1].Columns[9] = "Ном.буд.";
                    worksheet.Rows[1].Columns[10] = "Паспорт";
                    worksheet.Rows[1].Columns[11] = "Ідент. код";
                    worksheet.Rows[1].Columns[12] = "Військ. ID";
                    

                    for (int i = 2; i < dataGridViewВікноПошуку.RowCount + 2; i++)
                    {
                        worksheet.Rows[i].Columns[1] = i - 1;
                        for (int j = 2; j < dataGridViewВікноПошуку.ColumnCount + 1; j++)
                        {
                            if (j != 5 && j != 12 && j != 13 && j != 14 && j != 15 && j != 16)
                           
                            worksheet.Rows[i].Columns[j] = dataGridViewВікноПошуку.Rows[i - 2].Cells[j - 1].Value;
                        }
                        
                    }
                    Excel.Range usedRange = worksheet.UsedRange;
                    Excel.Range columnToDelete = worksheet.Columns[5];
                    Excel.Range row = worksheet.Rows[1];
                    row.Font.Size = 16;
                    row.Font.Bold = true;
                    // Автоматично змінюємо ширину стовпців для відповідності вмісту
                    usedRange.Columns.AutoFit();
                    columnToDelete.Delete();
                    exApp.AlertBeforeOverwriting = false;
                    worksheet.SaveAs(path);
                    exApp.Quit();
                }

                MessageBox.Show("Файл збережено на диск C в папку База Даних");
            }
            else
                MessageBox.Show("Спочатку введіть назву файлу !!!");
        }

        private void rjButtonПовернутись_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
        }

        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = System.Windows.Forms.Application.OpenForms.OfType<Головна>().FirstOrDefault();
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

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Картки_Click(object sender, EventArgs e)
        {
            Картки.BackColor = Color.IndianRed;

            if (MessageBox.Show(string.Format("Ви дійсно бажаєте отримати картки первинного обліку для усіх {0} записів у таблиці ?",
                arg0: dataGridViewВікноПошуку.RowCount), "Погоджуюсь",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                if (dataGridViewВікноПошуку.RowCount != 0)
                {
                    for (int i = 1; i < dataGridViewВікноПошуку.RowCount + 1; i++)
                    {
                        string ПІП = dataGridViewВікноПошуку.Rows[i - 1].Cells[1].Value.ToString()
                                     + " " + dataGridViewВікноПошуку.Rows[i - 1].Cells[2].Value.ToString()
                                     + " " + dataGridViewВікноПошуку.Rows[i - 1].Cells[3].Value.ToString();
                        string dd_mm_yyy = dataGridViewВікноПошуку.Rows[i - 1].Cells[5].Value.ToString();
                        string date = dd_mm_yyy.Substring(0, 10) + "p.";
                        string Село = dataGridViewВікноПошуку.Rows[i - 1].Cells[6].Value.ToString();
                        string Вулиця = dataGridViewВікноПошуку.Rows[i - 1].Cells[7].Value.ToString();
                        string Номер = dataGridViewВікноПошуку.Rows[i - 1].Cells[8].Value.ToString();
                        string іпн = dataGridViewВікноПошуку.Rows[i - 1].Cells[10].Value.ToString();
                        string pass = dataGridViewВікноПошуку.Rows[i - 1].Cells[9].Value.ToString();
                        string серія = null;
                        string номПас = null;
                        if (pass != "")
                        {
                            bool containsLetters = pass.Any(char.IsLetter);
                            if (containsLetters)
                            {
                                pass = pass.Replace(" ", "");
                                серія = pass.Substring(0, 2);
                                номПас = pass.Substring(2, 6);
                            }
                            else
                            {
                                номПас = pass;
                            }
                        }

                        var items = new Dictionary<string, string>
                    {
                        { "Прізвище Ім'я Побатькові", ПІП },
                        { "dd mm yyyy", date },
                        { "іденткод", іпн },
                        { "SER", серія },
                        { "номПас", номПас },
                        { "Село", Село },
                        { "Вулиця", Вулиця },
                        { "Номербуд", Номер }
                    };
                        string fileName = ПІП;

                        var app = new Word.Application();
                        Object file = Path.Combine(Directory.GetCurrentDirectory(), "DocTemplates", "Картка_Шаблон.doc");
                        Object missing = Type.Missing;

                        app.Documents.Open(ref file);

                        foreach (var item in items)
                        {
                            if (item.Value == null)
                            {
                                Word.Find find = app.Selection.Find;
                                find.ClearFormatting();
                                find.Text = item.Key;
                                find.Replacement.ClearFormatting();
                                find.Replacement.Text = "______";

                                object replaceAll = Word.WdReplace.wdReplaceAll;
                                find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                            }
                            else
                            {
                                Word.Find find = app.Selection.Find;
                                find.ClearFormatting();
                                find.Text = item.Key;
                                find.Replacement.ClearFormatting();
                                find.Replacement.Text = item.Value;

                                object replaceAll = Word.WdReplace.wdReplaceAll;
                                find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                        }
                        // Визначення шляху до тимчасової папки
                        string tempFolderPath = @"C:\Картки первинного обліку\";
                        string tempFilePath = @tempFolderPath + ПІП + ".doc";

                        // Створення папки, якщо її немає
                        if (!Directory.Exists(tempFolderPath))
                        {
                            Directory.CreateDirectory(tempFolderPath);
                        }

                        // Зберігаємо зміни в тимчасовий файл
                        app.ActiveDocument.SaveAs2(tempFilePath);
                        app.ActiveDocument.Close();
                        app.Quit();

                    }

                    MessageBox.Show("Файл збережено на диску C в папку Картки первинного обліку");
                    Картки.BackColor = Color.PeachPuff;
                }
                else
                {
                    MessageBox.Show("Немає вибраної особи для формування картки. Спочатку виберіть особу або кілька осіб");
                    Картки.BackColor = Color.PeachPuff;
                }
            }
            else
            {
                Картки.BackColor = Color.PeachPuff;
            }
        }


        private void dataGridViewВікноПошуку_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //user = new User();

            //if (user.userName == "A")
            //{

                if (e.ColumnIndex == 16)
                {
                    DataGridViewRow row = dataGridViewВікноПошуку.Rows[e.RowIndex];


                    if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["people_id"].Value), "Погоджуюсь",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionClass _manager = new ConnectionClass();
                        _manager.openConnection();

                        string com = "DELETE FROM people WHERE people_id = '" + row.Cells["people_id"].Value + "'";

                        MySqlCommand dell = new MySqlCommand(com, _manager.getConnection());


                        if (dell.ExecuteNonQuery() == 1)
                        {
                            dataGridViewВікноПошуку.Rows.RemoveAt(row.Index);
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

        private void buttonДовідка_Click(object sender, EventArgs e)
        {
            buttonДовідка.BackColor = Color.IndianRed;

            if (textBoxНомерДовідки.Text == "Вкажіть номер")
            {
                MessageBox.Show("Спочатку вкажіть порядковий номер довідки !");
                buttonДовідка.BackColor = Color.PeachPuff;
                return;
            }
            else
            {
                if (dataGridViewВікноПошуку.RowCount != 0 && dataGridViewВікноПошуку.SelectedRows.Count != 0)
                {
                    int id = Convert.ToInt32(dataGridViewВікноПошуку.SelectedRows[0].Cells[0].Value);
                    string ПІП = dataGridViewВікноПошуку.SelectedRows[0].Cells[1].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[2].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[3].Value.ToString();
                    string dd_mm_yyy = dataGridViewВікноПошуку.SelectedRows[0].Cells[5].Value.ToString();
                    string date = dd_mm_yyy.Substring(0, 10) + " p.н.";
                    string Село = dataGridViewВікноПошуку.SelectedRows[0].Cells[6].Value.ToString();
                    string Вулиця = dataGridViewВікноПошуку.SelectedRows[0].Cells[7].Value.ToString();
                    string Номер = dataGridViewВікноПошуку.SelectedRows[0].Cells[8].Value.ToString();
                    string sex = dataGridViewВікноПошуку.SelectedRows[0].Cells[4].Value.ToString();
                    string житель = "жителю";
                    string жителька = "жительці";
                    string його = "його";
                    string її = "її";
                    string DateNow = DateTime.Now.ToShortDateString();
                    string NumbOfDoc = textBoxНомерДовідки.Text.ToString();

                    AddressIds ids = new AddressIds();
                    int villagestreetId = ids.GetVillageStreetIdByPeopleId(id);

                    string select = "SELECT p.people_id, p.lastname, p.name, p.surname, p.sex, p.date_of_birth, v.name AS village, s.name AS street," +
                        " p.numb_of_house, p.passport, p.id_kod, p.phone_numb, p.status, p.registr, p.m_date, p.mil_ID" +
                        " FROM people p" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE p.villagestreetId = @villagestreetId" +
                        " AND p.numb_of_house = @numb_of_house" +
                        " AND p.people_id <> @id" +
                        " AND p.registr = 'так'";
                     
                    string selectTotalArea = "SELECT totalArea FROM houses WHERE `villagestreetId` = @villagestreetId" +
                        " AND `numb_of_house` = @numb_of_house";
                   
                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();
                    MySqlCommand comand = new MySqlCommand(select, _manager.getConnection());
                    comand.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comand.Parameters.AddWithValue("@numb_of_house", Номер);
                    comand.Parameters.AddWithValue("@id", id);
                    MySqlDataReader _reader;
                    _reader = comand.ExecuteReader();

                    _data.Clear();

                    while (_reader.Read())
                    {
                        RowOfData row_1 = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                            _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                            _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                            _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"], _reader["mil_ID"]);
                        _data.Add(row_1);

                    }
                    _manager.closeConnection();

                    _manager.openConnection();
                    MySqlCommand comandTotalArea = new MySqlCommand(selectTotalArea, _manager.getConnection());
                    comandTotalArea.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comandTotalArea.Parameters.AddWithValue("@numb_of_house", Номер);
                    string totalArea = comandTotalArea.ExecuteScalar().ToString();
                    _manager.closeConnection();
                    
                    Word.Application wordApp = new Word.Application();

                    string currentDirectory = Directory.GetCurrentDirectory();

                    string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "ШаблонСкладСім.docx");

                    Document document = wordApp.Documents.Open(temlatePath);

                    // Заміна слова у всьому документі
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    if (sex == "чол")
                    {
                        replacements.Add("жителю", житель);
                        if (_data.Count > 1)
                        {
                            replacements.Add("його", його);
                        }
                        else
                        {
                            replacements.Add("його сім’я складається з наступних осіб : ", " за даною адресою він зареєстрований один.");
                        }
                    }
                    else
                    {
                        replacements.Add("жителю", жителька);
                        if (_data.Count > 1)
                        {
                            replacements.Add("його", її);
                        }
                        else
                        {
                            replacements.Add("його сім’я складається з наступних осіб : ", " за даною адресою вона зареєстрована одна.");
                        }
                    }
                    replacements.Add("ПоточнаДата", DateNow);
                    replacements.Add("НомерДовідки", NumbOfDoc);
                    replacements.Add("село", Село);
                    replacements.Add("вулиця", Вулиця);
                    replacements.Add("номер", Номер);
                    replacements.Add("піп", ПІП);
                    replacements.Add("дата", date);

                    // Вставляємо список у місце закладки
                    Word.Range range = document.Bookmarks["ListPlace"].Range;
                    range.Text = string.Join("\n\n", _data.Select((x, i) =>
                    $"{i + 1}.  {x.lastname} {x.name} {x.surname}  -  {x.date_of_birth.ToString().Substring(0 ,10)} р.н."));

                    replacements.Add("ЗагальнаПлоща", totalArea);

                    foreach (var replacement in replacements)
                    {
                        // Визначаємо об'єкт для пошуку
                        Find find = wordApp.Selection.Find;

                        // Налаштовуємо параметри пошуку
                        find.ClearFormatting();
                        find.Text = replacement.Key; // Текст для пошуку
                        find.Replacement.ClearFormatting();
                        find.Replacement.Text = replacement.Value; // Текст для заміни

                        // Виконуємо заміну у всьому документі
                        find.Execute(Replace: WdReplace.wdReplaceAll);
                    }

                    // Визначення шляху до тимчасової папки
                    string tempFolderPath = @"C:\Довідки про склад сім'ї";
                    string tempFilePath = Path.Combine(tempFolderPath, ПІП + ".docx");

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }

                    // Зберігаємо зміни в тимчасовий файл
                    document.SaveAs(tempFilePath);

                    // Відкриваємо документ в Word для перегляду
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true
                    });

                    MessageBox.Show("Довідку для " + ПІП + " збережено на диску С в папці - Довідки про склад сім'ї");
                    buttonДовідка.BackColor = Color.PeachPuff;
                }
                else
                {
                    MessageBox.Show("Немає вибраної особи для формування довідки. Спочатку виберіть особу");
                    buttonДовідка.BackColor = Color.PeachPuff;
                    return;
                }
            }

        }

        private void buttonХарактеристика_Click(object sender, EventArgs e)
        {
            buttonХарактеристика.BackColor = Color.IndianRed;

            if (textBoxНомерДовідки.Text == "Вкажіть номер")
            {
                MessageBox.Show("Спочатку вкажіть порядковий номер характеристики !");
                buttonХарактеристика.BackColor = Color.PeachPuff;
                return;
            }
            else
            {
                if (dataGridViewВікноПошуку.RowCount != 0 && dataGridViewВікноПошуку.SelectedRows.Count != 0)
                {
                    int id = Convert.ToInt32(dataGridViewВікноПошуку.SelectedRows[0].Cells[0].Value);
                    string ПІП = dataGridViewВікноПошуку.SelectedRows[0].Cells[1].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[2].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[3].Value.ToString();
                    string dd_mm_yyy = dataGridViewВікноПошуку.SelectedRows[0].Cells[5].Value.ToString();
                    string date = dd_mm_yyy.Substring(0, 10) + " p.н.";
                    string Село = dataGridViewВікноПошуку.SelectedRows[0].Cells[6].Value.ToString();
                    string Вулиця = dataGridViewВікноПошуку.SelectedRows[0].Cells[7].Value.ToString();
                    string Номер = dataGridViewВікноПошуку.SelectedRows[0].Cells[8].Value.ToString();
                    string sex = dataGridViewВікноПошуку.SelectedRows[0].Cells[4].Value.ToString();
                    string громадянин = "громадянина";
                    string громадянка = "громадянку";
                    string його = "його";
                    string її = "її";
                    string зареєстрована = "зареєстрована";
                    string DateNow = DateTime.Now.ToShortDateString();
                    string NumbOfDoc = textBoxНомерДовідки.Text.ToString();

                    string select = "SELECT p.people_id, p.lastname, p.name, p.surname, p.sex, p.date_of_birth, v.name AS village, s.name AS street," +
                        " s.name AS street, p.numb_of_house, p.passport, p.id_kod, p.phone_numb, p.status, p.registr, p.m_date, p.mil_ID" +
                        " FROM people p" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE p.people_id = @id";

                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();
                    MySqlCommand comand = new MySqlCommand(select, _manager.getConnection());
                    comand.Parameters.AddWithValue("@id", id);
                    MySqlDataReader _reader;
                    _reader = comand.ExecuteReader();

                    _data.Clear();

                    while (_reader.Read())
                    {
                        RowOfData row_1 = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                            _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                            _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                            _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"], _reader["Mil_ID"]);
                        _data.Add(row_1);

                    }
                    _manager.closeConnection();

                    Word.Application wordApp = new Word.Application();

                    string currentDirectory = Directory.GetCurrentDirectory();

                    string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "ШаблонХарактеристика.docx");

                    Document document = wordApp.Documents.Open(temlatePath);

                    // Заміна слова у всьому документі
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    if (sex == "чол")
                    {
                        replacements.Add("громадянин", громадянин);
                        replacements.Add("його", його);
                    }
                    else
                    {
                        replacements.Add("громадянин", громадянка);
                        replacements.Add("його", її);
                        replacements.Add("зареєстрований", зареєстрована);
                    }

                    replacements.Add("ПоточнаДата", DateNow);
                    replacements.Add("НомерДовідки", NumbOfDoc);
                    replacements.Add("село", Село);
                    replacements.Add("вулиця", Вулиця);
                    replacements.Add("номер", Номер);
                    replacements.Add("піп", ПІП);
                    replacements.Add("дата", date);

                    foreach (var replacement in replacements)
                    {
                        // Визначаємо об'єкт для пошуку
                        Find find = wordApp.Selection.Find;

                        // Налаштовуємо параметри пошуку
                        find.ClearFormatting();
                        find.Text = replacement.Key; // Текст для пошуку
                        find.Replacement.ClearFormatting();
                        find.Replacement.Text = replacement.Value; // Текст для заміни

                        // Виконуємо заміну у всьому документі
                        find.Execute(Replace: WdReplace.wdReplaceAll);
                    }

                    // Визначення шляху до тимчасової папки
                    string tempFolderPath = @"C:\Характеристики";
                    string tempFilePath = Path.Combine(tempFolderPath, ПІП + ".docx");

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }

                    // Зберігаємо зміни в тимчасовий файл
                    document.SaveAs(tempFilePath);

                    // Відкриваємо документ в Word для перегляду
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true
                    });

                    MessageBox.Show("Характеристику на " + ПІП + " збережено на диску C в папці - Характеристики");
                    buttonХарактеристика.BackColor = Color.PeachPuff;
                }
                else
                {
                    MessageBox.Show("Немає вибраної особи для формування довідки. Спочатку виберіть особу");
                    buttonХарактеристика.BackColor = Color.PeachPuff;
                    return;
                }
            }
        }

        private void РеєстраціяТак_CheckedChanged(object sender, EventArgs e)
        {
            if(РеєстраціяТак.CheckState == CheckState.Unchecked)
            {
                РеєстраціяНі.Checked = true;
            }
        }

        private void РеєстраціяНі_CheckedChanged(object sender, EventArgs e)
        {
            if(РеєстраціяНі.CheckState == CheckState.Unchecked)
            {
                РеєстраціяТак.Checked = true;
            }
        }

        private void Заповіт_Click(object sender, EventArgs e)
        {
            Заповіт.BackColor = Color.IndianRed;

            if (textBoxНомерДовідки.Text == "Вкажіть номер")
            {
                MessageBox.Show("Спочатку вкажіть порядковий номер заповіту !");
                Заповіт.BackColor = Color.PeachPuff;
                return;
            }
            else
            {
                if (dataGridViewВікноПошуку.RowCount != 0 && dataGridViewВікноПошуку.SelectedRows.Count != 0)
                {
                    DateToString dateSTR = new DateToString();
                    string dateString = dateSTR.GetDateInWords();
                    string nunbOfWill = textBoxНомерДовідки.Text;
                    string ПІП = dataGridViewВікноПошуку.SelectedRows[0].Cells[1].Value.ToString()
                                   + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[2].Value.ToString()
                                   + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[3].Value.ToString();
                    string sex = dataGridViewВікноПошуку.SelectedRows[0].Cells[4].Value.ToString();
                    string dd_mm_yyy = dataGridViewВікноПошуку.SelectedRows[0].Cells[5].Value.ToString();
                    string dateOfBirth = dd_mm_yyy.Substring(0, 10) + " p.н.";
                    string Село = dataGridViewВікноПошуку.SelectedRows[0].Cells[6].Value.ToString();
                    string Вулиця = dataGridViewВікноПошуку.SelectedRows[0].Cells[7].Value.ToString();
                    string НомерБуд = dataGridViewВікноПошуку.SelectedRows[0].Cells[8].Value.ToString();
                    string ідентНомер = dataGridViewВікноПошуку.SelectedRows[0].Cells[10].Value.ToString();
                    string whichBorn = "";
                    string registr = "";
                    string who = "";
                    if (sex == "чол")
                    {
                        whichBorn = "який народився";
                        registr = "зареєстрований";
                        who = "ним";
                    }
                    else
                    {
                        whichBorn = "яка народилася";
                        registr = "зареєстрована";
                        who = "нею";
                    }

                    Word.Application wordApp = new Word.Application();
                    

                    string currentDirectory = Directory.GetCurrentDirectory();

                    string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "Шаблон_заповіт.docx");

                    Document document = wordApp.Documents.Open(temlatePath);

                    //Заміна слова у всьому документі
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    replacements.Add("ідентифікаційний_номер", ідентНомер);
                    replacements.Add("номер_заповіту", nunbOfWill);
                    replacements.Add("село", Село);
                    replacements.Add("вулиця", Вулиця);
                    replacements.Add("номер_буд", НомерБуд);
                    replacements.Add("ПІБ", ПІП);
                    replacements.Add("ДатаТекст", dateString);
                    replacements.Add("дата_народження", dateOfBirth);
                    replacements.Add("which born", whichBorn);
                    replacements.Add("registr", registr);
                    replacements.Add("who", who);
                    

                    foreach (var replacement in replacements)
                    {
                        // Визначаємо об'єкт для пошуку
                        Find find = wordApp.Selection.Find;

                        // Налаштовуємо параметри пошуку
                        find.ClearFormatting();
                        find.Text = replacement.Key; // Текст для пошуку
                        find.Replacement.ClearFormatting();
                        find.Replacement.Text = replacement.Value; // Текст для заміни

                        // Виконуємо заміну у всьому документі
                        find.Execute(Replace: WdReplace.wdReplaceAll);
                    }

                    // Визначення шляху до тимчасової папки
                    string tempFolderPath = @"C:\Заповіти";
                    string tempFilePath = Path.Combine(tempFolderPath, ПІП + ".docx");

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }

                    // Зберігаємо зміни в тимчасовий файл
                    document.SaveAs(tempFilePath);

                    // Відкриваємо документ в Word для перегляду
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true
                    });

                    MessageBox.Show("Заповіт на " + ПІП + " збережено на диску C в папці - Заповіти");
                    Заповіт.BackColor = Color.PeachPuff;
                }
                else
                {
                    MessageBox.Show("Немає вибраної особи для формування заповіту. Спочатку виберіть особу");
                    Заповіт.BackColor = Color.PeachPuff;
                    return;
                }
            }
        }

        private void dataGridViewВікноПошуку_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewВікноПошуку.Rows[e.RowIndex].Cells[0].Value);
                
                this.Hide();
                Редагувати редагувати = new Редагувати(id, this);
                редагувати.Show();
            }
        }

        private void buttonAplyForWill_Click(object sender, EventArgs e)
        {
            buttonAplyForWill.BackColor = Color.IndianRed;

            if (dataGridViewВікноПошуку.RowCount == 0 || dataGridViewВікноПошуку.SelectedRows.Count == 0)
            {
                MessageBox.Show("Немає вибраної особи для формування заяви. Спочатку виберіть особу");
                buttonAplyForWill.BackColor = Color.PeachPuff;
                return;
            }
            else
            {
                //int index = dataGridViewВікноПошуку.SelectedRows[0].Index;
                int id = Convert.ToInt32(dataGridViewВікноПошуку.SelectedRows [0].Cells[0].Value);
                this.Close();
                WillApplicationRegistr form = new WillApplicationRegistr(id);
                form.Show();
            }
        }

        private void comboBoxСтать_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxСтать.ForeColor = Color.Black;
        }

        private void Довідка_на_субсидію_Click(object sender, EventArgs e)
        {
            Довідка_на_субсидію.BackColor = Color.IndianRed;

            if (textBoxНомерДовідки.Text == "Вкажіть номер")
            {
                MessageBox.Show("Спочатку вкажіть порядковий номер довідки !");
                Довідка_на_субсидію.BackColor = Color.PeachPuff;
                return;
            }
            else
            {

                if (dataGridViewВікноПошуку.RowCount != 0 && dataGridViewВікноПошуку.SelectedRows.Count != 0)
                {
                    int id = Convert.ToInt32(dataGridViewВікноПошуку.SelectedRows[0].Cells[0].Value);
                    string ПІП = dataGridViewВікноПошуку.SelectedRows[0].Cells[1].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[2].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[3].Value.ToString();
                    string dd_mm_yyy = dataGridViewВікноПошуку.SelectedRows[0].Cells[5].Value.ToString();
                    string date = dd_mm_yyy.Substring(0, 10) + " p.н.";
                    string Село = dataGridViewВікноПошуку.SelectedRows[0].Cells[6].Value.ToString();
                    string Вулиця = dataGridViewВікноПошуку.SelectedRows[0].Cells[7].Value.ToString();
                    string Номер = dataGridViewВікноПошуку.SelectedRows[0].Cells[8].Value.ToString();
                    string Паспорт_Full = dataGridViewВікноПошуку.SelectedRows[0].Cells[9].Value.ToString();
                    string Паспорт = Паспорт_Full.Length > 9 ? Паспорт_Full.Substring(0, 9) : Паспорт_Full;
                    string curentMonth = DateTime.Now.Month.ToString();
                    string curentDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
                    string numberOfDoc = textBoxНомерДовідки.Text.ToString();

                    AddressIds ids = new AddressIds();
                    int villagestreetId = ids.GetVillageStreetIdByPeopleId(id);

                    string select = "SELECT p.people_id, p.lastname, p.name, p.surname, p.sex, p.date_of_birth, v.name AS village, s.name AS street," +
                        " p.numb_of_house, p.passport, p.id_kod, p.phone_numb, p.status, p.registr, p.m_date, p.mil_ID" +
                        " FROM people p" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE p.villagestreetId = @villagestreetId" +
                        " AND p.numb_of_house = @numb_of_house";

                    string selectTotalArea = "SELECT totalArea FROM houses WHERE `villagestreetId` = @villagestreetId" +
                        " AND `numb_of_house` = @numb_of_house";

                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();
                    MySqlCommand comand = new MySqlCommand(select, _manager.getConnection());
                    comand.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comand.Parameters.AddWithValue("@numb_of_house", Номер);
                    MySqlDataReader _reader;
                    _reader = comand.ExecuteReader();

                    _data.Clear();

                    while (_reader.Read())
                    {
                        RowOfData row_1 = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                            _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                            _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                            _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"], _reader["mil_ID"]);
                        _data.Add(row_1);

                    }
                    _manager.closeConnection();

                    _manager.openConnection();
                    MySqlCommand comandTotalArea = new MySqlCommand(selectTotalArea, _manager.getConnection());
                    comandTotalArea.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comandTotalArea.Parameters.AddWithValue("@numb_of_house", Номер);

                    object totalObj = comandTotalArea.ExecuteScalar();
                    string totalArea = totalObj != null ? totalObj.ToString() : "—";

                    _manager.closeConnection();

                    //DocX document = DocX.Load(@"DocTemplates\ШаблонСкладСім.docx");

                    Word.Application wordApp = new Word.Application();

                    string currentDirectory = Directory.GetCurrentDirectory();

                    string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "Шаблон_довідка_на_субсидію.docx");

                    Word.Document document = wordApp.Documents.Open(temlatePath);

                    Word.Table table = document.Tables[1];
                    Word.Row templateRow = table.Rows[2];
                    int k = 0;
                    // Додаємо нові рядки
                    for (int i = 0; i < _data.Count; i++)
                    {
                        if (Convert.ToInt32(_data[i].people_id) == id)
                        { continue; }
                        Word.Row newRow = table.Rows.Add();

                        k++;
                        // Заповнюємо дані у клітинки
                        newRow.Cells[1].Range.Text = (k + 1).ToString(); // № п/п
                        newRow.Cells[2].Range.Text = _data[i].lastname.ToString().ToUpper() + " "
                            + _data[i].name.ToString().ToUpper() + " " + _data[i].surname.ToString().ToUpper();
                        newRow.Cells[3].Range.Text = "член сім'ї";
                        newRow.Cells[4].Range.Text = Convert.ToDateTime(_data[i].date_of_birth)
                                    .ToString("dd.MM.yyyy") + " р.н.";
                        newRow.Cells[5].Range.Text = _data[i].passport.ToString().Length > 9 ?
                            _data[i].passport.ToString().Substring(0, 9) : _data[i].passport.ToString();
                    }
                    // Заміна слова у всьому документі
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    string count = _data.Count.ToString();
                    string countWrite = "(одна) особа";
                    if (_data.Count == 2)
                    {
                        countWrite = "(дві) особи";
                    }
                    if (_data.Count == 3)
                    {
                        countWrite = "(три) особи";
                    }
                    if (_data.Count == 4)
                    {
                        countWrite = "(чотири) особи";
                    }
                    if (_data.Count == 5)
                    {
                        countWrite = "(п'ять) осіб";
                    }
                    if (_data.Count == 6)
                    {
                        countWrite = "(шість) осіб";
                    }
                    if (_data.Count == 7)
                    {
                        countWrite = "(сім) осіб";
                    }
                    if (_data.Count == 8)
                    {
                        countWrite = "(вісім) осіб";
                    }
                    if (_data.Count == 9)
                    {
                        countWrite = "(дев'ять) осіб";
                    }
                    if (_data.Count == 10)
                    {
                        countWrite = "(десять) осіб";
                    }
                    replacements.Add("ПІП", ПІП);
                    replacements.Add("Нас.пункт", Село);
                    replacements.Add("Вулиця", Вулиця);
                    replacements.Add("Номер", Номер);
                    replacements.Add("Дата нар.", date);
                    replacements.Add("Документ", Паспорт);
                    replacements.Add("Кількість", count);
                    replacements.Add("Кільк.Прописом", countWrite);
                    replacements.Add("Заг.Площа", totalArea);
                    replacements.Add("curentMonth", curentMonth);
                    replacements.Add("curentDate", curentDate);
                    replacements.Add("numberOfDoc", numberOfDoc);


                    foreach (var replacement in replacements)
                    {
                        // Визначаємо об'єкт для пошуку
                        Word.Find find = wordApp.ActiveDocument.Content.Find;


                        // Налаштовуємо параметри пошуку
                        find.ClearFormatting();
                        find.Text = replacement.Key; // Текст для пошуку
                        find.Replacement.ClearFormatting();
                        find.Replacement.Text = replacement.Value; // Текст для заміни

                        // Виконуємо заміну у всьому документі
                        find.Execute(Replace: WdReplace.wdReplaceAll);
                    }

                    // Визначення шляху до тимчасової папки
                    string tempFolderPath = @"C:\Довідки на субсидію";
                    string tempFilePath = Path.Combine(tempFolderPath, ПІП + ".docx");

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }

                    // Зберігаємо зміни в тимчасовий файл
                    document.SaveAs(tempFilePath);

                    // Відкриваємо документ в Word для перегляду
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true
                    });

                    document.Close(false);
                    wordApp.Quit();


                    MessageBox.Show("Довідку для " + ПІП + " збережено на диску С в папці - Довідки на субсидію");
                    Довідка_на_субсидію.BackColor = Color.PeachPuff;
                }
                else
                {
                    MessageBox.Show("Немає вибраної особи для формування довідки. Спочатку виберіть особу");
                    Довідка_на_субсидію.BackColor = Color.PeachPuff;
                    return;
                }
            }
            
        }

        private void Довідка_на_пільги_Click(object sender, EventArgs e)
        {
            Довідка_на_пільги.BackColor = Color.IndianRed;

            if (textBoxНомерДовідки.Text == "Вкажіть номер")
            {
                MessageBox.Show("Спочатку вкажіть порядковий номер довідки !");
                Довідка_на_пільги.BackColor = Color.PeachPuff;
                return;
            }
            else
            {

                if (dataGridViewВікноПошуку.RowCount != 0 && dataGridViewВікноПошуку.SelectedRows.Count != 0)
                {
                    int id = Convert.ToInt32(dataGridViewВікноПошуку.SelectedRows[0].Cells[0].Value);
                    string ПІП = dataGridViewВікноПошуку.SelectedRows[0].Cells[1].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[2].Value.ToString()
                                    + " " + dataGridViewВікноПошуку.SelectedRows[0].Cells[3].Value.ToString();
                    string dd_mm_yyy = dataGridViewВікноПошуку.SelectedRows[0].Cells[5].Value.ToString();
                    string date = dd_mm_yyy.Substring(0, 10) + " p.н.";
                    string Село = dataGridViewВікноПошуку.SelectedRows[0].Cells[6].Value.ToString();
                    string Вулиця = dataGridViewВікноПошуку.SelectedRows[0].Cells[7].Value.ToString();
                    string Номер = dataGridViewВікноПошуку.SelectedRows[0].Cells[8].Value.ToString();
                    string Паспорт_Full = dataGridViewВікноПошуку.SelectedRows[0].Cells[9].Value.ToString();
                    string Паспорт = Паспорт_Full.Length > 9 ? Паспорт_Full.Substring(0, 9) : Паспорт_Full;
                    string curentMonth = DateTime.Now.Month.ToString();
                    string curentDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
                    string numberOfDoc = textBoxНомерДовідки.Text.ToString();


                    AddressIds ids = new AddressIds();
                    int villagestreetId = ids.GetVillageStreetIdByPeopleId(id);

                    string select = "SELECT p.people_id, p.lastname, p.name, p.surname, p.sex, p.date_of_birth, v.name AS village, s.name AS street," +
                        " p.numb_of_house, p.passport, p.id_kod, p.phone_numb, p.status, p.registr, p.m_date, p.mil_ID" +
                        " FROM people p" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE p.villagestreetId = @villagestreetId" +
                        " AND p.numb_of_house = @numb_of_house";

                    string selectTotalArea = "SELECT totalArea FROM houses WHERE `villagestreetId` = @villagestreetId" +
                        " AND `numb_of_house` = @numb_of_house";

                    string selectLivingArea = "SELECT livingArea FROM houses WHERE `villagestreetId` = @villagestreetId" +
                        " AND `numb_of_house` = @numb_of_house";

                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();
                    MySqlCommand comand = new MySqlCommand(select, _manager.getConnection());
                    comand.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comand.Parameters.AddWithValue("@numb_of_house", Номер);
                    MySqlDataReader _reader;
                    _reader = comand.ExecuteReader();

                    _data.Clear();

                    while (_reader.Read())
                    {
                        RowOfData row_1 = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                            _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                            _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                            _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"], _reader["mil_ID"]);
                        _data.Add(row_1);

                    }
                    _manager.closeConnection();

                    _manager.openConnection();
                    MySqlCommand comandTotalArea = new MySqlCommand(selectTotalArea, _manager.getConnection());
                    comandTotalArea.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comandTotalArea.Parameters.AddWithValue("@numb_of_house", Номер);
                    MySqlCommand comandLivingArea = new MySqlCommand(selectLivingArea, _manager.getConnection());
                    comandLivingArea.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    comandLivingArea.Parameters.AddWithValue("@numb_of_house", Номер);


                    object totalObj = comandTotalArea.ExecuteScalar();
                    string totalArea = totalObj != null ? totalObj.ToString() : "—";

                    object livingObj = comandLivingArea.ExecuteScalar();
                    string livingArea = livingObj != null ? livingObj.ToString() : "-";

                    _manager.closeConnection();

                    //DocX document = DocX.Load(@"DocTemplates\ШаблонСкладСім.docx");

                    Word.Application wordApp = new Word.Application();

                    string currentDirectory = Directory.GetCurrentDirectory();

                    string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "Шаблон_довідка_УБД.docx");

                    Word.Document document = wordApp.Documents.Open(temlatePath);

                    Word.Table table = document.Tables[1];
                    Word.Row templateRow = table.Rows[2];
                    // Додаємо нові рядки
                    for (int i = 0; i < _data.Count; i++)
                    {
                        if (Convert.ToInt32(_data[i].people_id) == id)
                        { continue; }
                        Word.Row newRow = table.Rows.Add();

                       
                        // Заповнюємо дані у клітинки
                        
                        newRow.Cells[1].Range.Text = _data[i].lastname.ToString() + " "
                            + _data[i].name.ToString() + " " + _data[i].surname.ToString();
                        newRow.Cells[2].Range.Text = "член сім'ї";
                        newRow.Cells[3].Range.Text = Convert.ToDateTime(_data[i].date_of_birth)
                                    .ToString("dd.MM.yyyy") + " р.н.";
                        newRow.Cells[4].Range.Text = _data[i].passport.ToString().Length > 9 ?
                            _data[i].passport.ToString().Substring(0, 9) : _data[i].passport.ToString();
                    }
                    // Заміна слова у всьому документі
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    string count = _data.Count.ToString();
                    string countWrite = "(одна) особа";
                    if (_data.Count == 2)
                    {
                        countWrite = "(дві) особи";
                    }
                    if (_data.Count == 3)
                    {
                        countWrite = "(три) особи";
                    }
                    if (_data.Count == 4)
                    {
                        countWrite = "(чотири) особи";
                    }
                    if (_data.Count == 5)
                    {
                        countWrite = "(п'ять) осіб";
                    }
                    if (_data.Count == 6)
                    {
                        countWrite = "(шість) осіб";
                    }
                    if (_data.Count == 7)
                    {
                        countWrite = "(сім) осіб";
                    }
                    if (_data.Count == 8)
                    {
                        countWrite = "(вісім) осіб";
                    }
                    if (_data.Count == 9)
                    {
                        countWrite = "(дев'ять) осіб";
                    }
                    if (_data.Count == 10)
                    {
                        countWrite = "(десять) осіб";
                    }
                    replacements.Add("ПІП", ПІП);
                    replacements.Add("Village", Село);
                    replacements.Add("Street", Вулиця);
                    replacements.Add("numbOfHouse", Номер);
                    replacements.Add("dateOfBirth", date);
                    replacements.Add("passport", Паспорт);
                    replacements.Add("LivingArea", livingArea);
                    replacements.Add("CountOfPerson", countWrite);
                    replacements.Add("TotalArea", totalArea);
                    //replacements.Add("curentMonth", curentMonth);
                    replacements.Add("curentDate", curentDate);
                    replacements.Add("numberOfDoc", numberOfDoc);


                    foreach (var replacement in replacements)
                    {
                        // Визначаємо об'єкт для пошуку
                        Word.Find find = wordApp.ActiveDocument.Content.Find;


                        // Налаштовуємо параметри пошуку
                        find.ClearFormatting();
                        find.Text = replacement.Key; // Текст для пошуку
                        find.Replacement.ClearFormatting();
                        find.Replacement.Text = replacement.Value; // Текст для заміни

                        // Виконуємо заміну у всьому документі
                        find.Execute(Replace: WdReplace.wdReplaceAll);
                    }

                    // Визначення шляху до тимчасової папки
                    string tempFolderPath = @"C:\Довідки на пільги";
                    string tempFilePath = Path.Combine(tempFolderPath, ПІП + ".docx");

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }

                    // Зберігаємо зміни в тимчасовий файл
                    document.SaveAs(tempFilePath);

                    // Відкриваємо документ в Word для перегляду
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true
                    });

                    document.Close(false);
                    wordApp.Quit();


                    MessageBox.Show("Довідку для " + ПІП + " збережено на диску С в папці - Довідки на пільги");
                    Довідка_на_пільги.BackColor = Color.PeachPuff;
                }
                else
                {
                    MessageBox.Show("Немає вибраної особи для формування довідки. Спочатку виберіть особу");
                    Довідка_на_пільги.BackColor = Color.PeachPuff;
                    return;
                }
            }

        }
    }
}
