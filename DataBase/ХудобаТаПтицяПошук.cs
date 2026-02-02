using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ХудобаТаПтицяПошук : Form
    {
        private List<RowOfDataAnymals> _data = new List<RowOfDataAnymals>();
        VillageStreet villageStreet = new VillageStreet();
       // private User user;

        public ХудобаТаПтицяПошук()
        {
            InitializeComponent();
            HeaderOfTheTable();


            textBoxПрізвище.Text = "Прізвище";
            textBoxПрізвище.ForeColor = Color.Gray;

            textBoxІм_я.Text = "Ім'я";
            textBoxІм_я.ForeColor = Color.Gray;

            textBoxПобатькові.Text = "Побатькові";
            textBoxПобатькові.ForeColor = Color.Gray;

            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxVillage.Text = "Виберіть населений пункт";

            textBoxCount.Text = "0";

        }

        private void HeaderOfTheTable()
        {
            this.dataGridViewВікноПошуку.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewВікноПошуку.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewВікноПошуку.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewВікноПошуку.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewВікноПошуку.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            this.dataGridViewВікноПошуку.EnableHeadersVisualStyles = false;


            var column0 = new DataGridViewColumn();
            column0.HeaderText = "Номер";
            column0.Width = 55;
            column0.Name = "anymalsid";
            column0.Frozen = true;
            column0.CellTemplate = new DataGridViewTextBoxCell();

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
            column4.Width = 110;
            column4.Name = "surname";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Населений пункт";
            column5.Width = 110;
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
            column12.Width =98;
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
            column14.Name = "bees";
            column14.Frozen = true;
            column14.CellTemplate = new DataGridViewTextBoxCell();

            var column15 = new DataGridViewColumn();
            column15.HeaderText = "Видалити";
            column15.Width = 98;
            column15.Name = "Видалити";
            column15.Frozen = true;
            column15.CellTemplate = new DataGridViewTextBoxCell();



            dataGridViewВікноПошуку.Columns.Add(column0);
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
            


            dataGridViewВікноПошуку.AllowUserToAddRows = false;
            dataGridViewВікноПошуку.ReadOnly = true;
        }

        private void ВікноПошуку_Shown(object sender, EventArgs e)
        {
            HeaderOfTheTable();
           //user = new User();
        }
        private void textBoxПрізвище_Enter(object sender, EventArgs e)
        {
            if (textBoxПрізвище.Text == "Прізвище")
            {
                textBoxПрізвище.Text = "";
                textBoxПрізвище.ForeColor = Color.Black;
            }
        }
        private void textBoxПрізвище_Leave1(object sender, EventArgs e)
        {
            if (textBoxПрізвище.Text == "")
            {
                textBoxПрізвище.Text = "Прізвище";
                textBoxПрізвище.ForeColor = Color.Gray;
            }
        }
       
        private void textBoxІм_я_Enter1(object sender, EventArgs e)
        {
            if (textBoxІм_я.Text == "Ім'я")
            {
                textBoxІм_я.Text = "";
                textBoxІм_я.ForeColor = Color.Black;
            }
        }

        private void textBoxІм_я_Leave1(object sender, EventArgs e)
        {
            if (textBoxІм_я.Text == "")
            {
                textBoxІм_я.Text = "Ім'я";
                textBoxІм_я.ForeColor = Color.Gray;
            }
        }

        private void textBoxПобатькові_Enter1(object sender, EventArgs e)
        {
            if (textBoxПобатькові.Text == "Побатькові")
            {
                textBoxПобатькові.Text = "";
                textBoxПобатькові.ForeColor = Color.Black;
            }
        }

        private void textBoxПобатькові_Leave1(object sender, EventArgs e)
        {
            if (textBoxПобатькові.Text == "")
            {
                textBoxПобатькові.Text = "Побатькові";
                textBoxПобатькові.ForeColor = Color.Gray;
            }
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ХудобаТаПтиця form = new ХудобаТаПтиця();
            Program.OpenForm(this, form);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void buttonОчиститиПоля_Click(object sender, EventArgs e)
        {
            textBoxПрізвище.Text = "Прізвище";
            textBoxПрізвище.ForeColor = Color.Gray;

            textBoxІм_я.Text = "Ім'я";
            textBoxІм_я.ForeColor = Color.Gray;

            textBoxПобатькові.Text = "Побатькові";
            textBoxПобатькові.ForeColor = Color.Gray;

            comboBoxVillage.Text = "Виберіть населений пункт";
        }

        private void AddDataGrid(RowOfDataAnymals row)
        {
            dataGridViewВікноПошуку.Rows.Add(row.anymalsId, row.lastname, row.name, row.surname, row.village,
                row.anymals, row.covs, row.pigs, row.sheeps,
                row.goats, row.horses, row.birds, row.rabbits, row.beeses);
        }

        private void button1Пошук_Click(object sender, EventArgs e)
        {
            dataGridViewВікноПошуку.DataSource = null;
            dataGridViewВікноПошуку.Rows.Clear();

            _data.Clear();

            bool mess = false;

            if (textBoxПрізвище.Text == "Прізвище" && textBoxІм_я.Text == "Ім'я" &&
                  textBoxПобатькові.Text == "Побатькові" && comboBoxVillage.Text == "Виберіть населений пункт" &&
                  !checkBoxBee.Checked && !checkBoxBirds.Checked && !checkBoxCov.Checked && !checkBoxGoat.Checked && !checkBoxHorse.Checked
                  && !checkBoxPig.Checked && !checkBoxRabbit.Checked && !checkBoxSheep.Checked)
            {
                MessageBox.Show("Жодне поле пошуку не заповнено і не позначено !");
                return;
            }

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            SQLCommand c = new SQLCommand();

            string lastname = Convert.ToString(textBoxПрізвище.Text).ToLower().Replace("'", "`").Replace('"', '`');
            string name = Convert.ToString(textBoxІм_я.Text).ToLower().Replace("'", "`").Replace('"', '`');
            string surname = Convert.ToString(textBoxПобатькові.Text).ToLower().Replace("'", "`").Replace('"', '`');
            string village = Convert.ToString(comboBoxVillage.Text).ToLower();

            c.com = "SELECT * FROM anymals WHERE 1 = 1";

            if (textBoxПрізвище.Text != "Прізвище")
            {
                 c.com = c.com + " AND LOWER(lastname) LIKE '" + lastname + "%'";
            }
            if (textBoxІм_я.Text != "Ім'я")
            {
                 c.com = c.com + " AND LOWER(name) LIKE '" + name + "%'";
            }
            if (textBoxПобатькові.Text != "Побатькові")
            {
                 c.com = c.com + " AND LOWER(surname) LIKE '" + surname + "%'";
            }
            if (comboBoxVillage.Text != "Виберіть населений пункт")
            {
                 c.com = c.com + " AND LOWER(village) LIKE '" + village + "%'";
            }
            if (checkBoxBee.Checked)
            {
                 c.com = c.com + " AND beeses <> 0";
            }
            if (checkBoxRabbit.Checked)
            {
                 c.com = c.com + " AND rabbits <> 0";
            }
            if (checkBoxBirds.Checked)
            {
                 c.com = c.com + " AND birds <> 0";
            }
            if (checkBoxHorse.Checked)
            {
                 c.com = c.com + " AND horses <> 0";
            }
            if (checkBoxGoat.Checked)
            {
                 c.com = c.com + " AND goats <> 0";
            }
            if (checkBoxSheep.Checked)
            {
                 c.com = c.com + " AND sheeps <> 0";
            }
            if (checkBoxPig.Checked)
            {
                 c.com = c.com + " AND pigs <> 0";
            }
            if (checkBoxCov.Checked)
            {
                 c.com = c.com + " AND covs <> 0";
            }
            try 
            {
                _manager.openConnection();

                MySqlCommand _command = new MySqlCommand(c.com, _manager.getConnection());
                _reader = _command.ExecuteReader();


                while (_reader.Read())
                {
                    RowOfDataAnymals row = new RowOfDataAnymals(_reader["anymalsId"], _reader["lastname"], _reader["name"],
                        _reader["surname"],  _reader["village"], _reader["anymals"], _reader["covs"],
                        _reader["pigs"], _reader["sheeps"], _reader["goats"], _reader["horses"],
                        _reader["birds"], _reader["rabbits"], _reader["beeses"]);
                    _data.Add(row);

                }
                for (int i = 0; i < _data.Count; i++)
                {

                    AddDataGrid(_data[i]);
                    dataGridViewВікноПошуку.Rows[i].Cells[14].Value = "Видалити";
                    dataGridViewВікноПошуку.Rows[i].Cells[14].Style.BackColor = Color.DarkRed;
                    dataGridViewВікноПошуку.Rows[i].Cells[14].Style.ForeColor = Color.White;
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

        private void Редагувати_Click(object sender, EventArgs e)
        {
            dataGridViewВікноПошуку.ReadOnly = false;
            dataGridViewВікноПошуку.Columns[0].ReadOnly = true;
        }

        private void dataGridViewВікноПошуку_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //user = new User();

           //if (user.userName == "A")
            //{

                if (e.ColumnIndex == 14)
                {
                    DataGridViewRow row = dataGridViewВікноПошуку.Rows[e.RowIndex];


                    if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["anymalsId"].Value), "Погоджуюсь",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ConnectionClass _manager = new ConnectionClass();
                        _manager.openConnection();

                        string com = "DELETE FROM anymals WHERE anymalsId = '" + row.Cells["anymalsId"].Value + "'";

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

        private void Зберегти_зміни_Click(object sender, EventArgs e)
        {
           // user = new User();

           // if (user.userName == "A")
            //{

                if (dataGridViewВікноПошуку.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Не вибрано рядки для збереження внесених змін. Виберіть рядки !");

                }
                else
                {
                    ConnectionClass _manager = new ConnectionClass();

                    bool changed = true;

                    for (int i = 0; i < dataGridViewВікноПошуку.SelectedRows.Count; i++)
                    {

                        if (Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[1].Value) != "" &&
                            Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[2].Value) != "" &&
                            Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[3].Value) != "" &&
                            Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[4].Value) != "")

                        {
                            string anymalsId = Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[0].Value);
                            string lastname = Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[1].Value).Replace("'", "`").Replace('"', '`');
                            string name = Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[2].Value).Replace("'", "`").Replace('"', '`');
                            string surname = Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[3].Value).Replace("'", "`").Replace('"', '`');
                            string village = Convert.ToString(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[4].Value);
                            int anymals = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[5].Value);
                            int covs = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[6].Value);
                            int pigs = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[7].Value);
                            int sheeps = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[8].Value);
                            int goats = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[9].Value);
                            int horses = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[10].Value);
                            int birds = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[11].Value);
                            int rabbits = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[12].Value);
                            int beeses = Convert.ToInt32(this.dataGridViewВікноПошуку.SelectedRows[i].Cells[13].Value);
                            
                            string _commandString = "UPDATE anymals SET lastname = '" + lastname + "', " +
                           "name = @name, " +
                           "surname = @surname, " +
                           "anymals = @anymals, " +
                           "covs = @covs, " +
                           "village = @village, " +
                           "pigs = @pigs, " +
                           "sheeps = @sheeps, " +
                           "goats = @goats, " +
                           "horses = @horses, " +
                           "birds = @birds, " +
                           "rabbits = @rabbits, " +
                           "beeses = @beeses " +
                           "WHERE anymalsId = @anymalsId";

                            MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());
                            _command.Parameters.AddWithValue("@name", name);
                            _command.Parameters.AddWithValue("@surname", surname);
                            _command.Parameters.AddWithValue("@anymals", anymals);
                            _command.Parameters.AddWithValue("@covs", covs);
                            _command.Parameters.AddWithValue("@village", village);
                            _command.Parameters.AddWithValue("@pigs", pigs);
                            _command.Parameters.AddWithValue("@sheeps", sheeps);
                            _command.Parameters.AddWithValue("@goats", goats);
                            _command.Parameters.AddWithValue("@horses", horses);
                            _command.Parameters.AddWithValue("@birds", birds);
                            _command.Parameters.AddWithValue("@rabbits", rabbits);
                            _command.Parameters.AddWithValue("@beeses", beeses);
                            _command.Parameters.AddWithValue("@anymalsId", anymalsId);

                            try
                            {
                                _manager.openConnection();
                                _command.ExecuteNonQuery();

                                dataGridViewВікноПошуку.ReadOnly = true;

                                if (_command.ExecuteNonQuery() != 1)
                                    changed = false;
                            }
                            catch
                            {
                                MessageBox.Show("Помилка роботи з базою даних !!");
                            }

                        }
                        else
                            MessageBox.Show("Не всі поля заповнені !");
                    }
                    if (changed)
                        MessageBox.Show("Дані змінено !");
                    else
                        MessageBox.Show("Не всі дані змінено !");

                    dataGridViewВікноПошуку.ReadOnly = true;
                    _manager.closeConnection();
                }
            //}
            //else
            //    MessageBox.Show("У вас немає доступу до зміни даних в таблиці !");
        }

        private void buttonExportInExcel_Click(object sender, EventArgs e)
        {
            if (textBoxFileName.Text != "")
            {
                string fileName = Convert.ToString(textBoxFileName.Text);
               
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
                worksheet.Rows[1].Columns[5] = "Населений пункт";
                worksheet.Rows[1].Columns[6] = "ВРХ";
                worksheet.Rows[1].Columns[7] = "Корови";
                worksheet.Rows[1].Columns[8] = "Свині";
                worksheet.Rows[1].Columns[9] = "Вівці";
                worksheet.Rows[1].Columns[10] = "Кози";
                worksheet.Rows[1].Columns[11] = "Коні";
                worksheet.Rows[1].Columns[12] = "Птиця";
                worksheet.Rows[1].Columns[13] = "Кролі";
                worksheet.Rows[1].Columns[14] = "Бджолосім'ї";


                for (int i = 2; i < dataGridViewВікноПошуку.RowCount + 2; i++)
                {
                    worksheet.Rows[i].Columns[1] = i - 1;
                    for (int j = 2; j < dataGridViewВікноПошуку.ColumnCount + 1; j++)
                    {
                        if (j != 15)

                            worksheet.Rows[i].Columns[j] = dataGridViewВікноПошуку.Rows[i - 2].Cells[j - 1].Value;
                    }

                }
                Excel.Range usedRange = worksheet.UsedRange;
                Excel.Range row = worksheet.Rows[1];
                row.Font.Size = 16;
                row.Font.Bold = true;
                // Автоматично змінюємо ширину стовпців для відповідності вмісту
                usedRange.Columns.AutoFit();
                exApp.AlertBeforeOverwriting = false;
                worksheet.SaveAs(path);
                exApp.Quit();
                

                MessageBox.Show("Файл збережено на диск C в папку База Даних");
            }
            else
                MessageBox.Show("Спочатку введіть назву файлу !!!");
        }
    }
   
   
}
