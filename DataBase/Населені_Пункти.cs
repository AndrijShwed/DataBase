using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace DataBase
{
    public partial class Населені_Пункти : Form
    {
        //private User user;
        List<RowOfVillage> _data = new List<RowOfVillage>();
        List<Village> dataVillage = new List<Village>();
        List<Street> dataStreet = new List<Street>();

        public Населені_Пункти()
        {
            InitializeComponent();
            HeaderOfTheTable();
        }

        private void HeaderOfTheTable()
        {
            dataVillage.Clear();

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
            _manager.closeConnection();

            this.dataGridViewНаселені_Пункти.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewНаселені_Пункти.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewНаселені_Пункти.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewНаселені_Пункти.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewНаселені_Пункти.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewНаселені_Пункти.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            this.dataGridViewНаселені_Пункти.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Рік";
            column1.Width = 120;
            column1.Name = "year";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            List<DataGridViewColumn> col = new List<DataGridViewColumn>();
            int i;
            for ( i = 2; i < dataVillage.Count + 2; i++)
            {
                var columni = new DataGridViewColumn();
                columni.HeaderText = dataVillage[i - 2].Name.ToString();
                columni.Width = 120;
                columni.Name = dataVillage[i - 2].Name.ToString();
                columni.Frozen = true;
                columni.CellTemplate = new DataGridViewTextBoxCell();
                col.Add(columni);
            }

            var columnk = new DataGridViewColumn();
            columnk.HeaderText = "Всього";
            columnk.Width = 120;
            columnk.Name = "all";
            columnk.Frozen = true;
            columnk.DefaultCellStyle.Format = "d";
            columnk.CellTemplate = new DataGridViewTextBoxCell();


            dataGridViewНаселені_Пункти.Columns.Add(column1);
           
            for ( i = 0; i < col.Count; i++)
            {
                dataGridViewНаселені_Пункти.Columns.Add(col[i]);
            }

            dataGridViewНаселені_Пункти.Columns.Add(columnk);


            dataGridViewНаселені_Пункти.AllowUserToAddRows = false;
            dataGridViewНаселені_Пункти.ReadOnly = true;
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

        private void ButtonПовернутись_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            Program.OpenForm(this, form);
        }

        //private void buttonОновити_Click(object sender, EventArgs e)
        //{
        //    dataGridViewНаселені_Пункти.DataSource = null;
        //    dataGridViewНаселені_Пункти.Rows.Clear();
        //    _data.Clear();

        //    //user = new User();

        //    ConnectionClass _manager = new ConnectionClass();

        //    _manager.openConnection();

        //    List<string> count_v = new List<string>();
        //    this.dataGridViewНаселені_Пункти.Rows.Add();

        //    for (int i = 0; i < dataVillage.Count; i++)
        //    {
        //        string count1 = @"
        //            SELECT COUNT(*) 
        //            FROM people p
        //            JOIN villagestreet vs ON p.villagestreetId = vs.id
        //            JOIN villages v ON vs.villageId = v.id
        //            WHERE v.name = @name AND registr = 'так'";
        //        count_v.Add(count1);
        //    }


        //    int all = 0;
        //    int sum;
        //    List<int> sum_v = new List<int>();
        //    for (int i = 0; i < dataVillage.Count; i++)
        //    {
        //        MySqlCommand search = new MySqlCommand(count_v[i], _manager.getConnection());
        //        search.Parameters.AddWithValue("@name", dataVillage[i].Name);

        //        object result = search.ExecuteScalar();
        //        sum = (result == null) ? 0 : Convert.ToInt32(result);

        //        all += sum;
        //        sum_v.Add(sum);
        //    }

        //    dataGridViewНаселені_Пункти.Rows[0].Cells[0].Value = Convert.ToInt32(DateTime.Now.Year.ToString());
        //    for (int i = 0; i < dataVillage.Count; i++)
        //    {
        //        dataGridViewНаселені_Пункти.Rows[0].Cells[i + 1].Value = sum_v[i];
        //    }

        //    dataGridViewНаселені_Пункти.Rows[0].Cells[dataVillage.Count + 1].Value = all;

        //}

        //private void buttonОновити_Click(object sender, EventArgs e)
        //{
        //    dataGridViewНаселені_Пункти.DataSource = null;
        //    dataGridViewНаселені_Пункти.Rows.Clear();
        //    _data.Clear();

        //    ConnectionClass _manager = new ConnectionClass();
        //    _manager.openConnection();

        //    // ОДИН SQL ЗАПИТ ЗАМІСТЬ ЦИКЛУ
        //    string query = @"
        //                SELECT 
        //                    v.name,
        //                    COUNT(p.people_id) AS cnt
        //                FROM villages v
        //                LEFT JOIN villagestreet vs ON vs.villageId = v.id
        //                LEFT JOIN people p 
        //                    ON p.villagestreetId = vs.id 
        //                    AND p.registr = 'так'
        //                GROUP BY v.id, v.name";

        //    MySqlCommand cmd = new MySqlCommand(query, _manager.getConnection());
        //    MySqlDataReader reader = cmd.ExecuteReader();

        //    int all = 0;

        //    // додаємо один рядок у грід
        //    dataGridViewНаселені_Пункти.Rows.Add();

        //    int col = 1; // 0 колонка = рік

        //    while (reader.Read())
        //    {
        //        int count = Convert.ToInt32(reader["cnt"]);
        //        string name = reader["name"].ToString();

        //        all += count;

        //        dataGridViewНаселені_Пункти.Rows[0].Cells[col].Value = count;
        //        col++;
        //    }

        //    reader.Close();
        //    _manager.closeConnection();

        //    // рік
        //    dataGridViewНаселені_Пункти.Rows[0].Cells[0].Value = DateTime.Now.Year;

        //    // загальна сума
        //    dataGridViewНаселені_Пункти.Rows[0].Cells[col].Value = all;
        //}

        private void buttonОновити_Click(object sender, EventArgs e)
        {
            dataGridViewНаселені_Пункти.DataSource = null;
            dataGridViewНаселені_Пункти.Rows.Clear();
            _data.Clear();

            ConnectionClass _manager = new ConnectionClass();
            _manager.openConnection();

            MySqlConnection conn = _manager.getConnection();

            // =========================
            // 📊 1. ІСТОРІЯ SNAPSHOT
            // =========================
            string snapQuery = @"
                        SELECT 
                            year,
                            settlement_name,
                            population
                        FROM population_snapshot
                        ORDER BY year";

            MySqlCommand snapCmd = new MySqlCommand(snapQuery, conn);
            MySqlDataReader snapReader = snapCmd.ExecuteReader();

            // структура: year -> (name -> value)
            Dictionary<int, Dictionary<string, int>> data = new Dictionary<int, Dictionary<string, int>>();
            HashSet<string> villages = new HashSet<string>();

            while (snapReader.Read())
            {
                int year = Convert.ToInt32(snapReader["year"]);
                string name = snapReader["settlement_name"].ToString();
                int pop = Convert.ToInt32(snapReader["population"]);

                villages.Add(name);

                if (!data.ContainsKey(year))
                    data[year] = new Dictionary<string, int>();

                data[year][name] = pop;
            }

            snapReader.Close();

            // =========================
            // ⚡ 2. ПОТОЧНЕ НАСЕЛЕННЯ
            // =========================
            string currentQuery = @"
                    SELECT 
                        v.name,
                        COUNT(p.people_id) AS cnt
                    FROM villages v
                    LEFT JOIN villagestreet vs ON vs.villageId = v.id
                    LEFT JOIN people p 
                        ON p.villagestreetId = vs.id 
                        AND p.registr = 'так'
                    GROUP BY v.id, v.name";

            MySqlCommand cmd = new MySqlCommand(currentQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            Dictionary<string, int> current = new Dictionary<string, int>();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                int cnt = Convert.ToInt32(reader["cnt"]);

                current[name] = cnt;
                villages.Add(name);
            }

            reader.Close();

            _manager.closeConnection();

            // =========================
            // 🧱 3. БУДУЄМО ТАБЛИЦЮ
            // =========================

            dataGridViewНаселені_Пункти.Rows.Add();

            int col = 1;

            // 📌 додаємо snapshot роки
            foreach (var year in data.Keys.OrderBy(x => x))
            {
                dataGridViewНаселені_Пункти.Rows.Add();

                dataGridViewНаселені_Пункти.Rows[col].Cells[0].Value = year;

                int villageIndex = 1;
                int total = 0;

                foreach (var v in villages)
                {
                    int value = data[year].ContainsKey(v) ? data[year][v] : 0;

                    dataGridViewНаселені_Пункти.Rows[col].Cells[villageIndex].Value = value;
                    total += value;
                    villageIndex++;
                }

                dataGridViewНаселені_Пункти.Rows[col].Cells[villageIndex].Value = total;
                col++;
            }

            // =========================
            // ⚡ 4. АКТУАЛЬНИЙ РЯДОК
            // =========================

            dataGridViewНаселені_Пункти.Rows.Add();

            int lastRow = col;

            dataGridViewНаселені_Пункти.Rows[lastRow].Cells[0].Value = "Поточний";

            int i = 1;
            int all = 0;

            foreach (var v in villages)
            {
                int val = current.ContainsKey(v) ? current[v] : 0;

                dataGridViewНаселені_Пункти.Rows[lastRow].Cells[i].Value = val;
                all += val;
                i++;
            }

            dataGridViewНаселені_Пункти.Rows[lastRow].Cells[i].Value = all;
        }


        private void buttonВихідЗПрограми_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonsnapShot_Click(object sender, EventArgs e)
        {
            ConnectionClass _manager = new ConnectionClass();
            _manager.openConnection();

            MySqlConnection conn = _manager.getConnection();

            try
            {
                // 🔒 БЛОКУВАННЯ (захист від паралельних запусків)
                MySqlCommand lockCmd = new MySqlCommand("SELECT GET_LOCK('snapshot_lock', 10);", conn);
                object lockResult = lockCmd.ExecuteScalar();

                if (lockResult == null || Convert.ToInt32(lockResult) != 1)
                {
                    MessageBox.Show("Не вдалося отримати блокування. Спробуйте ще раз.");
                    return;
                }

                int year = DateTime.Now.Year;

                // 📊 основний запит
                string query = @"
                                SELECT 
                                    v.name,
                                    COUNT(*) AS cnt
                                FROM villages v
                                LEFT JOIN villagestreet vs ON vs.villageId = v.id
                                LEFT JOIN people p 
                                    ON p.villagestreetId = vs.id 
                                    AND p.registr = 'так'
                                GROUP BY v.id, v.name";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<(string name, int count)> data = new List<(string, int)>();

                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    int count = Convert.ToInt32(reader["cnt"]);
                    data.Add((name, count));
                }

                reader.Close();

                // 💾 запис snapshot
                foreach (var item in data)
                {
                    string insert = @"
                                INSERT INTO population_snapshot (settlement_name, year, population)
                                VALUES (@name, @year, @pop)
                                ON DUPLICATE KEY UPDATE population = VALUES(population)";

                    MySqlCommand insertCmd = new MySqlCommand(insert, conn);
                    insertCmd.Parameters.AddWithValue("@name", item.name);
                    insertCmd.Parameters.AddWithValue("@year", year);
                    insertCmd.Parameters.AddWithValue("@pop", item.count);

                    insertCmd.ExecuteNonQuery();
                }

                // 🔓 зняття блокування
                MySqlCommand unlockCmd = new MySqlCommand("SELECT RELEASE_LOCK('snapshot_lock');", conn);
                unlockCmd.ExecuteNonQuery();

                MessageBox.Show("Snapshot успішно створено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
            finally
            {
                _manager.closeConnection();
            }
        }
    }
}  
