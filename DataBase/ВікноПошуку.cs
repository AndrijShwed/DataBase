using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ВікноПошуку : Form
    {
        private List<RowOfData> _data = new List<RowOfData>();
        VillageStreet villageStreet = new VillageStreet();
       // private User user;

        public ВікноПошуку()
        {
            InitializeComponent();
            HeaderOfTheTable();

            button1Пошук.Text = "Пошук  \U0001F504";
                 
            textBoxПрізвище.Text = "Прізвище";
            textBoxПрізвище.ForeColor = Color.Gray;

            textBoxІм_я.Text = "Ім'я";
            textBoxІм_я.ForeColor = Color.Gray;

            textBoxПобатькові.Text = "Побатькові";
            textBoxПобатькові.ForeColor = Color.Gray;

            textBoxСтать.Text = "Стать";
            textBoxСтать.ForeColor = Color.Gray;

            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxVillage.Text = "Виберіть населений пункт";

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

            textBoxНомерЗаповіту.Text = "Номер";
            textBoxНомерЗаповіту.ForeColor= Color.Gray;

            textBoxCount.Text = "0";

            РеєстраціяТак.CheckState = CheckState.Checked;
            РеєстраціяТак.BackColor = Color.AliceBlue;

            РеєстраціяНі.CheckState = CheckState.Unchecked;
            РеєстраціяНі.BackColor = Color.AliceBlue;

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
            column9.HeaderText = "Номер будинку";
            column9.Width = 80;
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
            column14.HeaderText = "Рестрація";
            column14.Width = 90;
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
            column16.HeaderText = "Видалити";
            column16.Width = 100;
            column16.Name = "Видалити";
            column16.Frozen = true;
             column16.CellTemplate = new DataGridViewTextBoxCell();

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

        private void textBoxСтать_Enter(object sender, EventArgs e)
        {
            if (textBoxСтать.Text == "Стать")
            {
                textBoxСтать.Text = "";
                textBoxСтать.ForeColor = Color.Black;
            }
        }

        private void textBoxСтать_Leave(object sender, EventArgs e)
        {
            if (textBoxСтать.Text == "")
            {
                textBoxСтать.Text = "Стать";
                textBoxСтать.ForeColor = Color.Gray;
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

        private void textBoxНомерЗаповіту_Enter(object sender, EventArgs e)
        {

            if (textBoxНомерЗаповіту.Text == "Номер")
            {
                textBoxНомерЗаповіту.Text = "";
                textBoxНомерЗаповіту.ForeColor = Color.Black;
            }
        }

        private void textBoxНомерЗаповіту_Leave(object sender, EventArgs e)
        {
            if (textBoxНомерЗаповіту.Text == "")
            {
                textBoxНомерЗаповіту.Text = "Вкажіть номер";
                textBoxНомерЗаповіту.ForeColor = Color.Gray;
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

            textBoxСтать.Text = "Стать";
            textBoxСтать.ForeColor = Color.Gray;

            comboBoxVillage.Text = "Виберіть населений пункт";

            textBoxВікВІД.Text = "Вік від:";
            textBoxВікВІД.ForeColor = Color.Gray;

            textBoxВікДО.Text = "Вік до:";
            textBoxВікДО.ForeColor = Color.Gray;

            comboBoxStreets.Text = "";
            comboBoxStreets.Items.Clear();

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
                row.id_kod, row.phone_numb, row.status, row.registr, row.M_Year);
        }

        private void button1Пошук_Click(object sender, EventArgs e)
        {
            dataGridViewВікноПошуку.DataSource = null;
            dataGridViewВікноПошуку.Rows.Clear();

            _data.Clear();

            bool mess = false;
            
            if (textBoxПрізвище.Text == "Прізвище" && textBoxІм_я.Text == "Ім'я" &&
                   textBoxПобатькові.Text == "Побатькові" && comboBoxVillage.Text == "Виберіть населений пункт" &&
                   comboBoxStreets.Text == "" && textBoxСтать.Text == "Стать" &&
                   textBoxВікВІД.Text == "Вік від:" &&
                   textBoxВікДО.Text == "Вік до:" &&
                   textBoxНомерБудинку.Text == "Номер будинку" &&
                   textBoxСтатус.Text == "Статус" &&
                   textBoxM_Year.Text == "Рік зміни статусу")
            {
                MessageBox.Show("Жодне поле пошуку не заповнено !");
                return;
            }

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            SQLCommand c = new SQLCommand();
           
            string lastname = Convert.ToString(textBoxПрізвище.Text).ToLower().Replace("'", "`").Replace('"', '`').Replace(" ", "");
            string name = Convert.ToString(textBoxІм_я.Text).ToLower().Replace("'", "`").Replace('"', '`').Replace(" ", "");
            string surname = Convert.ToString(textBoxПобатькові.Text).ToLower().Replace("'", "`").Replace('"', '`').Replace(" ", "");
            string sex = Convert.ToString(textBoxСтать.Text).ToLower().Replace(" ", "");
            string village = Convert.ToString(comboBoxVillage.Text).ToLower();
            string street = Convert.ToString(comboBoxStreets.Text).ToLower();
            string numb_of_house = Convert.ToString(textBoxНомерБудинку.Text).Replace(" ", "");
            string status = Convert.ToString(textBoxСтатус.Text).ToLower();
           
            string registr = "так";

            if (РеєстраціяТак.CheckState == CheckState.Unchecked)
            {
                 registr = "ні";
            }

            bool first = true;
            c.com = "SELECT * FROM people ";

            if(РеєстраціяТак.CheckState == CheckState.Unchecked)
            {
                РеєстраціяНі.Checked = true;
            }

            if (РеєстраціяНі.CheckState == CheckState.Checked && РеєстраціяТак.CheckState == CheckState.Checked)
            {
            }
            else
            {
                if (first)
                {
                    c.com = c.com + "WHERE LOWER(registr) LIKE '%" + registr + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + "AND LOWER(registr) LIKE '%" + registr + "%'";
                }
            }

            if (textBoxСтатус.Text != "Статус")
            {
                if (first)
                {
                    c.com = c.com + "WHERE LOWER(status) LIKE '%" + status + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(status) LIKE '%" + status + "%'";
                }

            }
            if(textBoxM_Year.Text != "Рік зміни статусу")
            {
                int year = Convert.ToInt32(textBoxM_Year.Text);
                if (first)
                {
                    c.com = c.com + "WHERE year(m_date) = '" + year + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(m_date) LIKE '" + year + "%'";
                }

            }
            if (textBoxПрізвище.Text != "Прізвище")
            {
               
                if(first)
                {
                    c.com = c.com + "WHERE LOWER(lastname) LIKE '" + lastname + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(lastname) LIKE '" + lastname + "%'";
                }

            }
            if (textBoxІм_я.Text != "Ім'я")
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
            if (textBoxПобатькові.Text != "Побатькові")
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
            if (comboBoxVillage.Text != "Виберіть населений пункт")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(village) LIKE '" + village + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(village) LIKE '" + village + "%'";
                }
            }
            if (textBoxСтать.Text != "Стать")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(sex) LIKE '" + sex + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(sex) LIKE '" + sex + "%'";
                }
            }
            if (comboBoxStreets.Text != "Виберіть вулицю" && comboBoxStreets.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(street) LIKE '" + street + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(street) LIKE '" + street + "%'";
                }
            }
            if (textBoxНомерБудинку.Text != "Номер будинку")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(numb_of_house) = '" + numb_of_house + "'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(numb_of_house) = '" + numb_of_house + "'";
                }
            }
            if (textBoxСтатус.Text != "Статус" && (textBoxВікВІД.Text != "Вік від:" || textBoxВікДО.Text != "Вік до:" ||
                comboBoxVillage.Text != "Виберіть населений пункт" || textBoxНомерБудинку.Text != "Номер будинку" ||
                comboBoxStreets.Text != "Вулиця" || textBoxСтать.Text != "Стать" || comboBoxVillage.Text != "Виберіть населений пункт" ||
                textBoxПобатькові.Text != "Побатькові" || textBoxІм_я.Text != "Ім'я" || textBoxПрізвище.Text != "Прізвище"))
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(status) LIKE '%" + status + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(status) LIKE '%" + status + "%'";
                }
            }
            if (textBoxВікВІД.Text != "Вік від:" || textBoxВікДО.Text != "Вік до:")
            {

                DateTime today = DateTime.Today;

                int minAge = 0;
                if (textBoxВікВІД.Text != "Вік від:" && !string.IsNullOrWhiteSpace(textBoxВікВІД.Text))
                {
                    if (!int.TryParse(textBoxВікВІД.Text, out minAge))
                    {
                        MessageBox.Show("Неправильний вік у полі 'Вік від'");
                        return;
                    }
                }

                int maxAge = 150;
                if (textBoxВікДО.Text != "Вік до:" && !string.IsNullOrWhiteSpace(textBoxВікДО.Text))
                {
                    if (!int.TryParse(textBoxВікДО.Text, out maxAge))
                    {
                        MessageBox.Show("Неправильний вік у полі 'Вік до'");
                        return;
                    }
                }

                DateTime latestBirthDate = today.AddYears(-minAge); // Наймолодший
                DateTime earliestBirthDate = today.AddYears(-maxAge); // Найстарший

                string date_start = earliestBirthDate.ToString("yyyy-MM-dd");
                string date_end = latestBirthDate.ToString("yyyy-MM-dd");

                if (first)
                {
                    c.com += $" WHERE date_of_birth BETWEEN '{date_start}' AND '{date_end}'";
                }
                else
                {
                    c.com += $" AND date_of_birth BETWEEN '{date_start}' AND '{date_end}'";
                }


            }

            try
            {
                _manager.openConnection();

                MySqlCommand _command = new MySqlCommand(c.com,_manager.getConnection());
                _reader = _command.ExecuteReader();


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
                    if (_data[i].status != null && Regex.IsMatch(_data[i].status.ToString(), @"\bпомер\b", RegexOptions.IgnoreCase) == true)
                    {
                        dataGridViewВікноПошуку.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                        dataGridViewВікноПошуку.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    dataGridViewВікноПошуку.Rows[i].Cells[15].Value = "Видалити";
                    dataGridViewВікноПошуку.Rows[i].Cells[15].Style.BackColor = Color.DarkRed;
                    dataGridViewВікноПошуку.Rows[i].Cells[15].Style.ForeColor = Color.White;
                    dataGridViewВікноПошуку.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            textBoxCount.Text = Convert.ToString(_data.Count);
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
                    

                    for (int i = 2; i < dataGridViewВікноПошуку.RowCount + 2; i++)
                    {
                        worksheet.Rows[i].Columns[1] = i - 1;
                        for (int j = 2; j < dataGridViewВікноПошуку.ColumnCount + 1; j++)
                        {
                            if (j != 5 /*&& j != 10 && j != 11 */&& j != 12 && j != 13 && j != 14 && j != 15 && j != 16)
                           
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


        private void dataGridViewВікноПошуку_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //user = new User();

            //if (user.userName == "A")
            //{

                if (e.ColumnIndex == 15)
                {
                    DataGridViewRow row = dataGridViewВікноПошуку.Rows[e.RowIndex];


                    if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["people_id"].Value), "Погоджуюсь",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
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

                    string select = "SELECT * FROM people WHERE `village` = '" + Село + "'" +
                        " AND `street` = '" + Вулиця + "' AND `numb_of_house` = '" + Номер + "'" +
                        "AND people_id <> '" + id + "' AND registr = 'так'";

                    string selectTotalArea = "SELECT totalArea FROM houses WHERE `village` = '" + Село + "'" +
                        " AND `street` = '" + Вулиця + "' AND `numb_of_house` = '" + Номер + "'";

                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();
                    MySqlCommand comand = new MySqlCommand(select, _manager.getConnection());
                    MySqlDataReader _reader;
                    _reader = comand.ExecuteReader();

                    _data.Clear();

                    while (_reader.Read())
                    {
                        RowOfData row_1 = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                            _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                            _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                            _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"]);
                        _data.Add(row_1);

                    }
                    _manager.closeConnection();

                    _manager.openConnection();
                    MySqlCommand comandTotalArea = new MySqlCommand(selectTotalArea, _manager.getConnection());
                    string totalArea = comandTotalArea.ExecuteScalar().ToString();
                    _manager.closeConnection();
                    
                    //DocX document = DocX.Load(@"DocTemplates\ШаблонСкладСім.docx");

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
                        
                    string str = "";
                    string str_1 = "";
                    string date_1;
                    string date_2;

                    int k = 0;
                    if (_data.Count > 5)
                    {
                        k = _data.Count - 5;

                        for (int i = 0; i <= _data.Count - k; i++)
                        {
                            date_1 = _data[i].date_of_birth.ToString().Substring(0, 10);
                            str += (i + 1) + ". " + _data[i].lastname + " " + _data[i].name + " " + _data[i].surname + ", " + date_1 + " р.н.\r";
                        }
                        for (int i = 6; i < _data.Count; i++)
                        {
                            date_2 = _data[i].date_of_birth.ToString().Substring(0, 10);
                            str_1 += (i + 1) + ". " + _data[i].lastname + " " + _data[i].name + " " + _data[i].surname + ", " + date_2 + " р.н.\r";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _data.Count; i++)
                        {
                            date_1 = _data[i].date_of_birth.ToString().Substring(0, 10);
                            str += (i + 1) + ". " + _data[i].lastname + " " + _data[i].name + " " + _data[i].surname + ", " + date_1 + " р.н.\r";
                        }
                    }
                    replacements.Add("список_", str);
                    replacements.Add("продовження", str_1);
                    replacements.Add("ЗагальнаПлоща", totalArea);

                    foreach (var replacement in replacements)
                    {
                       // document.ReplaceText(replacement.Key, replacement.Value, false);

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

                    string select = "SELECT * FROM people WHERE `people_id` = '" + id + "'";

                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();
                    MySqlCommand comand = new MySqlCommand(select, _manager.getConnection());
                    MySqlDataReader _reader;
                    _reader = comand.ExecuteReader();

                    _data.Clear();

                    while (_reader.Read())
                    {
                        RowOfData row_1 = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                            _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                            _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                            _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"]);
                        _data.Add(row_1);

                    }
                    _manager.closeConnection();

                    //DocX document = DocX.Load(@"DocTemplates\ШаблонХарактеристика.docx");

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
                       // document.ReplaceText(replacement.Key, replacement.Value, false);

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

            if (textBoxНомерЗаповіту.Text == "Номер")
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
                    string nunbOfWill = textBoxНомерЗаповіту.Text;
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
                        // document.ReplaceText(replacement.Key, replacement.Value, false);

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

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            villageStreet.comboBoxStreetChoose(comboBoxVillage, comboBoxStreets);
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
    }
}
