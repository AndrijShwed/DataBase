using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class PlotSearch: Form
    {
       private List<RowOfDataPlot> _data = new List<RowOfDataPlot>(); 
        VillageStreet villageStreet = new VillageStreet();

        public PlotSearch()
        {
            InitializeComponent();
            HeaderOfTheTable();

            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxVillage.Text = "Виберіть населений пункт";

            buttonSearch.Text = "Пошук  \U0001F504";
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
            column1.Width = 60;
            column1.Name = "id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Власник";
            column2.Width = 232;
            column2.Name = "fullname";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Нас. пункт";
            column3.Width = 140;
            column3.Name = "vsllage";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Вулиця";
            column4.Width = 140;
            column4.Name = "street";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Номер буд";
            column5.Width = 60;
            column5.Name = "housenumb";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Номер поля";
            column6.Width = 80;
            column6.Name = "fieldnumber";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Тип землі";
            column7.Width = 60;
            column7.Name = "plottype";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Номер ділянки";
            column8.Width = 60;
            column8.Name = "plotnumber";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Площа, Га";
            column9.Width = 60;
            column9.Name = "plotarea";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Кадастровий номер";
            column10.Width = 160;
            column10.Name = "cadastr";
            column10.Frozen = true;
            column10.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Орендар";
            column11.Width = 160;
            column11.Name = "tenant";
            column11.Frozen = true;
            column11.CellTemplate = new DataGridViewTextBoxCell();

            var column12 = new DataGridViewLinkColumn();
            column12.HeaderText = "Посилання на карту";
            column12.Width = 160;
            column12.Name = "url";
            column12.Frozen = true;
            column12.CellTemplate = new DataGridViewLinkCell();

            var column13 = new DataGridViewColumn();
            column13.HeaderText = "Видалити";
            column13.Width = 80;
            column13.Name = "Видалити";
            column13.Frozen = true;
            column13.CellTemplate = new DataGridViewTextBoxCell();

            var column14 = new DataGridViewColumn();
            column14.HeaderText = "id";
            column14.Width = 1;
            column14.Name = "id";
            column14.Frozen = true;
            column14.CellTemplate = new DataGridViewTextBoxCell();


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

            dataGridViewВікноПошуку.AllowUserToAddRows = false;
            dataGridViewВікноПошуку.ReadOnly = true;
        }

        private void головToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void земляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot form = new Plot();
            this.Close();
            form.Show();
        }

        private void AddDataGrid(RowOfDataPlot row)
        {
            dataGridViewВікноПошуку.Rows.Add(row.id, row.fullName, row.village, row.street, row.houseNummb, row.fieldNumber, row.plotType, row.plotNumber,
                row.plotArea, row.cadastr, row.tenant, row.url, row.id, row.id);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewВікноПошуку.DataSource = null;
            dataGridViewВікноПошуку.Rows.Clear();

            _data.Clear();

            bool mess = false;
            decimal totalArea = 0;

            if (textBoxFullName.Text == "" && textBoxFieldNumber.Text == "" &&
                   textBoxPlotType.Text == "" && comboBoxVillage.Text == "Виберіть населений пункт" &&
                   textBoxCadastr.Text == "" && textBoxPlotNumber.Text == "" &&
                   textBoxTenant.Text == "" && comboBoxStreets.Text == "" && textBoxHouseNumb.Text == "")
            {
                MessageBox.Show("Жодне поле пошуку не заповнено !");
                return;
            }

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            SQLCommand c = new SQLCommand();

            string fullName = (textBoxFullName.Text).ToLower().Replace("'", "`").Replace('"', '`');
            string fieldNumber = textBoxFieldNumber.Text;
            string village = (comboBoxVillage.Text).ToLower();
            string street = (comboBoxStreets.Text).ToLower();
            string plotType = textBoxPlotType.Text;
            string plotNumber = textBoxPlotNumber.Text;
            string tenant = (textBoxTenant.Text).ToLower();
            string cadastr = textBoxCadastr.Text;
            string houseNumb = textBoxHouseNumb.Text;


            bool first = true;
            c.com = "SELECT * FROM plot ";

            if (textBoxFullName.Text != "")
            {
                if (first)
                {
                    c.com = c.com + "WHERE LOWER(fullname) LIKE '%" + fullName + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(fullname) LIKE '%" + fullName + "%'";
                }

            }
            if (comboBoxVillage.Text != "Виберіть населений пункт")
            {
                if (first)
                {
                    c.com = c.com + "WHERE LOWER(village) Like '%" + village + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(village) LIKE '%" + village + "%'";
                }

            }
            if (comboBoxStreets.Text != "Виберіть вулицю" && comboBoxStreets.Text != "")
            {
                if (first)
                {
                    c.com = c.com + "WHERE LOWER(street) Like '%" + street + "%'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(street) LIKE '%" + street + "%'";
                }

            }
            if (textBoxHouseNumb.Text != "")
            {
                if (first)
                {
                    c.com = c.com + "WHERE LOWER(housenumb) = '" + houseNumb + "'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND LOWER(housenumb) = '" + houseNumb + "'";
                }

            }
            if (textBoxFieldNumber.Text != "")
            {

                if (first)
                {
                    c.com = c.com + "WHERE fieldnumber = '" + fieldNumber + "'";
                    first = false;
                }
                else
                {
                    c.com = c.com + " AND fieldnumber = '" + fieldNumber + "'";
                }

            }
            if (textBoxPlotType.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(plottype) LIKE '%" + plotType + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(plottype) LIKE '%" + plotType + "%'";
                }
            }
            if (textBoxPlotNumber.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE plotnumber = '" + plotNumber + "'";
                }
                else
                {
                    c.com = c.com + " AND plotnumber = '" + plotNumber + "'";
                }
            }
            if (textBoxCadastr.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE cadastr = '" + cadastr + "'";
                }
                else
                {
                    c.com = c.com + " AND cadastr = '" + cadastr + "'";
                }
            }
            if (textBoxTenant.Text != "")
            {
                if (first)
                {
                    first = false;
                    c.com = c.com + "WHERE LOWER(tenant) LIKE '%" + tenant + "%'";
                }
                else
                {
                    c.com = c.com + " AND LOWER(tenant) LIKE '%" + tenant + "%'";
                }
            }
           
            try
            {
                _manager.openConnection();

                MySqlCommand _command = new MySqlCommand(c.com, _manager.getConnection());
                _reader = _command.ExecuteReader();


                while (_reader.Read())
                {
                    RowOfDataPlot row = new RowOfDataPlot(_reader["id"], _reader["fullname"], _reader["village"],
                        _reader["street"], _reader["housenumb"], _reader["fieldnumber"], _reader["plottype"],
                        _reader["plotnumber"], _reader["plotarea"], _reader["cadastr"], _reader["tenant"], _reader["url"]);
                    _data.Add(row);

                }
                for (int i = 0; i < _data.Count; i++)
                {

                    AddDataGrid(_data[i]);

                    dataGridViewВікноПошуку.Rows[i].Cells[0].Value = i + 1;
                    dataGridViewВікноПошуку.Rows[i].Cells[12].Value = "Видалити";
                    dataGridViewВікноПошуку.Rows[i].Cells[12].Style.BackColor = Color.DarkRed;
                    dataGridViewВікноПошуку.Rows[i].Cells[12].Style.ForeColor = Color.White;
                    dataGridViewВікноПошуку.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    totalArea += Convert.ToDecimal(_data[i].plotArea);
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
            textBoxPlotAmount.Text = Convert.ToString(_data.Count);
            textBoxTotalArea.Text = totalArea.ToString();
        }

        private void dataGridViewВікноПошуку_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                DataGridViewRow row = dataGridViewВікноПошуку.Rows[e.RowIndex];


                if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells[13].Value), "Погоджуюсь",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ConnectionClass _manager = new ConnectionClass();
                    _manager.openConnection();

                    string com = "DELETE FROM plot WHERE id = '" + row.Cells[13].Value + "'";

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

            if (e.ColumnIndex == 11)
            {
                string url = dataGridViewВікноПошуку.Rows[e.RowIndex].Cells[11].Value?.ToString();

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true // потрібне для .NET Core/.NET 5+ щоб відкривати в браузері
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не вдалося відкрити посилання: " + ex.Message);
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFullName.Text = string.Empty;
            comboBoxVillage.Text = "Виберіть населений пункт";
            comboBoxStreets.Text = string.Empty;
            comboBoxStreets.Items.Clear();
            textBoxPlotType.Text = string.Empty;
            textBoxPlotNumber.Text = string.Empty;
            textBoxFieldNumber.Text = string.Empty;
            textBoxTenant.Text = string.Empty;
            textBoxCadastr.Text = string.Empty;
        }

        private void dataGridViewВікноПошуку_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewВікноПошуку.Rows[e.RowIndex].Cells[13].Value);

                this.Hide();
                PlotEdit редагувати = new PlotEdit(id, this);
                редагувати.Show();
            }
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            villageStreet.comboBoxStreetChoose(comboBoxVillage, comboBoxStreets);
        }
    }
}
