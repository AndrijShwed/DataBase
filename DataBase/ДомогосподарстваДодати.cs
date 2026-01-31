using DataBase.Repositories;
using DataBase.Services;
using DocumentFormat.OpenXml.ExtendedProperties;
using MySqlConnector;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ДомогосподарстваДодати : Form
    {
        VillageStreetRepository _villageStreetRepo = new VillageStreetRepository();
        AddressService service = new AddressService();
        // private User user;

        public ДомогосподарстваДодати()
        {
            InitializeComponent();
            service.LoadVillages(comboBoxVillage);

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
            Головна form = System.Windows.Forms.Application.OpenForms.OfType<Головна>().FirstOrDefault();
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
            System.Windows.Forms.Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
        }

        private void ЗберегтиВТаблицю_Click(object sender, EventArgs e)
        {
            ConnectionClass conn = new ConnectionClass();
            bool add = false;
            bool a = false;

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

            string choose = "SELECT * FROM houses WHERE villagestreetId = @villagestreetId AND numb_of_house = @numb";
            MySqlCommand search = new MySqlCommand(choose, conn.getConnection());
            search.Parameters.AddWithValue("@villagestreetId", villagestreetId);
            search.Parameters.AddWithValue("@numb", numb);
            MySqlDataReader _reader;
            _reader = search.ExecuteReader();
            a = _reader.HasRows;
            _reader.Close();
            if (a)
            {
                MessageBox.Show("Таке домогосподарство вже існує у погосподарській книзі");
            }
            else
            {
                try
                {
                    string _commandString = "INSERT INTO `houses`(`numb_of_house`,`lastname`,`name`,`surname`,`totalArea`,`livingArea`,`total_of_rooms`,`villagestreetId`)" +
                        "VALUES(@numb_of_house,@lastname,@name,@surname,@totalArea,@livingArea,@total_of_rooms,@villagestreetId)";
                    MySqlCommand _command = new MySqlCommand(_commandString, conn.getConnection());

                    _command.Parameters.AddWithValue("@numb_of_house", numb);
                    _command.Parameters.AddWithValue("@lastname", lastname);
                    _command.Parameters.AddWithValue("@name", name);
                    _command.Parameters.AddWithValue("@surname", surname);
                    _command.Parameters.AddWithValue("@totalArea", totalarea);
                    _command.Parameters.AddWithValue("@livingArea", livingarea);
                    _command.Parameters.AddWithValue("@total_of_rooms", countrooms);
                    _command.Parameters.AddWithValue("@villagestreetId", villagestreetId);

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
                if (add)
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
        }
            
        

        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
        }
    }
}
