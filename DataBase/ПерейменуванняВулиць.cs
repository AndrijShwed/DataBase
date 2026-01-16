using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using DataBase.Repositories;
using System.Drawing;
using System.IO;
using System.Data;

namespace DataBase
{
    public partial class ПерейменуванняВулиць : Form
    {
        private VillageRepository _villageRepo;
        private StreetRepository _streetRepo;
        //private User user;

        public ПерейменуванняВулиць()
        {
            InitializeComponent();
            LoadVillages();
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                LoadStreets(villageId);
            }
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
            
            comboBoxStreet.DisplayMember = "Name";
            comboBoxStreet.ValueMember = "Id";
            comboBoxStreet.DataSource = streets;
            comboBoxStreet.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxStreet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxStreet.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBoxStreet.SelectedIndex = -1;
        }
        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            this.Hide();
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

        private void ЗамінитиІЗберегти_Click(object sender, EventArgs e)
        {
           // user = new User();

           // if (user.userName == "A")
           // {

                string NewName = Convert.ToString(НоваНазва.Text);

                string village = comboBoxVillage.Text;

                string OldName = Convert.ToString(comboBoxStreet.Text);
               
                string imput = maskedTextBoxChangeDate.Text;

                string filePath = textBoxFilePath.Text;
                
                if(!DateTime.TryParseExact(imput, "ddMMyyyy", CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out DateTime changeDate))
                {
                   MessageBox.Show("Невірна дата. Введіть у форматі ДДММРРРР");
                   return;
                }

                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    MessageBox.Show("Оберіть файл для завантаження!");
                    return;
                }

                

                ConnectionClass _manager = new ConnectionClass();
            
                if (OldName == "" || NewName == "" || village == "" || imput.Length < 8)
                {
                    MessageBox.Show("Заповніть будь ласка дані !");
                }
                else
                {
                    RenameStreetInVillage(village, OldName, NewName, filePath, changeDate);
                }

            //}
            //else
            //    MessageBox.Show("У вас немає доступу до зміни даних в таблиці !");
        }

        //Новий метод
        public void RenameStreetInVillage(
            string villageName,
            string oldStreetName,
            string newStreetName,
            string filePath,
            DateTime changeDate)
        {
            ConnectionClass con = new ConnectionClass();
            con.openConnection();

            var conn = con.getConnection();
            var tran = conn.BeginTransaction();
            // Зчитування файлу у байти
            byte[] fileBytes = File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);

            try
            {
                int villageId;
                int oldStreetId;
                int newStreetId;
                int oldvillagestreetId;
               
                // 1. villageId
                using (var cmd = new MySqlCommand(
                    "SELECT id FROM villages WHERE name = @name",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@name", villageName);
                    villageId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. oldStreetId
                using (var cmd = new MySqlCommand(@"
                    SELECT s.id
                    FROM streets s
                    JOIN villagestreet vs ON vs.streetId = s.id
                    WHERE s.name = @streetName
                      AND vs.villageId = @villageId
                      AND vs.IsActive = 1",
                            conn, tran))
                {
                    cmd.Parameters.AddWithValue("@streetName", oldStreetName);
                    cmd.Parameters.AddWithValue("@villageId", villageId);

                    oldStreetId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // oldvillagestreetId
                using (var cmd = new MySqlCommand(@"
                    SELECT Id 
                    FROM villagestreet
                    WHERE villageId = @villageId
                    AND streetId = @streetId
                    AND IsActive = 1
                  LIMIT 1
                  FOR UPDATE;", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@streetId", oldStreetId);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                        throw new Exception("Активний запис вулиці не знайдено");
                    oldvillagestreetId = Convert.ToInt32(result);
                }

                // 3. deactivate old
                using (var cmd = new MySqlCommand(@"
                    UPDATE villagestreet
                    SET IsActive = 0,
                        oldStreetName = @oldStreetName,
                        renameDate = @date
                    WHERE villageId = @villageId
                      AND streetId = @streetId
                      AND IsActive = 1",
                            conn, tran))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@streetId", oldStreetId);
                    cmd.Parameters.AddWithValue("@oldStreetName", oldStreetName);
                    cmd.Parameters.AddWithValue("@date", changeDate);
                    cmd.ExecuteNonQuery();
                }

                // 4. get or create new street
                using (var cmd = new MySqlCommand(
                    "SELECT id FROM streets WHERE name = @name",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@name", newStreetName);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        newStreetId = Convert.ToInt32(result);
                    }
                    else
                    {
                        using (var insert = new MySqlCommand(
                            "INSERT INTO streets (name) VALUES (@name)",
                            conn, tran))
                        {
                            insert.Parameters.AddWithValue("@name", newStreetName);
                            insert.ExecuteNonQuery();
                            newStreetId = (int)insert.LastInsertedId;
                        }
                    }
                }

                // 5. link new
                using (var cmd = new MySqlCommand(@"
                    INSERT INTO villagestreet (villageId, streetId, IsActive, previousvillagestreetId, fileData)
                    VALUES (@villageId, @streetId, 1, @Id, @fileData)",
                            conn, tran))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@streetId", newStreetId);
                    cmd.Parameters.AddWithValue("@Id", oldvillagestreetId);
                    cmd.Parameters.Add("@fileData", MySqlDbType.Blob).Value = fileBytes;
                    cmd.ExecuteNonQuery();
                }

                // 6. Rename street in table people
                using (var cmd = new MySqlCommand(@"
                       UPDATE people SET street = @NewStreetName 
                       WHERE street = @OldName AND village = @village",
                         conn, tran))
                {
                    cmd.Parameters.AddWithValue("@NewStreetName", newStreetName);
                    cmd.Parameters.AddWithValue("@OldName", oldStreetName);
                    cmd.Parameters.AddWithValue("@village", villageName);
                    cmd.ExecuteNonQuery();
                }

                // 7. Rename street in table houses
                using (var cmd = new MySqlCommand(@"
                       UPDATE houses SET street = @NewStreetName 
                       WHERE street = @OldName AND village = @village",
                        conn, tran))
                {
                    cmd.Parameters.AddWithValue("@NewStreetName", newStreetName);
                    cmd.Parameters.AddWithValue("@OldName", oldStreetName);
                    cmd.Parameters.AddWithValue("@village", villageName);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show("Назву вулиці замінено успішно !");
            }
            catch
            {
                tran.Rollback();
                MessageBox.Show("Помилка роботи з базою даних !");
            }
            finally
            {
                con.closeConnection();
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void maskedTextBoxChangeDate_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBoxChangeDate.Select(0, 0);
        }

        private void rjButtonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "All files (*.*)|*.*"; // будь-які файли
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
