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

            string reader = "SELECT * FROM village";
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
            this.Close();
            form.Show();
        }

        private void buttonОновити_Click(object sender, EventArgs e)
        {
            dataGridViewНаселені_Пункти.DataSource = null;
            dataGridViewНаселені_Пункти.Rows.Clear();
            _data.Clear();

            //user = new User();

            ConnectionClass _manager = new ConnectionClass();
            
            _manager.openConnection();

            List<string> count_v = new List<string>();
            this.dataGridViewНаселені_Пункти.Rows.Add();

            for (int i = 0; i < dataVillage.Count; i++)
            {
                string count1 = "SELECT COUNT(*) FROM people WHERE village = '" + dataVillage[i].Name.ToString() + "' AND registr = 'так'";
                count_v.Add(count1);
            }


            int all = 0;
            int sum;
            List<int> sum_v = new List<int>();
            for (int i = 0; i < dataVillage.Count; i++)
            {
                MySqlCommand search = new MySqlCommand(count_v[i], _manager.getConnection());
                if(search.ExecuteScalar().ToString() == "")
                {
                    sum = 0;
                }
                else
                {
                    sum = Convert.ToInt32(search.ExecuteScalar());
                }
                 
                all += sum;
                sum_v.Add(sum);
            }

            dataGridViewНаселені_Пункти.Rows[0].Cells[0].Value = Convert.ToInt32(DateTime.Now.Year.ToString());
            for (int i = 0; i < dataVillage.Count; i++)
            {
                dataGridViewНаселені_Пункти.Rows[0].Cells[i + 1].Value = sum_v[i];
            }

            dataGridViewНаселені_Пункти.Rows[0].Cells[dataVillage.Count + 1].Value = all;

        }

        private void buttonВихідЗПрограми_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}  
