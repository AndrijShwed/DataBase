using DataBase.Repositories;
using DataBase.Services;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class EnterpriseAdd : Form
    {
        private VillageStreetRepository _villageStreetRepo = new VillageStreetRepository();
        AddressService service = new AddressService();
        public EnterpriseAdd()
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
        private void земляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enterprises form = new Enterprises();
            this.Close();
            form.Show();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            {
                bool a = false;
                bool add = false;

                ConnectionClass _manager = new ConnectionClass();
                MySqlDataReader _reader;

                if (textBoxEnterpriseName.Text == "" )
                {
                    MessageBox.Show("Не заповнено поле назва підприємства");
                    return;
                }

                string PIP = textBoxOwnerName.Text;
                var village = comboBoxVillage.SelectedItem as Village;
                var street = comboBoxStreets.SelectedItem as Street;
                string houseNumb = textBoxHouseNumb.Text;
                string employesCount = textBoxEmployeesCount.Text;
                string enterpriseName = textBoxEnterpriseName.Text;
               
                try
                {
                    _manager.openConnection();

                    if (enterpriseName!= null)
                    {
                        string equal = "SELECT * FROM enterprises WHERE name = @enterpriseName";

                        MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                        search.Parameters.AddWithValue("@enterpriseName", enterpriseName);
                        _reader = search.ExecuteReader();
                        a = _reader.HasRows;
                        _reader.Close();

                        if (a)
                        {
                            MessageBox.Show("Підприємство з такою назвою уже є втаблиці !!!");
                            return;
                        }

                    }
                    if (village != null && street != null && houseNumb != null)
                    {
                        string equal = "SELECT * FROM enterprises e" +
                            " JOIN villagestreet vs ON e.villagestreetId = vs.id" +
                            " JOIN villages v ON vs.villageId = v.id" +
                            " JOIN streets s ON vs.streetId = s.id" +
                             " WHERE housenumber = @houseNumber";

                        MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                        search.Parameters.AddWithValue("@houseNumb", houseNumb);
                        _reader = search.ExecuteReader();
                        a = _reader.HasRows;
                        _reader.Close();

                        if (a)
                        {
                            MessageBox.Show("По даній адресі уже є підприємство !!!");
                            return;
                        }
                    }

                    
                    if (village == null)
                    {
                        MessageBox.Show("Оберіть населений пункт !");
                        return;
                    }
                    int villageId = village.Id;

                    if (street == null)
                    {
                        MessageBox.Show("Вкажіть вулицю !");
                        return;
                    }
                    int streetId = street.Id;
                    int villagestreetId = _villageStreetRepo.GetVillageStreetId(villageId, streetId, _manager.getConnection());


                    string _commandString = "INSERT INTO `berezhnytsya`.`enterprises` (name, owner, villagestreetId, " +
                                          "employeesnumber, housenumber) VALUES(@name, @owner, @villagestreetId, " +
                                          "@employeesnumber, @housenumber)";

                    MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());

                    _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxEnterpriseName.Text.ToString().Replace("'", "`").Replace('"', '`');
                    _command.Parameters.Add("@owner", MySqlDbType.VarChar).Value = textBoxOwnerName.Text.ToString();
                    _command.Parameters.Add("@villagestreetId", MySqlDbType.VarChar).Value = villagestreetId;
                    _command.Parameters.Add("@employeesnumber", MySqlDbType.VarChar).Value = textBoxEmployeesCount.Text.ToString();
                    _command.Parameters.Add("@housenumber", MySqlDbType.VarChar).Value = textBoxHouseNumb.Text.ToString();
                    

                    if (_command.ExecuteNonQuery() == 1)
                        add = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    _manager.closeConnection();
                }
                if (add)
                {
                    MessageBox.Show("Дані добавлено !");
                    textBoxOwnerName.Text = string.Empty;
                    comboBoxVillage.Text = "Виберіть населений пункт";
                    comboBoxStreets.Text = string.Empty;
                    textBoxHouseNumb.Text = string.Empty;
                    textBoxEmployeesCount.Text = string.Empty;
                    textBoxEnterpriseName.Text = string.Empty;
                }
                else

                    MessageBox.Show("Помилка добавлення даних !");
            }
        }

        
    }
}
