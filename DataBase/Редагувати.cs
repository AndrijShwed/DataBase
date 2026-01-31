using DataBase.Repositories;
using DataBase.Services;
using DocumentFormat.OpenXml.Office2013.Word;
using MySqlConnector;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Редагувати : Form
    {
        public int _id;
        private ВікноПошуку вікноПошуку;
        private VillageStreetRepository _villageStreetRepo = new VillageStreetRepository();
        private RowOfData _data = new RowOfData();
        private RowOfData data_1 = new RowOfData();
        AddressService service = new AddressService();

        public Редагувати(int id, ВікноПошуку вікно)
        {
            InitializeComponent();
            
            _id = id;
            вікноПошуку = вікно;
            AddressIds ids = new AddressIds();
            int villageId = ids.GetAddressByPeopleId(_id).villageId;
            int streetId = ids.GetAddressByPeopleId(_id).streetId;
            service.LoadVillages(comboBoxVillage);
            comboBoxVillage.SelectedValue = villageId;
            service.LoadStreets(comboBoxStreet, villageId);
            comboBoxStreet.SelectedValue = streetId;

            вікноПошуку = вікно;
            data_1 = _data.GetValueFromDB(id);

            textBoxLastname.Text = data_1.lastname.ToString();
            textBoxName.Text = data_1.name.ToString();
            textBoxSurname.Text = data_1.surname.ToString();
            comboBoxSex.SelectedItem = data_1.sex.ToString().ToLower();
            DateTime birthDate = Convert.ToDateTime(data_1.date_of_birth);
            maskedTextBoxBirthDate.Text = birthDate.ToString("dd.MM.yyyy");
            textBoxHouse.Text = data_1.numb_of_house.ToString();
            textBoxIdKod.Text = data_1.id_kod.ToString();
            textBoxPhone.Text = data_1.phone_numb.ToString();
            textBoxStatus.Text = data_1.status.ToString();
            comboBoxRegistr.SelectedItem = data_1.registr.ToString().ToLower();
            DateTime M_Year = Convert.ToDateTime(data_1.M_Year);
            maskedTextBoxM_Year.Text = M_Year.ToString("dd.MM.yyyy");
            richTextBoxPassport.Text = data_1.passport.ToString();
            textBoxВійськовийID.Text = data_1.Mil_ID.ToString();
           
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                service.LoadStreets(comboBoxStreet, villageId);
            }
        }
        
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Program.OpenForm(this, вікноПошуку);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (ConnectionClass _manager = new ConnectionClass())
            {
                _manager.openConnection();

                bool changed = true;


                if (!string.IsNullOrWhiteSpace(textBoxLastname.Text) &&
                    !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                     comboBoxSex.SelectedItem != null)
                {
                    string lastname = textBoxLastname.Text.Replace("'", "`").Replace('"', '`');
                    string name = textBoxName.Text.Replace("'", "`").Replace('"', '`');
                    string surname = textBoxSurname.Text.Replace("'", "`").Replace('"', '`');
                    string sex = comboBoxSex.SelectedItem.ToString();

                    if (!TryParseMaskedDate(maskedTextBoxBirthDate, out DateTime birthDate, "дату народження")) return;
                    if (!TryParseMaskedDate(maskedTextBoxM_Year, out DateTime M_Year, "дату внесення змін")) return;

                    string village = comboBoxVillage.Text;
                    string street = comboBoxStreet.Text;
                    if (comboBoxVillage.SelectedItem != null &&
                        comboBoxStreet.SelectedItem != null)
                    {
                        village = comboBoxVillage.SelectedItem.ToString();
                        street = comboBoxStreet.SelectedItem.ToString();
                    }

                    string numb_of_house = textBoxHouse.Text;
                    string passport = richTextBoxPassport.Text;
                    string id_kod = textBoxIdKod.Text;
                    string phone_numb = textBoxPhone.Text;
                    string status = textBoxStatus.Text;
                    string registr = comboBoxRegistr.SelectedItem.ToString();

                    string Mil_ID = textBoxВійськовийID.Text.Trim();
                    if (Mil_ID.Length != 0 && Mil_ID.Length != 21)
                    {
                        MessageBox.Show("Поле 'Військовий ID' повинно містити рівно 21 символ.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    var village1 = comboBoxVillage.SelectedItem as Village;
                    if (village1 == null)
                    {
                        MessageBox.Show("Оберіть населений пункт!");
                        return;
                    }
                    int villageId = village1.Id;

                    var street1 = comboBoxStreet.SelectedItem as Street;
                    if (street1 == null)
                    {
                        MessageBox.Show("Вкажіть вулицю!");
                        return;
                    }
                    int streetId = street1.Id;

                    int villagestreetId = _villageStreetRepo.GetVillageStreetId(villageId, streetId, _manager.getConnection());

                    string _commandString = @"
                            UPDATE people SET 
                                lastname = @lastname,
                                name = @name,
                                surname = @surname,
                                sex = @sex,
                                date_of_birth = @date_of_birth,
                                numb_of_house = @numb_of_house,
                                passport = @passport,
                                id_kod = @id_kod,
                                phone_numb = @phone_numb,
                                status = @status,
                                registr = @registr,
                                m_date = @M_Year,
                                mil_ID = @Mil_ID,
                                villagestreetId = @villagestreetId
                            WHERE people_id = @id";

                    using (MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection()))
                    {
                        _command.Parameters.AddWithValue("@lastname", lastname);
                        _command.Parameters.AddWithValue("@name", name);
                        _command.Parameters.AddWithValue("@surname", surname);
                        _command.Parameters.AddWithValue("@sex", sex);
                        _command.Parameters.AddWithValue("@date_of_birth", birthDate);
                        _command.Parameters.AddWithValue("@numb_of_house", numb_of_house);
                        _command.Parameters.AddWithValue("@passport", passport);
                        _command.Parameters.AddWithValue("@id_kod", id_kod);
                        _command.Parameters.AddWithValue("@phone_numb", phone_numb);
                        _command.Parameters.AddWithValue("@status", status);
                        _command.Parameters.AddWithValue("@registr", registr);
                        _command.Parameters.AddWithValue("@M_Year", M_Year);
                        _command.Parameters.AddWithValue("@Mil_ID", Mil_ID);
                        _command.Parameters.AddWithValue("@villagestreetId", villagestreetId);
                        _command.Parameters.AddWithValue("@id", _id); // твій id запису

                        try
                        {
                            int rows = _command.ExecuteNonQuery();

                            if (rows != 1)
                                changed = false;
                        }
                        catch
                        {
                            MessageBox.Show("Помилка роботи з базою даних !!");
                        }
                    }
                }
                else
                    MessageBox.Show("Не всі поля заповнені !");
                MessageBox.Show(changed ? "Дані змінено!" : "Дані не змінено!");
                this.Close();
                вікноПошуку.Show();

            }
        }

        private bool TryParseMaskedDate(MaskedTextBox maskBox, out DateTime result, string fieldName)
        {
            result = DateTime.MinValue;
            maskBox.TextMaskFormat = MaskFormat.IncludeLiterals;

            if (!maskBox.MaskCompleted)
            {
                MessageBox.Show($"Введіть {fieldName}!");
                maskBox.Focus();
                return false;
            }

            if (!DateTime.TryParseExact(maskBox.Text.Replace(',', '.'), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                MessageBox.Show($"{fieldName} введено неправильно!");
                maskBox.Focus();
                return false;
            }

            if (result > DateTime.Today)
            {
                MessageBox.Show($"{fieldName} не може бути в майбутньому!");
                maskBox.Focus();
                return false;
            }

            return true;
        }



        private void textBoxLastname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLastname.Text))
            {
                int cursorPosition = textBoxLastname.SelectionStart;

                string text = textBoxLastname.Text;
                string updatedText = char.ToUpper(text[0]) + text.Substring(1);

                if (text != updatedText)
                {
                    textBoxLastname.Text = updatedText;
                    textBoxLastname.SelectionStart = cursorPosition; // Повернути курсор на місце
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

        private void maskedTextBoxBirthDate_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBoxBirthDate.Select(11, 10);
        }

        private void maskedTextBoxM_Date_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBoxM_Year.Select(11, 10);
        }
    }
}
