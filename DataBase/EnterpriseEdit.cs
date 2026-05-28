using DataBase.Repositories;
using DataBase.Services;
using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class EnterpriseEdit : Form
    {
        AddressService service = new AddressService();
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
            AddressIds ids = new AddressIds();
            int villageId = ids.GetAddressByIdEnterprise(_id).villageId;
            int streetId = ids.GetAddressByIdEnterprise(_id).streetId;
            service.LoadVillages(comboBoxVillage);
            comboBoxVillage.SelectedValue = villageId;
            service.LoadStreets(comboBoxStreets, villageId);
            comboBoxStreets.SelectedValue = streetId;
            data = EnterpriseRepository.GetValueFromDB(id);

            textBoxName.Text = data.name.ToString();
            textBoxOwner.Text = data.owner ?? string.Empty;
            textBoxHouseNumber.Text = data.houseNumber.ToString();
            textBoxEmployeesNumber.Text = data.employeesNumber.ToString() ?? string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            bool changed = true;

            string Name = textBoxName.Text.Replace("'", "`").Replace('"', '`');
            //var village = comboBoxVillage.SelectedItem as Village;
            //var street = comboBoxStreets.SelectedItem as Street;
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
            var village1 = comboBoxVillage.SelectedItem as Village;
            if (village1 == null)
            {
                MessageBox.Show("Оберіть населений пункт!");
                return;
            }
            int villageId = village1.Id;

            var street1 = comboBoxStreets.SelectedItem as Street;
            if (street1 == null)
            {
                MessageBox.Show("Вкажіть вулицю!");
                return;
            }
            int streetId = street1.Id;

            int villagestreetId = villageStreetRepository.GetVillageStreetId(villageId, streetId, _manager.getConnection());

            string _commandString = "UPDATE enterprises SET name = @Name, " +
                                        "villagestreetId = @villagestreetId, " +
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
                MessageBox.Show("Дані не змінилися !");
                this.Close();
                _enterpriseSearch.Show();
            }

            _manager.closeConnection();
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                service.LoadStreets(comboBoxStreets, villageId);
            }
        }
    }
}
