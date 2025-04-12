using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class PlotEdit: Form
    {
        public int _id;
        private PlotSearch _plotSearch;
        //private List<VillageStreet> data = new List<VillageStreet>();
        private RowOfDataPlot data = new RowOfDataPlot();

        public PlotEdit(int id, PlotSearch plotSearch)
        {
            InitializeComponent();
            _id = id;
            _plotSearch = plotSearch;
            data = GetValueFromDB(id);

            textBoxFullName.Text = data.fullName.ToString();
            textBoxVillage.Text = data.village.ToString();
            textBoxStreet.Text = data.street.ToString();
            textBoxHouseNumb.Text = data.houseNummb.ToString();
            textBoxFieldNumber.Text = data.fieldNumber.ToString();
            textBoxPlotType.Text = data.plotType.ToString();
            textBoxPlotNumber.Text = data.plotNumber.ToString();
            textBoxPlotArea.Text = data.plotArea.ToString();
            textBoxCadastr.Text = data.cadastr.ToString();
            textBoxTenant.Text = data.tenant.ToString();
           
            bool mess = false;
            //data.Clear();

            //ConnectionClass _manager = new ConnectionClass();
            //MySqlDataReader _reader;
            //_manager.openConnection();

            //string reader = "SELECT DISTINCT village FROM villagestreet";
            //MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            //_reader = _search.ExecuteReader();

            //while (_reader.Read())
            //{
            //    VillageStreet row = new VillageStreet(_reader["village"]);
            //    data.Add(row);

            //}
            //_reader.Close();

            //for (int i = 0; i < data.Count; i++)
            //{
            //    AddDataGrid(data[i]);
            //    mess = true;
            //}
            //if (mess == false)
            //{
            //    MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            //}
            //_manager.closeConnection();
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
                       _reader["plotnumber"], _reader["plotarea"], _reader["cadastr"], _reader["tenant"]);
            }
            return row;
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            ConnectionClass _manager = new ConnectionClass();

            bool changed = true;


            if (textBoxFullName.Text != "")
            {
                string fullName = textBoxFullName.Text.Replace("'", "`").Replace('"', '`');
                string village = textBoxVillage.Text;
                string street = textBoxStreet.Text;
                string houseNumb = textBoxHouseNumb.Text;
                string fieldNumber = textBoxFieldNumber.Text;
                string plotType = textBoxPlotType.Text;
                string plotNumber = textBoxPlotNumber.Text;
                decimal plotArea = Convert.ToDecimal(textBoxPlotArea.Text);
                string cadastr = textBoxCadastr.Text;
                string tenant = textBoxTenant.Text;
                int id = _id;

                string _commandString = "UPDATE plot SET fullname = @fullName, " +
                                        "village = @village, " +
                                        "street = @street, " +
                                        "housenumb = @houseNumb, " +
                                        "fieldnumber = @fieldNumber, " +
                                        "plottype = @plotType, " +
                                        "plotnumber = @plotNumber, " +
                                        "plotarea = @plotArea, " +
                                        "cadastr = @cadastr, " +
                                        "tenant = @tenant " +
                                        "WHERE id = @id";


                try
                {
                    _manager.openConnection();
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
    }
}
