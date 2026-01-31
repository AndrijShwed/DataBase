using DataBase.Repositories;
using DataBase.Services;
using MySqlConnector;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Додати : Form
    {
        private VillageStreetRepository _villageStreetRepo = new VillageStreetRepository();
        AddressService service = new AddressService();
        // private User user;

        public Додати()
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

        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            Program.OpenForm(this, form);
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonПовернутись_Click_1(object sender, EventArgs e)
        {
            Населення form = new Населення();
            Program.OpenForm(this, form);
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            bool a = false;
            bool add = false;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;

            if (textBoxLastName.Text != "" &&
                textBoxName.Text != "" &&
                comboBoxSex.SelectedItem != null &&
                comboBoxRegistration.SelectedItem != null &&
                comboBoxVillage.Text != "" &&
                comboBoxStreets.Text != "" &&
                textBoxNumbOfHouse.Text != "" &&
                maskedTextBoxDateOfBirth.Text.Length == 8 &&
                maskedTextBoxChangeDate.Text.Length == 8)
            {

                try 
                {
                    _manager.openConnection();

                    string lastname = textBoxLastName.Text.ToString().Replace("'", "`").Replace('"', '`');
                    string name = textBoxName.Text.ToString().Replace("'", "`").Replace('"', '`');
                    string surname = textBoxSurname.Text.ToString().Replace("'", "`").Replace('"', '`');
                    string sex = comboBoxSex.SelectedItem.ToString();

                    if (!DateTime.TryParseExact(maskedTextBoxDateOfBirth.Text.Trim(), "dd.MM.yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date_of_birth))
                    {
                        MessageBox.Show("Дата народження невірна!");
                        return;
                    }

                    if (!DateTime.TryParseExact(maskedTextBoxChangeDate.Text, "dd.MM.yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime m_date))
                    {
                        MessageBox.Show("Дата зміни статусу невірна!");
                        return;
                    }

                    if (date_of_birth > DateTime.Today || m_date > DateTime.Today)
                    {
                        MessageBox.Show("Дата не може бути з майбутнього!");
                        return;
                    }

                    string registr = comboBoxRegistration.SelectedItem.ToString();

                    if (lastname != "" && name != "" && sex != "" && 
                        date_of_birth != null && m_date != null && registr != "")
                    {
                        string equal = "SELECT * FROM people WHERE lastname = @lastname AND" +
                            " name = @name AND surname = @surname AND " +
                                "date_of_birth = @date_of_birth";

                        MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                        search.Parameters.AddWithValue("@lastname", lastname);
                        search.Parameters.AddWithValue("@name", name);
                        search.Parameters.AddWithValue("@surname", surname);
                        search.Parameters.Add("@date_of_birth", MySqlDbType.Date).Value = date_of_birth;
                        _reader = search.ExecuteReader();
                        a = _reader.HasRows;
                        _reader.Close();

                        if (a)
                        {
                            MessageBox.Show("Така особа уже є в погосподарській книзі !!!");

                        }
                        else
                        {
                            try
                            {
                                if (date_of_birth > DateTime.Now || m_date > DateTime.Now)
                                {
                                    MessageBox.Show("Дата народження або дата зміни статусу не може бути новішою за поточну дату !");
                                }
                                else
                                {
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
                                    int villagestreetId = _villageStreetRepo.GetVillageStreetId(villageId, streetId, _manager.getConnection());

                                    string _commandString = "INSERT INTO `people`(`lastname`,`name`,`surname`,`sex`," +
                                        "`date_of_birth`,`numb_of_house`,`passport`,`id_kod`,`phone_numb`,`status`," +
                                        "`registr`,`m_date`,`mil_ID`,`villagestreetId`)" +
                                    "VALUES(@lastname,@name,@surname,@sex,@date_of_birth,@numb_of_house,@passport," +
                                           "@id_kod,@phone_numb,@status,@registr,@m_date,@mill_ID,@villagestreetId)";
                                    MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());


                                    _command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = textBoxLastName.Text.ToString().Replace("'", "`").Replace('"', '`'); ;
                                    _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxName.Text.ToString().Replace("'", "`").Replace('"', '`');
                                    _command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSurname.Text.ToString().Replace("'", "`").Replace('"', '`');
                                    _command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = comboBoxSex.SelectedItem.ToString();
                                    _command.Parameters.Add("@date_of_birth", MySqlDbType.Date).Value = date_of_birth;
                                    _command.Parameters.Add("@numb_of_house", MySqlDbType.VarChar).Value = textBoxNumbOfHouse.Text;
                                    _command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = textBoxPassport.Text;
                                    _command.Parameters.Add("@id_kod", MySqlDbType.VarChar).Value = textBoxIdKod.Text;
                                    _command.Parameters.Add("@phone_numb", MySqlDbType.VarChar).Value = textBoxPhone.Text;
                                    _command.Parameters.Add("@status", MySqlDbType.VarChar).Value = textBoxStatus.Text;
                                    _command.Parameters.Add("@registr", MySqlDbType.VarChar).Value = comboBoxRegistration.SelectedItem.ToString();
                                    _command.Parameters.Add("@mill_ID", MySqlDbType.VarChar).Value = textBoxMilitaryID.Text;
                                    _command.Parameters.Add("@villagestreetId", MySqlDbType.Int32).Value = villagestreetId;
                                    if (maskedTextBoxChangeDate.Text != "дд.мм.рррр")
                                    {
                                        _command.Parameters.Add("@m_date", MySqlDbType.Date).Value = m_date;;
                                    }

                                    if (_command.ExecuteNonQuery() == 1)
                                        add = true;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Помилка введення дати ! Дату потрібно вводити у форматі - дд.мм.рррр ");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не всі поля заповнені !");
                        return;
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
                if (add)
                {
                    MessageBox.Show("Дані добавлено !");
                    maskedTextBoxChangeDate.Clear();
                    maskedTextBoxDateOfBirth.Clear();
                    textBoxLastName.Text = string.Empty;
                    textBoxName.Text = string.Empty;
                    textBoxSurname.Text = string.Empty;
                    textBoxPassport.Text = string.Empty;
                    textBoxPhone.Text = string.Empty;
                    textBoxStatus.Text = string.Empty;
                    textBoxNumbOfHouse.Text = string.Empty;
                    textBoxIdKod.Text = string.Empty;
                    comboBoxRegistration.SelectedIndex = -1;
                    comboBoxSex.SelectedIndex = -1;
                    comboBoxStreets.Text = "";
                    comboBoxVillage.Text = "";
                    textBoxMilitaryID.Text = "";
                }
                else if (!add && !a)

                    MessageBox.Show("Помилка добавлення даних !");
            }
            else
            {
                MessageBox.Show("Не всі дані заповнено !");
            }

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLastName.Text))
            {
                int cursorPosition = textBoxLastName.SelectionStart;

                string text = textBoxLastName.Text;
                string updatedText = char.ToUpper(text[0]) + text.Substring(1);

                if (text != updatedText)
                {
                    textBoxLastName.Text = updatedText;
                    textBoxLastName.SelectionStart = cursorPosition; // Повернути курсор на місце
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                int cursorPosition = textBoxName.SelectionStart;

                string text = textBoxName.Text;
                string updatedText = char.ToUpper(text[0]) + text.Substring(1);

                if (text != updatedText)
                {
                    textBoxName.Text = updatedText;
                    textBoxName.SelectionStart = cursorPosition; // Повернути курсор на місце
                }
            }
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSurname.Text))
            {
                int cursorPosition = textBoxSurname.SelectionStart;

                string text = textBoxSurname.Text;
                string updatedText = char.ToUpper(text[0]) + text.Substring(1);

                if (text != updatedText)
                {
                    textBoxSurname.Text = updatedText;
                    textBoxSurname.SelectionStart = cursorPosition; // Повернути курсор на місце
                }
            }
        }

        private void maskedTextBoxDateOfBirth_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBoxDateOfBirth.Select(0, 0);
        }

        private void maskedTextBoxChangeDate_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBoxChangeDate.Select(0, 0);
        }
    }
}
