using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class PlotEdit: Form
    {
        public int _id;
        private PlotSearch _plotSearch;
        VillageStreet villageStreet = new VillageStreet();
        private Land_plot data = new Land_plot();

        public PlotEdit(int id, PlotSearch plotSearch)
        {
            InitializeComponent();
            _id = id;
            _plotSearch = plotSearch;
            data = GetValueFromDB(id);

            textBoxFullName.Text = data.fullName.ToString();
            comboBoxVillage.Text = data.village.ToString();
            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxStreets.Text = data.street.ToString();
            textBoxHouseNumb.Text = data.houseNummb.ToString();
            textBoxFieldNumber.Text = data.fieldNumber ?? string.Empty;
            textBoxPlotType.Text = data.plotType ?? string.Empty;
            textBoxPlotNumber.Text = data.plotNumber ?? string.Empty;
            textBoxPlotArea.Text = data.plotArea.ToString();
            textBoxCadastr.Text = data.cadastr ?? string.Empty;
            textBoxTenant.Text = data.tenant ?? string.Empty;
            textBoxURL.Text = data.url ?? string.Empty;
        }

        private Land_plot GetValueFromDB(int id)
        {
            Land_plot row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string query = "SELECT * FROM plot WHERE id = " + id;

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = Land_plot.ReadOne(_reader);
            }
            return row;
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            bool changed = true;


            if (textBoxFullName.Text != "")
            {
                string fullName = textBoxFullName.Text.Replace("'", "`").Replace('"', '`');
                string village = comboBoxVillage.Text;
                string street = comboBoxStreets.Text;
                string houseNumb = textBoxHouseNumb.Text;
                string fieldNumber = textBoxFieldNumber.Text;
                string plotType = textBoxPlotType.Text;
                string plotNumber = textBoxPlotNumber.Text;
                decimal plotArea = Convert.ToDecimal(textBoxPlotArea.Text.Replace(".", ",").Replace(".", ",").Replace(",", ",").Replace(".", ","));
                string cadastr = textBoxCadastr.Text;
                string tenant = textBoxTenant.Text;
                string url = textBoxURL.Text;
                int id = _id;
                bool a = false;

                _manager.openConnection();

                if (cadastr != null)
                {
                    string equal = "SELECT * FROM plot WHERE cadastr IS NOT NULL AND cadastr <> '' AND" +
                        " cadastr = '" + cadastr + "' AND id <> '" + id + "'";

                    MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                    _reader = search.ExecuteReader();
                    a = _reader.HasRows;
                    _reader.Close();

                    if (a)
                    {
                        MessageBox.Show("Земельна ділянка з таким кадастровим номером уже є в таблиці !!!");
                        return;
                    }

                }

                string _commandString = "UPDATE plot SET fullname = @fullName, " +
                                        "village = @village, " +
                                        "street = @street, " +
                                        "housenumb = @houseNumb, " +
                                        "fieldnumber = @fieldNumber, " +
                                        "plottype = @plotType, " +
                                        "plotnumber = @plotNumber, " +
                                        "plotarea = @plotArea, " +
                                        "cadastr = @cadastr, " +
                                        "tenant = @tenant, " +
                                        "url = @url " +
                                        "WHERE id = @id";


                try
                {
                    using (MySqlCommand command = new MySqlCommand(_commandString, _manager.getConnection()))
                    {
                        command.Parameters.AddWithValue("@fullName", fullName);
                        command.Parameters.AddWithValue("@village", village);
                        command.Parameters.AddWithValue("@street", street);
                        command.Parameters.AddWithValue("@houseNumb", houseNumb);
                        command.Parameters.AddWithValue("@fieldNumber", fieldNumber);
                        command.Parameters.AddWithValue("@plotType", plotType);
                        command.Parameters.AddWithValue("@plotNumber", plotNumber);
                        command.Parameters.AddWithValue("@plotArea", plotArea);
                        command.Parameters.AddWithValue("@cadastr", cadastr);
                        command.Parameters.AddWithValue("@tenant", tenant);
                        command.Parameters.AddWithValue("@url", url);
                        command.Parameters.AddWithValue("@id", id);

                        // Виконати команду
                        command.ExecuteNonQuery();
                        if (command.ExecuteNonQuery() != 1)
                            changed = false;
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    _manager.closeConnection();
                }
                
            }
            else
                MessageBox.Show("Не всі поля заповнені !");
            if (changed)
            {
                MessageBox.Show("Дані змінено !");
                this.Close();
                _plotSearch.Show();
            }
            else
            {
                MessageBox.Show("Дані не змінилится !");
                this.Close();
                _plotSearch.Show();
            }

            _manager.closeConnection();
        }

        private void comboBoxVilaage_SelectedIndexChanged(object sender, EventArgs e)
        {
            villageStreet.ComboBoxStreetChoose(comboBoxVillage, comboBoxStreets);
        }
    }
}
