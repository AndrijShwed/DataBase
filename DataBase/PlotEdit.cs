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
        private RowOfDataPlot data = new RowOfDataPlot();

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
            textBoxFieldNumber.Text = data.fieldNumber.ToString();
            textBoxPlotType.Text = data.plotType.ToString();
            textBoxPlotNumber.Text = data.plotNumber.ToString();
            textBoxPlotArea.Text = data.plotArea.ToString();
            textBoxCadastr.Text = data.cadastr.ToString();
            textBoxTenant.Text = data.tenant.ToString();
            textBoxURL.Text = data.url.ToString();
        }

        private RowOfDataPlot GetValueFromDB(int id)
        {
            RowOfDataPlot row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string query = "SELECT * FROM plot WHERE id = " + id;

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = new RowOfDataPlot(_reader["id"], _reader["fullname"], _reader["village"],
                       _reader["street"], _reader["housenumb"], _reader["fieldnumber"], _reader["plottype"],
                       _reader["plotnumber"], _reader["plotarea"], _reader["cadastr"], _reader["tenant"], _reader["url"]);
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
                decimal plotArea = Convert.ToDecimal(textBoxPlotArea.Text);
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
                        MessageBox.Show("Земельна ділянка з таким кадастровим номером уже є втаблиці !!!");
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
            villageStreet.comboBoxStreetChoose(comboBoxVillage, comboBoxStreets);
        }
    }
}
