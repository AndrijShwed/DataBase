using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace DataBase
{
    public partial class ПерейменуванняВулиць : Form
    {
        private List<Village> dataVillage = new List<Village>();
        private List<Street> dataStreet = new List<Street>();
        //private User user;

        public ПерейменуванняВулиць()
        {
            InitializeComponent();
            bool mess = false;
            dataVillage.Clear();
            comboBoxНаселенийПункт.Items.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT * FROM villages";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                Village row = new Village(_reader["name"].ToString());
                dataVillage.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < dataVillage.Count; i++)
            {
                AddDataGrid(dataVillage[i]);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Помилка роботи з базою даних !");
            }
            _manager.closeConnection();

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

                string village = comboBoxНаселенийПункт.Text;

                string OldName = Convert.ToString(comboBoxСтараНазваВулиці.Text);
               
                string imput = maskedTextBoxChangeDate.Text;
                
                if(!DateTime.TryParseExact(imput, "ddMMyyyy", CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out DateTime changeDate))
                {
                   MessageBox.Show("Невірна дата. Введіть у форматі ДДММРРРР");
                   return;
                }

                ConnectionClass _manager = new ConnectionClass();
            
                if (OldName == "" || NewName == "" || village == "" || imput.Length < 8)
                {
                    MessageBox.Show("Заповніть будь ласка дані !");
                }
                else
                {
                    RenameStreetInVillage(village, OldName, NewName, changeDate);
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
            DateTime changeDate)
        {
            ConnectionClass con = new ConnectionClass();
            con.openConnection();

            var conn = con.getConnection();
            var tran = conn.BeginTransaction();

            try
            {
                int villageId;
                int oldStreetId;
                int newStreetId;

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

                // 3. deactivate old
                using (var cmd = new MySqlCommand(@"
                    UPDATE villagestreet
                    SET IsActive = 0,
                        renameDate = @date
                    WHERE villageId = @villageId
                      AND streetId = @streetId",
                            conn, tran))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@streetId", oldStreetId);
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
                    INSERT INTO villagestreet (villageId, streetId, IsActive)
                    VALUES (@villageId, @streetId, 1)",
                            conn, tran))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@streetId", newStreetId);
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



        private void AddDataGrid(Village row)
        {
            comboBoxНаселенийПункт.Items.Add(row.Name);
        }


        private void AddDataGrid_1(Street row)
        {
            comboBoxСтараНазваВулиці.Items.Add(row.Name);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void comboBoxНаселенийПункт_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxСтараНазваВулиці.Items.Clear();
            dataStreet.Clear();
            bool mess = false;
            string village = comboBoxНаселенийПункт.Text;

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT s.id, s.name FROM streets s JOIN villagestreet ss ON ss.streetId = s.id" +
                " JOIN villages st ON st.id = villageId WHERE st.name = '" + village + "' AND ss.isActive = 1 ORDER BY s.name";
            MySqlCommand _search1 = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search1.ExecuteReader();

            while (_reader.Read())
            {
                Street row = new Street(_reader["name"].ToString());
                dataStreet.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < dataStreet.Count; i++)
            {
                AddDataGrid_1(dataStreet[i]);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Помилка роботи з базою даних  !");
            }
            _manager.closeConnection();
        }

        private void maskedTextBoxChangeDate_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBoxChangeDate.Select(0, 0);
        }
    }
}
