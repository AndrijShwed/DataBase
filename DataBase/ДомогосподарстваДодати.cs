using DataBase.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ДомогосподарстваДодати : Form
    {
        private VillageRepository _villageRepo;
        private StreetRepository _streetRepo;
        // private User user;

        int rowNumber = 0;

        public ДомогосподарстваДодати()
        {
            InitializeComponent();
            LoadVillages();
            bool mess = false;
          
        }

        private void LoadVillages()
        {
            ConnectionClass _manager = new ConnectionClass();
            _villageRepo = new VillageRepository(_manager);

            var villages = _villageRepo.GetAllVillages();

            comboBoxVillage.DisplayMember = "Name";
            comboBoxVillage.ValueMember = "Id";
            comboBoxVillage.DataSource = villages;
            comboBoxVillage.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxVillage.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxVillage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            comboBoxVillage.SelectedIndex = -1;
        }

        private void LoadStreets(int villageId)
        {
            ConnectionClass _manager = new ConnectionClass();
            _streetRepo = new StreetRepository(_manager);

            var streets = _streetRepo.GetStreetsInVillage(villageId);

            comboBoxStreets.DisplayMember = "Name";
            comboBoxStreets.ValueMember = "Id";
            comboBoxStreets.DataSource = streets;
            comboBoxStreets.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxStreets.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxStreets.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBoxStreets.SelectedIndex = -1;
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                LoadStreets(villageId);
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
            //user = new User();

            //if (user.userName == "A")
            //{

                //{
                //    rowNumber = 0;
                //    bool a = false;
                //    bool add = false;
                //    int current = 0;

                //    ConnectionClass _manager = new ConnectionClass();
                //    MySqlDataReader _reader;


                //    for (int i = 0; i < rowCount; i++)
                //    {
                //        try
                //        {
                //            _manager.openConnection();


                //            string village = Convert.ToString(this.dataGridViewДомогосподарства.Rows[current].Cells[1].Value);
                //            string street = Convert.ToString(this.dataGridViewДомогосподарства.Rows[current].Cells[2].Value);
                //            string numb = Convert.ToString(this.dataGridViewДомогосподарства.Rows[current].Cells[3].Value);


                //            if (village != "" && street != "" && numb != "")
                //            {

                //                string equal = "SELECT * FROM houses WHERE village = '" + village + "' AND" +
                //                   " street = '" + street + "' AND numb_of_house = '" + numb + "'";

                //                MySqlCommand search = new MySqlCommand(equal, _manager.getConnection());
                //                _reader = search.ExecuteReader();
                //                a = _reader.HasRows;
                //                _reader.Close();

                //                if (a)
                //                {
                //                    current++;

                //                }
                //                else
                //                {
                //                    try
                //                    {
                //                        string _commandString = "INSERT INTO `houses`(`village`,`street`,`numb_of_house`,`lastname`,`name`,`surname`,`totalArea`,`livingArea`,`total_of_rooms`)" +
                //                      "VALUES(@village,@street,@numb_of_house,@lastname,@name,@surname,@totalArea,@livingArea,@total_of_rooms)";
                //                        MySqlCommand _command = new MySqlCommand(_commandString, _manager.getConnection());


                //                        _command.Parameters.Add("@village", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[1].Value;
                //                        _command.Parameters.Add("@street", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[2].Value;
                //                        _command.Parameters.Add("@numb_of_house", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[3].Value;
                //                        _command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[4].Value.ToString().Replace("'", "`").Replace('"', '`');
                //                        _command.Parameters.Add("@name", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[5].Value.ToString().Replace("'", "`").Replace('"', '`');
                //                        _command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[6].Value.ToString().Replace("'", "`").Replace('"', '`');
                //                        _command.Parameters.Add("@totalArea", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[7].Value;
                //                        _command.Parameters.Add("@livingArea", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[8].Value;
                //                        _command.Parameters.Add("@total_of_rooms", MySqlDbType.VarChar).Value = this.dataGridViewДомогосподарства.Rows[current].Cells[9].Value;

                //                        if (_command.ExecuteNonQuery() == 1)
                //                            add = true;

                //                        dataGridViewДомогосподарства.Rows.RemoveAt(current);

                //                    }
                //                    catch
                //                    {
                //                        MessageBox.Show("Помилка ! ");
                //                    }

                //                }

                //            }
                //            else
                //            {
                //                MessageBox.Show("Не всі поля заповнені !");
                //                return;
                //            }

                //        }
                //        catch
                //        {
                //            MessageBox.Show("Помилка роботи з базою даних !");
                //        }

                //        finally
                //        {
                //            _manager.closeConnection();
                //        }
                //        if (add && (i == rowCount - 1))
                //        {
                //            MessageBox.Show("Дані добавлено !");

                //        }
                //        else if (!add && (i == rowCount - 1) && !a)

                //            MessageBox.Show("Помилка добавлення даних !");

                //        if (a && dataGridViewДомогосподарства.Rows.Count > 0 && (i == rowCount - 1))

                //            MessageBox.Show("Такий запис вже існує !");

                //    }
                //}
            //}
            //else
            //{
            //    MessageBox.Show("У вас немає доступу до бази даних");
            //}
        }

        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            this.Hide();
            form.Show();
        }
    }
}
