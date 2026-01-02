using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Додати : Form
    {
        VillageStreet villageStreet = new VillageStreet();
       
       // private User user;

        public Додати()
        {
            InitializeComponent();

            comboBoxVillage.Items.Clear();
            villageStreet.ComboBoxVillageFill(comboBoxVillage);
            comboBoxVillage.Text = "Виберіть населений пункт";
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
            this.Hide();
            form.Show();
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonПовернутись_Click_1(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
            form.Show();
        }

        
        //private void переглядДанихToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ВивідДаних form = new ВивідДаних();
        //    this.Hide();
        //    form.Show();
        //}

        
        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            villageStreet.comboBoxStreetChoose(comboBoxVillage, comboBoxStreets);
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
                comboBoxVillage.SelectedItem != null &&
                comboBoxStreets.SelectedItem != null &&
                textBoxNumbOfHouse.Text != "" && 
                textBoxDateOfBirth.Text != "дд.мм.рррр")
            {

                try 
                {
                    _manager.openConnection();

                    string lastname = textBoxLastName.Text.ToString().Replace("'", "`").Replace('"', '`');
                    string name = textBoxName.Text.ToString().Replace("'", "`").Replace('"', '`');
                    string surname = textBoxSurname.Text.ToString().Replace("'", "`").Replace('"', '`');
                    string sex = comboBoxSex.SelectedItem.ToString();
                    string date_of_birth = textBoxDateOfBirth.Text;
                    string m_date = textBoxChangeDate.Text;
                    string registr = comboBoxRegistration.SelectedItem.ToString();

                    string s1 = date_of_birth.Substring(0, 2);
                    string s2 = date_of_birth.Substring(3, 2);
                    string s3 = date_of_birth.Substring(6, 4);
                    string s4 = m_date.Substring(0, 2);
                    string s5 = m_date.Substring(3, 2);
                    string s6 = m_date.Substring(6, 4);

                    if (lastname != "" && name != "" && sex != "" && date_of_birth != "дд.мм.рррр" && registr != "")
                    {
                        date_of_birth = s3 + "-" + s2 + "-" + s1;
                        string equal = "SELECT * FROM people WHERE lastname = '" + lastname + "' AND" +
                            " name = '" + name + "' AND surname = '" + surname + "' AND " +
                                "date_of_birth = '" + date_of_birth + "'";

                        MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
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
                                m_date = s6 + '/' + s5 + '/' + s4;
                                DateTime m_date1 = Convert.ToDateTime(m_date);

                                date_of_birth = s3 + '/' + s2 + '/' + s1;
                                DateTime date_of_birth1 = Convert.ToDateTime(date_of_birth);
                                if (date_of_birth1 > DateTime.Now || m_date1 > DateTime.Now)
                                {
                                    MessageBox.Show("Дата народження або дата зміни статусу не може бути новішою за поточну дату !");
                                }
                                else
                                {

                                    string _commandString = "INSERT INTO `people`(`lastname`,`name`,`surname`,`sex`,`date_of_birth`,`village`,`street`,`numb_of_house`,`passport`,`id_kod`,`phone_numb`,`status`,`registr`,`m_date`)" +
                                    "VALUES(@lastname,@name,@surname,@sex,@date_of_birth,@village,@street,@numb_of_house,@passport,@id_kod,@phone_numb,@status,@registr,@m_date)";
                                    MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());


                                    _command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = textBoxLastName.Text.ToString().Replace("'", "`").Replace('"', '`'); ;
                                    _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxName.Text.ToString().Replace("'", "`").Replace('"', '`');
                                    _command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSurname.Text.ToString().Replace("'", "`").Replace('"', '`');
                                    _command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = comboBoxSex.SelectedItem.ToString();
                                    _command.Parameters.Add("@date_of_birth", MySqlDbType.VarChar).Value = date_of_birth;
                                    _command.Parameters.Add("@village", MySqlDbType.VarChar).Value = comboBoxVillage.SelectedItem.ToString();
                                    _command.Parameters.Add("@street", MySqlDbType.VarChar).Value = comboBoxStreets.SelectedItem.ToString();
                                    _command.Parameters.Add("@numb_of_house", MySqlDbType.VarChar).Value = textBoxNumbOfHouse.Text;
                                    _command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = textBoxPassport.Text;
                                    _command.Parameters.Add("@id_kod", MySqlDbType.VarChar).Value = textBoxIdKod.Text;
                                    _command.Parameters.Add("@phone_numb", MySqlDbType.VarChar).Value = textBoxPhone.Text;
                                    _command.Parameters.Add("@status", MySqlDbType.VarChar).Value = textBoxStatus.Text;
                                    _command.Parameters.Add("@registr", MySqlDbType.VarChar).Value = comboBoxRegistration.SelectedItem.ToString();
                                    if (m_date != "дд.мм.рррр")
                                    {
                                        _command.Parameters.Add("@m_date", MySqlDbType.VarChar).Value = m_date;
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
                    textBoxChangeDate.Text = "дд.мм.рррр";
                    textBoxDateOfBirth.Text = "дд.мм.рррр";
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
                    comboBoxStreets.SelectedIndex = -1;
                    comboBoxVillage.Text = "Виберіть населений пункт";
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
    }
}
