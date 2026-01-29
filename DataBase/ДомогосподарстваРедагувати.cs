using DataBase.Repositories;
using DataBase.Services;
using MySqlConnector;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ДомогосподарстваРедагувати : Form
    {
        private int id;
        private VillageStreetRepository _villageStreetRepo = new VillageStreetRepository();
        RowOfDataH _data = new RowOfDataH();
        AddressService service = new AddressService();
        // private User user;

        public ДомогосподарстваРедагувати(int _id)
        {
            id = _id;
            InitializeComponent();
            AddressIds ids = new AddressIds();
            int villageId = ids.GetAddressByIdHouse(_id).villageId;
            int streetId = ids.GetAddressByIdHouse(_id).streetId;
            service.LoadVillages(comboBoxVillage);
            comboBoxVillage.SelectedValue = villageId;
            service.LoadStreets(comboBoxStreets, villageId);
            comboBoxStreets.SelectedValue = streetId;
            var data = _data.GetValueFromDBHouse(_id);

            textBoxNumb.Text = data.numb_of_house.ToString();
            textBoxLastname.Text = data.lastname.ToString();
            textBoxName.Text = data.name.ToString();
            textBoxSurname.Text = data.surname.ToString();
            textBoxTotalArea.Text = data.totalArea.ToString();
            textBoxLivingArea.Text = data.livingArea.ToString();
            textBoxCountRooms.Text = data.total_of_rooms.ToString();

        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                service.LoadStreets(comboBoxStreets, villageId);
            }
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

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }
        
        private void ЗберегтиВТаблицю_Click(object sender, EventArgs e)
        {
            ConnectionClass conn = new ConnectionClass();
            bool add = false;

            try
            {
                conn.openConnection();

                string numb = textBoxNumb.Text;
                string lastname = textBoxLastname.Text;
                string name = textBoxName.Text;
                string surname = textBoxSurname.Text;
                double GetDoubleOrZero(TextBox tb)
                {
                    return double.TryParse(tb.Text.Replace(",", "."),
                              NumberStyles.Any,
                              CultureInfo.InvariantCulture,
                              out double val) ? val : 0;
                }

                // використання
                double totalarea = GetDoubleOrZero(textBoxTotalArea);
                double livingarea = GetDoubleOrZero(textBoxLivingArea);
                double countrooms = GetDoubleOrZero(textBoxCountRooms);

                var village = comboBoxVillage.SelectedItem as Village;
                if (village == null)
                {
                    MessageBox.Show("Оберіть населений пункт !");
                    return;
                }
                int villageId = village.Id;

                var street = comboBoxStreets.SelectedItem as Street;
                if (street == null)
                {
                    MessageBox.Show("Вкажіть вулицю !");
                    return;
                }
                int streetId = street.Id;
                int villagestreetId = _villageStreetRepo.GetVillageStreetId(villageId, streetId, conn.getConnection());

                if (string.IsNullOrWhiteSpace(numb) ||
                    string.IsNullOrWhiteSpace(lastname) ||
                    string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Заповніть обов'язкові поля *!");
                    return;
                }

                string _commandString = @"UPDATE houses SET 
                                numb_of_house = @numb_of_house,
                                lastname = @lastname,
                                name = @name,
                                surname = @surname,
                                totalArea = @totalArea,
                                livingArea = @livingArea,
                                total_of_rooms = @total_of_rooms,
                                villagestreetId = @villagestreetId
                            WHERE idhouses = @idhouses";
                MySqlCommand _command = new MySqlCommand(_commandString, conn.getConnection());

                    _command.Parameters.AddWithValue("@numb_of_house", numb);
                    _command.Parameters.AddWithValue("@lastname", lastname);
                    _command.Parameters.AddWithValue("@name", name);
                    _command.Parameters.AddWithValue("@surname", surname);
                    _command.Parameters.AddWithValue("@totalArea", totalarea);
                    _command.Parameters.AddWithValue("@livingArea", livingarea);
                    _command.Parameters.AddWithValue("@total_of_rooms", countrooms);
                    _command.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                    _command.Parameters.AddWithValue("@idhouses", id);

                if (_command.ExecuteNonQuery() == 1)
                {
                    add = true;
                    MessageBox.Show("Дані добавлено !");
                }
                else
                {
                    MessageBox.Show("Запис не було додано !");
                }   

            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка БД:\n" + ex.Message);
            }

            finally
            {
                conn.closeConnection();
            }
            if(add)
            {
                comboBoxVillage.SelectedIndex = -1;
                comboBoxStreets.SelectedIndex = -1;
                textBoxNumb.Text = string.Empty;
                textBoxName.Text = string.Empty;
                textBoxLastname.Text = string.Empty;
                textBoxName.Text = string.Empty;
                textBoxSurname.Text = string.Empty;
                textBoxTotalArea.Text = string.Empty;
                textBoxLivingArea.Text = string.Empty;
                textBoxCountRooms.Text = string.Empty;
            }
        }

        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }
    }
}
