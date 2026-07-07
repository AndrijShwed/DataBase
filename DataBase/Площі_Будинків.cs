using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Площі_Будинків : Form
    {
        //private User user;
        List<RowOfVillageArea> _data = new List<RowOfVillageArea>();
        List<Village> dataVillage = new List<Village>();
        List<Street> dataStreet = new List<Street>();

        public Площі_Будинків()
        {
            InitializeComponent();
            HeaderOfTheTable();

        }
        private void HeaderOfTheTable()
        {
            //bool mess = false;
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

            this.dataGridViewArea.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewArea.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridViewArea.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewArea.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewArea.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            this.dataGridViewArea.EnableHeadersVisualStyles = false;
            this.dataGridViewArea.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Рік";
            column1.Width = 70;
            column1.Name = "year";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            List<DataGridViewColumn> col = new List<DataGridViewColumn>();
            int k = 3;
            for (int i = 0; i < dataVillage.Count; i++)
            {
               
                var columnk = new DataGridViewColumn();
                columnk.HeaderText = dataVillage[i].Name.ToString()+" заг.пл.";
                columnk.Width = 100;
                columnk.Frozen = true;
                columnk.CellTemplate = new DataGridViewTextBoxCell();
                col.Add(columnk);
                k++;
                columnk = new DataGridViewColumn();
                columnk.HeaderText = dataVillage[i].Name.ToString() + " житл.пл.";
                columnk.Width = 100;
                columnk.Frozen = true;
                columnk.CellTemplate = new DataGridViewTextBoxCell();
                col.Add(columnk);
                k++;
            }
            int s = k;
            var columns = new DataGridViewColumn();
            columns.HeaderText = "Всього заг. пл.";
            columns.Width = 100;
            columns.Name = "all";
            columns.Frozen = true;
            columns.CellTemplate = new DataGridViewTextBoxCell();

            int l = s++;
            var columnl= new DataGridViewColumn();
            columnl.HeaderText = "Всього житл. пл.";
            columnl.Width = 100;
            columnl.Name = "all";
            columnl.Frozen = true;
            columnl.CellTemplate = new DataGridViewTextBoxCell();


            dataGridViewArea.Columns.Add(column1);
           
            for (int i = 0; i < col.Count; i++)
            {
                dataGridViewArea.Columns.Add(col[i]);
            }

            dataGridViewArea.Columns.Add(columns);
            dataGridViewArea.Columns.Add(columnl);


            dataGridViewArea.AllowUserToAddRows = false;
            dataGridViewArea.ReadOnly = true;
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

        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void Оновити_Click(object sender, EventArgs e)
        {
            dataGridViewArea.DataSource = null;
            dataGridViewArea.Rows.Clear();

            _data.Clear();

            //user = new User();

            ConnectionClass _manager = new ConnectionClass();
            _manager.openConnection();
           
            this.dataGridViewArea.Rows.Add();

            decimal total;
            decimal living;

            List<decimal> tot = new List<decimal>();
            List<decimal> liv = new List<decimal>();

            for (int i = 0; i < dataVillage.Count; i++)
            {
                string sql = @"
                    SELECT
                        IFNULL(SUM(h.totalArea),0) AS TotalArea,
                        IFNULL(SUM(h.livingArea),0) AS LivingArea
                    FROM houses h
                    INNER JOIN villagestreet vs ON h.villagestreetId = vs.Id
                    INNER JOIN villages v ON vs.villageId = v.Id
                    WHERE v.Name = @village;";

                MySqlCommand cmd = new MySqlCommand(sql, _manager.getConnection());
                cmd.Parameters.AddWithValue("@village", dataVillage[i].Name);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        total = reader.GetDecimal("TotalArea");
                        living = reader.GetDecimal("LivingArea");

                        tot.Add(total);
                        liv.Add(living);
                    }
                }
            }

            decimal all_total = 0;
            decimal all_living = 0;

            for (int i = 0; i < tot.Count ; i++)
            {
                all_total += tot[i];
                all_living += liv[i];
            }

            int r = 0;

            dataGridViewArea.Rows[r].Cells[0].Value = Convert.ToInt32(DateTime.Now.Year.ToString());
            int k = 0;
            for (int i = 0; i< tot.Count; i++)
            {
                dataGridViewArea.Rows[r].Cells[k+1].Value = tot[i].ToString();
                dataGridViewArea.Rows[r].Cells[k+2].Value = liv[i].ToString();
                k += 2;
            }
           
            dataGridViewArea.Rows[r].Cells[k+1].Value = all_total;
            dataGridViewArea.Rows[r].Cells[k+2].Value = all_living;    
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
        }
    }
}
