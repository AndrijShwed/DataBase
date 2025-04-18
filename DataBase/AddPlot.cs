using MySqlConnector;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class AddPlot : Form
    {
        VillageStreet villageStreet = new VillageStreet();
        public AddPlot()
        {
            InitializeComponent();
            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxVillage.Text = "Виберіть населений пункт";
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

        private void земляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plot form = new Plot();
            this.Close();
            form.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool a = false;
            bool add = false;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            if (textBoxFullName.Text == "" || textBoxPlotType.Text == "" || textBoxPlotArea.Text == "")
            {
                MessageBox.Show("Не заповнено поле власника або тип земельної ділянки або площа");
                return;
            }

            string PIP = textBoxFullName.Text;
            string village = comboBoxVillage.Text;
            string street = comboBoxStreets.Text;
            string houseNumb = textBoxHouseNumb.Text;
            string fieldNumb = textBoxFieldNumber.Text;
            string plotType = textBoxPlotType.Text;
            string plotNumber = textBoxPlotNumber.Text;
            decimal plotArea = 0;
            string url = textBoxURL.Text;

            if (textBoxPlotArea.Text != "")
            {
                plotArea = Convert.ToDecimal(textBoxPlotArea.Text.Replace(".", ",").Replace(".", ",").Replace(",", ",").Replace(".", ","));
            }
           
            string cadastr = textBoxCadastr.Text;
            string tenant = textBoxTenant.Text;

            try
            {
                _manager.openConnection();

                if (cadastr != null)
                {
                    string equal = "SELECT * FROM plot WHERE cadastr IS NOT NULL AND cadastr <> '' AND" +
                        " cadastr = '" + cadastr + "'";

                    MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                    _reader = search.ExecuteReader();
                    a = _reader.HasRows;
                    _reader.Close();

                    if (a)
                    {
                        MessageBox.Show("Земельна ділянка з таким кадастровим номером уже є втаблиці !!!");
                        return;
                    }

                }
                if (PIP != null && village != null && street != null && houseNumb != null && plotType == "ОЖБ")
                {
                    string equal = "SELECT * FROM plot WHERE fullname = '" + PIP + "' AND village = '" + village + "' AND " +
                        " street = '" + street + "' AND housenumb = '" + houseNumb + "' AND plottype = 'ОЖБ'";

                    MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                    _reader = search.ExecuteReader();
                    a = _reader.HasRows;
                    _reader.Close();

                    if (a)
                    {
                        MessageBox.Show("Земельна ділянка уже є втаблиці !!!");
                        return;
                    }

                }

                if (fieldNumb != null && plotType != null && plotNumber != null && plotArea != 0)
                {
                    string equal = "SELECT * FROM plot WHERE fieldnumber IS NOT NULL AND fieldnumber <> '' AND" +
                        " fieldnumber = '" + fieldNumb + "' AND plottype IS NOT NULL AND plottype <> '' AND" +
                        " plottype = '" + plotType + "' AND plotnumber IS NOT NULL AND plotnumber <> '' AND" +
                        " plotnumber = '" + plotNumber + "' AND plotarea IS NOT NULL AND plotarea <> '' AND" +
                        " plotarea = '" + plotArea + "'";

                    MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                    _reader = search.ExecuteReader();
                    a = _reader.HasRows;
                    _reader.Close();

                    if (a)
                    {
                        MessageBox.Show("Земельна ділянка уже є втаблиці !!!");
                        return;
                    }
                }

                string _commandString = "INSERT INTO `berezhnytsya`.`plot` (fullname, village, street, housenumb, " +
                                      "`fieldnumber`, plottype, plotnumber, plotarea, cadastr, tenant, url) VALUES(@fullname, @village, " +
                                      "@street, @housenumb, @fieldnumber, @plottype, @plotnumber, @plotarea, @cadastr, @tenant, @url)";


                MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());


                _command.Parameters.Add("@fullname", MySqlDbType.VarChar).Value = textBoxFullName.Text.ToString().Replace("'", "`").Replace('"', '`');
                _command.Parameters.Add("@village", MySqlDbType.VarChar).Value = comboBoxVillage.Text.ToString();
                _command.Parameters.Add("@street", MySqlDbType.VarChar).Value = comboBoxStreets.Text.ToString();
                _command.Parameters.Add("@housenumb", MySqlDbType.VarChar).Value = textBoxHouseNumb.Text.ToString();
                _command.Parameters.Add("@fieldnumber", MySqlDbType.VarChar).Value = textBoxFieldNumber.Text.ToString();
                _command.Parameters.Add("@plottype", MySqlDbType.VarChar).Value = textBoxPlotType.Text.ToString();
                _command.Parameters.Add("@plotnumber", MySqlDbType.VarChar).Value = textBoxPlotNumber.Text.ToString();
                _command.Parameters.Add("@plotarea", MySqlDbType.Decimal).Value = plotArea;
                _command.Parameters.Add("@cadastr", MySqlDbType.VarChar).Value = textBoxCadastr.Text.ToString();
                _command.Parameters.Add("@tenant", MySqlDbType.VarChar).Value = textBoxTenant.Text.ToString();
                _command.Parameters.Add("@url", MySqlDbType.VarChar).Value = textBoxURL.Text.ToString();

                if (_command.ExecuteNonQuery() == 1)
                    add = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                _manager.closeConnection();
            }
            if (add)
            {
                MessageBox.Show("Дані добавлено !");
                textBoxFullName.Text = string.Empty;
                comboBoxVillage.Text = "Виберіть населений пункт";
                comboBoxStreets.Text = string.Empty;
                textBoxHouseNumb.Text = string.Empty;
                textBoxFieldNumber.Text = string.Empty;
                textBoxPlotType.Text = string.Empty;
                textBoxPlotNumber.Text = string.Empty;
                textBoxPlotArea.Text = string.Empty;
                textBoxCadastr.Text = string.Empty;
                textBoxTenant.Text = string.Empty;
                textBoxURL.Text = string.Empty;
            }
            else

                MessageBox.Show("Помилка добавлення даних !");
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            villageStreet.comboBoxStreetChoose(comboBoxVillage, comboBoxStreets);
        }
    }
}
