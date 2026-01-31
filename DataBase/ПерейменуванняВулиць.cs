using DataBase.Repositories;
using DataBase.Services;
using MySqlConnector;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ПерейменуванняВулиць : Form
    {
        AddressService service = new AddressService();
        //private User user;

        public ПерейменуванняВулиць()
        {
            InitializeComponent();
            service.LoadVillages(comboBoxVillage);
        }

        private void comboBoxVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVillage.SelectedValue is int villageId)
            {
                service.LoadStreets(comboBoxStreet, villageId);
            }
        }
       
        private void населенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Населення form = new Населення();
            Program.OpenForm(this, form);
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

                

                //ConnectionClass _manager = new ConnectionClass();
            
                if (OldName == "" || NewName == "" || village == "" || imput.Length < 8)
                {
                    MessageBox.Show("Заповніть будь ласка дані !");
                }
                else
                {
                    RenameStreetInVillage(village, OldName, NewName, filePath, changeDate);
                }
                ПочатокРоботи form = new ПочатокРоботи();
                this.Close();
                form.Show();

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
                //int oldvillagestreetId;
               
                // 1. villageId
                using (var cmd = new MySqlCommand(
                    "SELECT id FROM villages WHERE name = @name",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@name", villageName);
                    object result = cmd.ExecuteScalar();

                    if (!int.TryParse(result?.ToString(), out villageId))
                    {
                        throw new Exception("Не вдалося отримати ID села.");
                    }
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

                // 3. rename street in villagestreet
                using (var cmd = new MySqlCommand(@"
                    UPDATE villagestreet
                    SET streetId = @newstreetId,
                        oldStreetId = @oldStreetId,
                        renameDate = @date,
                        fileData = @fileData
                    WHERE villageId = @villageId AND streetId = @oldstreetId",
                            conn, tran))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@newstreetId", newStreetId);
                    cmd.Parameters.AddWithValue("@oldStreetId", oldStreetId);
                    cmd.Parameters.AddWithValue("@date", changeDate);
                    cmd.Parameters.Add("@fileData", MySqlDbType.Blob).Value = fileBytes;
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
                openFileDialog.Filter = "Документи (Word, PDF, скани)|*.doc;*.docx;*.pdf;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
