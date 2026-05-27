using DataBase.Repositories;
using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class EnterpriseEdit : Form
    {
        public int _id;
        private EnterpriseSearch _enterpriseSearch;
        VillageStreet villageStreet = new VillageStreet();
        private Enterprise data = new Enterprise();
        VillageStreetRepository villageStreetRepository = new VillageStreetRepository();
        public EnterpriseEdit(int id, EnterpriseSearch search)
        {
            InitializeComponent();
            _id = id;
            _enterpriseSearch = search;
            data = EnterpriseRepository.GetValueFromDB(id);

            textBoxName.Text = data.name.ToString();
            textBoxOwner.Text = data.owner ?? string.Empty;
            comboBoxVillage.Text = data.village.ToString();
            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxStreets.Text = data.street.ToString();
            textBoxHouseNumber.Text = data.houseNumber.ToString();
            textBoxEmployeesNumber.Text = data.employeesNumber.ToString() ?? string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            bool changed = true;

            string Name = textBoxName.Text.Replace("'", "`").Replace('"', '`');
            var village = comboBoxVillage.SelectedItem as Village;
            var street = comboBoxStreets.SelectedItem as Street;
            string houseNumber = textBoxHouseNumber.Text;
            string owner = textBoxOwner.Text;
            string employeesNumber = textBoxEmployeesNumber.Text;
            int id = _id;
            bool a = false;

            _manager.openConnection();

            if (Name != null)
            {
                string equal = "SELECT * FROM enterprises WHERE name IS NOT NULL AND" +
                    " name = '" + Name + "' AND id <> '" + id + "'";

                MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                _reader = search.ExecuteReader();
                a = _reader.HasRows;
                _reader.Close();

                if (a)
                {
                    MessageBox.Show("Підприємство з такою назвою уже є в таблиці !!!");
                    return;
                }

            }
            
            int villagestreetId = villageStreetRepository.GetVillageStreetId(village.Id, street.Id, _manager.getConnection());

            string _commandString = "UPDATE enterprises SET name = @Name, " +
                                        "villagstreetId = @villagestreetId, " +
                                        "housenumber = @houseNumber, " +
                                        "employeesnumber = @employeesNumber, " +
                                        "owner = @owner " +
                                        "WHERE id = @id";

            try
            {
                using (MySqlCommand command = new MySqlCommand(_commandString, _manager.getConnection()))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    command.Parameters.AddWithValue("@houseNumber", houseNumber);
                    command.Parameters.AddWithValue("@employeesNumber", employeesNumber);
                    command.Parameters.AddWithValue("@owner", owner);
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
            if (changed)
            {
                MessageBox.Show("Дані змінено !");
                this.Close();
                _enterpriseSearch.Show();
            }
            else
            {
                MessageBox.Show("Дані не змінилится !");
                this.Close();
                _enterpriseSearch.Show();
            }

            _manager.closeConnection();
        }
    }
}
