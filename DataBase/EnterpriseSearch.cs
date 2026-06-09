using DataBase.Services;
using DocumentFormat.OpenXml.Wordprocessing;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class EnterpriseSearch : Form
    {
        private List<Enterprise> _data = new List<Enterprise>();
        AddressService service = new AddressService();
        // private User user;

        public EnterpriseSearch()
        {
            InitializeComponent();
            HeaderOfTheTable();
            SetupPlaceholders();
            service.LoadVillages(comboBoxVillage);

            Search.Text = "Пошук  \U0001F504";

            textBoxCount.Text = "0";

            textBoxHead.TextChanged += CapitalizeFirst;
        }

        private void SetupPlaceholders()
        {
            InitPlaceholder(textBoxName, "Назва п-ства");
            InitPlaceholder(textBoxHead, "ПІБ власника");
            InitPlaceholder(textBoxHouseNumber, "Номер будинку");
        }

        private void InitPlaceholder(TextBox tb, string placeholder)
        {
            tb.Tag = placeholder;
            tb.Text = placeholder;
            tb.ForeColor = System.Drawing.Color.Gray;

            tb.Enter += TextBox_Enter;
            tb.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.Text == tb.Tag.ToString())
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = System.Drawing.Color.Gray;
            }
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
            this.dataGridViewSearchWindow.DefaultCellStyle.Font = new System.Drawing.Font("TimeNewRoman", 10);
            this.dataGridViewSearchWindow.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            this.dataGridViewSearchWindow.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewSearchWindow.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSearchWindow.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkOrange;
            this.dataGridViewSearchWindow.EnableHeadersVisualStyles = false;


            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 60;
            column1.Name = "id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "ПІБ власника";
            column2.Width = 325;
            column2.Name = "Owner";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Назва п-ства";
            column3.Width = 350;
            column3.Name = "name";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Нас. пункт";
            column4.Width = 220;
            column4.Name = "settlement";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Вулиця";
            column5.Width = 220;
            column5.Name = "street";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Номер буд.";
            column6.Width = 100;
            column6.Name = "houseNumber";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "К-сть працівників";
            column7.Width = 90;
            column7.Name = "employeesCount";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Видалити";
            column8.Width = 80;
            column8.Name = "Видалити";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            dataGridViewSearchWindow.Columns.Add(column1);
            dataGridViewSearchWindow.Columns.Add(column2);
            dataGridViewSearchWindow.Columns.Add(column3);
            dataGridViewSearchWindow.Columns.Add(column4);
            dataGridViewSearchWindow.Columns.Add(column5);
            dataGridViewSearchWindow.Columns.Add(column6);
            dataGridViewSearchWindow.Columns.Add(column7);
            dataGridViewSearchWindow.Columns.Add(column8);

            dataGridViewSearchWindow.AllowUserToAddRows = false;
            dataGridViewSearchWindow.ReadOnly = true;
        }

        //велика літера на початку
        private void CapitalizeFirst(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.TextLength == 0) return;

            string text = tb.Text;
            if (char.IsLower(text[0]))
            {
                int pos = tb.SelectionStart;
                tb.Text = char.ToUpper(text[0]) + text.Substring(1);
                tb.SelectionStart = pos;
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            comboBoxVillage.SelectedIndex = -1;
            comboBoxStreets.SelectedIndex = -1;
            SetupPlaceholders();
        }
        private void AddDataGrid(Enterprise row)
        {
            dataGridViewSearchWindow.Rows.Add(row.id, row.owner, row.name, row.village, row.street,
                                             row.houseNumber, row.employeesNumber);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            // Очистка DataGridView
            dataGridViewSearchWindow.DataSource = null;
            dataGridViewSearchWindow.Rows.Clear();
            _data.Clear();

            // Перевірка, що хоча б одне поле заповнене
            //if (textBoxName.Text == "Назва п-ства" &&
            //    textBoxHead.Text == "ПІБ власника" &&
            //    textBoxHouseNumber.Text == "Номер будинку" &&
            //    comboBoxVillage.SelectedIndex < 0 &&
            //    comboBoxStreets.SelectedIndex < 0)
               
            //{
            //    MessageBox.Show("Жодне поле пошуку не заповнено !");
            //    return;
            //}

            // Підготовка параметрів пошуку
            string head = textBoxHead.Text.ToLower().Replace("'", "`").Trim();
            string name = textBoxName.Text.ToLower().Replace("'", "`").Trim();
            string numb_of_house = textBoxHouseNumber.Text.ToLower().Trim();

            // Побудова SQL з WHERE 1=1
            string sql = "SELECT e.id, e.name, e.owner, e.employeesnumber, e.housenumber, " +
                        "v.name AS village, s.name AS street" +
                        " FROM enterprises e" +
                        " JOIN villagestreet vs ON e.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE 1 = 1 ";

            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(head) && textBoxHead.Text != "ПІБ власника")
            {
                sql += " AND LOWER(e.owner) LIKE @owner";
                parameters.Add(new MySqlParameter("@owner", head + "%"));
            }
            if (!string.IsNullOrWhiteSpace(name) && textBoxName.Text != "Назва п-ства")
            {
                sql += " AND LOWER(e.name) LIKE @name";
                parameters.Add(new MySqlParameter("@name", name + "%"));
            }
            if (comboBoxVillage.SelectedIndex >= 0)
            {
                var village = comboBoxVillage.SelectedItem as Village;
                if (village == null)
                {
                    MessageBox.Show("Оберіть населений пункт !");
                    return;
                }
                int villageId = village.Id;

                sql += " AND v.id = @villageId";
                parameters.Add(new MySqlParameter("@villageId", villageId));
            }
            if (comboBoxStreets.SelectedIndex >= 0)
            {
                var street = comboBoxStreets.SelectedItem as Street;
                if (street == null)
                {
                    MessageBox.Show("Вкажіть вулицю !");
                    return;
                }
                int streetId = street.Id;
                sql += " AND s.id = @streetId";
                parameters.Add(new MySqlParameter("@streetId", streetId));
            }
            if (!string.IsNullOrWhiteSpace(numb_of_house) && textBoxHouseNumber.Text != "Номер будинку")
            {
                sql += " AND LOWER(e.housenumber) = @house";
                parameters.Add(new MySqlParameter("@house", numb_of_house));
            }

            // Виконання запиту
            ConnectionClass _manager = new ConnectionClass();
            try
            {
                sql += " ORDER BY v.name, s.name, e.owner";
                _manager.openConnection();
                MySqlCommand cmd = new MySqlCommand(sql, _manager.getConnection());
                cmd.Parameters.AddRange(parameters.ToArray());

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enterprise row = Enterprise.ReadOne(reader);
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
                var gridRow = dataGridViewSearchWindow.Rows[dataGridViewSearchWindow.Rows.Count - 1];

                // Кнопка видалення
                gridRow.Cells[7].Value = "🗑️";
                gridRow.Cells[7].Style.BackColor = System.Drawing.Color.DarkRed;
                gridRow.Cells[7].Style.ForeColor = System.Drawing.Color.White;

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
            dataGridViewSearchWindow.Rows.Clear();
            textBoxCount.Text = "0";
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

        private void dataGridViewSearchWindow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DataGridViewRow row = dataGridViewSearchWindow.Rows[e.RowIndex];


                if (MessageBox.Show($"Ви дійсно бажаєте видалити цей рядок ? ID = {row.Cells["id"].Value}", "Погоджуюсь",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();

                    string com = "DELETE FROM enterprises WHERE id = '" + row.Cells["id"].Value + "'";

                    MySqlCommand dell = new MySqlCommand(com, _manager.getConnection());


                    if (dell.ExecuteNonQuery() == 1)
                    {
                        dataGridViewSearchWindow.Rows.RemoveAt(row.Index);
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

        private void dataGridViewSearchWindow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewSearchWindow.Rows[e.RowIndex].Cells[0].Value);

                this.Hide();
                EnterpriseEdit edit = new EnterpriseEdit(id, this);
                edit.Show();
            }
        }
    }
}
