using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Редагувати : Form
    {
        public int _id;
        private ВікноПошуку вікноПошуку;
        VillageStreet villageStreet = new VillageStreet();
        private RowOfData _data = new RowOfData();
        private RowOfData data_1 = new RowOfData();

        public Редагувати(int id, ВікноПошуку вікно)
        {
            InitializeComponent();
            _id = id;
            вікноПошуку = вікно;
            data_1 = _data.GetValueFromDB(id);

            textBoxLastname.Text = data_1.lastname.ToString();
            textBoxName.Text = data_1.name.ToString();
            textBoxSurname.Text = data_1.surname.ToString();
            comboBoxSex.SelectedItem = data_1.sex.ToString().ToLower();
            textBoxBirth.Text = data_1.date_of_birth.ToString().Length > 10 ? data_1.date_of_birth.ToString().Substring(0, 10) : data_1.date_of_birth.ToString();
            comboBoxVillage.Text = data_1.village.ToString();
            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxStreet.Text = data_1.street.ToString();
            textBoxHouse.Text = data_1.numb_of_house.ToString();
            textBoxPassport.Text = data_1.passport.ToString();
            textBoxIdKod.Text = data_1.id_kod.ToString();
            textBoxPhone.Text = data_1.phone_numb.ToString();
            textBoxStatus.Text = data_1.status.ToString();
            comboBoxRegistr.SelectedItem = data_1.registr.ToString().ToLower();
            textBoxMDate.Text = data_1.M_Year.ToString().Length > 10 ? data_1.M_Year.ToString().Substring(0, 10) : data_1.M_Year.ToString();

        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            вікноПошуку.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ConnectionClass _manager = new ConnectionClass();

            bool changed = true;


            if (textBoxLastname.Text != "" &&
                textBoxName.Text != "" &&
                //textBoxSurname.Text != "" &&
                comboBoxSex.SelectedItem.ToString() != "")

            {
                string lastname = textBoxLastname.Text.Replace("'", "`").Replace('"', '`');
                string name = textBoxName.Text.Replace("'", "`").Replace('"', '`');
                string surname = textBoxSurname.Text.Replace("'", "`").Replace('"', '`');
                string sex = comboBoxSex.SelectedItem.ToString();
                string date_of_birth = textBoxBirth.Text;
                string village = comboBoxVillage.Text;
                string street = comboBoxStreet.Text;
                if (comboBoxVillage.SelectedItem != null && 
                    comboBoxStreet.SelectedItem != null)
                {
                    village = comboBoxVillage.SelectedItem.ToString();
                    street = comboBoxStreet.SelectedItem.ToString();
                }
                
                string numb_of_house = textBoxHouse.Text;
                string passport = textBoxPassport.Text;
                string id_kod = textBoxIdKod.Text;
                string phone_numb = textBoxPhone.Text;
                string status = textBoxStatus.Text;
                string registr = comboBoxRegistr.SelectedItem.ToString();
                string M_Year = textBoxMDate.Text;
                int id = _id;

                if (date_of_birth != "" && M_Year != "")
                {
                    try
                    {
                        string s1 = date_of_birth.Substring(0, 2);
                        string s2 = date_of_birth.Substring(3, 2);
                        string s3 = date_of_birth.Substring(6, 4);
                        date_of_birth = s3 + '/' + s2 + '/' + s1;
                        DateTime date_of_birth1 = Convert.ToDateTime(date_of_birth);
                        string s4 = M_Year.Substring(0, 2);
                        string s5 = M_Year.Substring(3, 2);
                        string s6 = M_Year.Substring(6, 4);
                        M_Year = s6 + '/' + s5 + '/' + s4;
                        DateTime M_Year1 = Convert.ToDateTime(M_Year);
                    }
                    catch
                    {
                        MessageBox.Show("Помилка введення дати ! Дату потрібно вводити у форматі - дд.мм.рррр ");
                    }

                    if (Convert.ToDateTime(date_of_birth) > DateTime.Now)
                    {
                        MessageBox.Show("Дата народження не може бути новішою за поточну дату !");
                    }
                    else
                    {
                        string _commandString = "UPDATE people SET lastname = '" + lastname + "', " +
                        "name = '" + name + "', " +
                        "surname = '" + surname + "', " +
                        "sex = '" + sex + "', " +
                        "date_of_birth = '" + date_of_birth + "', " +
                        "village = '" + village + "', " +
                        "street = '" + street + "', " +
                        "numb_of_house = '" + numb_of_house + "', " +
                        "passport = '" + passport + "', " +
                        "id_kod = '" + id_kod + "', " +
                        "phone_numb = '" + phone_numb + "', " +
                        "status = '" + status + "', " +
                        "registr = '" + registr + "', " +
                        "m_date = '" + M_Year + "' " +
                        "WHERE people_id = " + id;

                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                        try
                        {
                            _manager.openConnection();
                            _command.ExecuteNonQuery();

                            if (_command.ExecuteNonQuery() != 1)
                                changed = false;
                        }
                        catch
                        {
                            MessageBox.Show("Помилка роботи з базою даних !!");
                        }
                    }
                }
                else if (date_of_birth != "")
                {
                    try
                    {
                        string s1 = date_of_birth.Substring(0, 2);
                        string s2 = date_of_birth.Substring(3, 2);
                        string s3 = date_of_birth.Substring(6, 4);
                        date_of_birth = s3 + '/' + s2 + '/' + s1;
                        DateTime date_of_birth1 = Convert.ToDateTime(date_of_birth);

                    }
                    catch
                    {
                        MessageBox.Show("Помилка введення дати ! Дату потрібно вводити у форматі - дд.мм.рррр ");
                    }

                    if (Convert.ToDateTime(date_of_birth) > DateTime.Now)
                    {
                        MessageBox.Show("Дата народження не може бути новішою за поточну дату !");

                    }
                    else
                    {

                        string _commandString = "UPDATE people SET lastname = '" + lastname + "', " +
                        "name = '" + name + "', " +
                        "surname = '" + surname + "', " +
                        "sex = '" + sex + "', " +
                        "date_of_birth = '" + date_of_birth + "', " +
                        "village = '" + village + "', " +
                        "street = '" + street + "', " +
                        "numb_of_house = '" + numb_of_house + "', " +
                        "passport = '" + passport + "', " +
                        "id_kod = '" + id_kod + "', " +
                        "phone_numb = '" + phone_numb + "', " +
                        "status = '" + status + "', " +
                        "registr = '" + registr + "', " +
                        "m_date = NULL" +
                        " WHERE people_id = " + id;

                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                        try
                        {
                            _manager.openConnection();
                            _command.ExecuteNonQuery();

                            if (_command.ExecuteNonQuery() != 1)
                                changed = false;
                        }
                        catch
                        {
                            MessageBox.Show("Помилка роботи з базою даних !!");
                        }
                    }
                }
                else if (M_Year != "")
                {
                    try
                    {

                        string s4 = M_Year.Substring(0, 2);
                        string s5 = M_Year.Substring(3, 2);
                        string s6 = M_Year.Substring(6, 4);
                        M_Year = s6 + '/' + s5 + '/' + s4;
                        DateTime M_Year1 = Convert.ToDateTime(M_Year);
                    }
                    catch
                    {
                        MessageBox.Show("Помилка введення дати ! Дату потрібно вводити у форматі - дд.мм.рррр ");
                    }


                    string _commandString = "UPDATE people SET lastname = '" + lastname + "', " +
                    "name = '" + name + "', " +
                    "surname = '" + surname + "', " +
                    "sex = '" + sex + "', " +
                    "date_of_birth = NULL," +
                    "village = '" + village + "', " +
                    "street = '" + street + "', " +
                    "numb_of_house = '" + numb_of_house + "', " +
                    "passport = '" + passport + "', " +
                    "id_kod = '" + id_kod + "', " +
                    "phone_numb = '" + phone_numb + "', " +
                    "status = '" + status + "', " +
                    "registr = '" + registr + "', " +
                    "m_date = '" + M_Year + "'" +
                    "WHERE people_id = " + id;

                    MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                    try
                    {
                        _manager.openConnection();
                        _command.ExecuteNonQuery();

                        if (_command.ExecuteNonQuery() != 1)
                            changed = false;
                    }
                    catch
                    {
                        MessageBox.Show("Помилка роботи з базою даних !!");
                    }

                }

                else
                {

                    string _commandString = "UPDATE people SET lastname = '" + lastname + "', " +
                        "name = '" + name + "', " +
                        "surname = '" + surname + "', " +
                        "sex = '" + sex + "', " +
                        "date_of_birth = NULL ," +
                        "village = '" + village + "', " +
                        "street = '" + street + "', " +
                        "numb_of_house = '" + numb_of_house + "', " +
                        "passport = '" + passport + "', " +
                        "id_kod = '" + id_kod + "', " +
                        "phone_numb = '" + phone_numb + "', " +
                        "status = '" + status + "', " +
                        "registr = '" + registr + "', " +
                        "m_date = NULL " +
                        "WHERE people_id = " + id;

                    MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                    try
                    {
                        _manager.openConnection();
                        _command.ExecuteNonQuery();
                        changed = true;
                    }
                    catch
                    {
                        MessageBox.Show("Помилка роботи з базою даних1 !");
                    }
                    finally
                    {
                        _manager.closeConnection();

                    }
                }
            }
            else
                MessageBox.Show("Не всі поля заповнені !");
            if (changed)
            {
                MessageBox.Show("Дані змінено !");
                this.Close();
                вікноПошуку.Show();
            }
            else
            {
                MessageBox.Show("Дані не змінилится !");
                this.Close();
                вікноПошуку.Show();
            }

            _manager.closeConnection();
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            villageStreet.comboBoxStreetChoose(comboBoxVillage, comboBoxStreet);
        }
    }
}
