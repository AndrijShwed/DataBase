using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public partial class ПоКількостіКімнат : Form
    {

        //private User user;
        List<RowCountOfRooms> _data = new List<RowCountOfRooms>();
        List<Village> dataVillage = new List<Village>();
        List<Street> dataStreet = new List<Street>();
      
        DataGridView dataGridView;

        public ПоКількостіКімнат()
        {
            InitializeComponent();
            HeaderOfTheTable(dataGridViewTab);
           
           
        }

        private void HeaderOfTheTable(DataGridView _dataGridView)
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

            this.dataGridView = _dataGridView;
            this.dataGridView.DefaultCellStyle.Font = new Font("TimeNewRoman", 12);
            this.dataGridView.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Italic);
            this.dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            this.dataGridView.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Населений пункт";
            column1.Width = 100;
            column1.Name = "village";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Рік";
            column2.Width = 100;
            column2.Name = "year";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Одно кімн.";
            column3.Width = 150;
            column3.Name = "one";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Дво кімн.";
            column4.Width = 150;
            column4.Name = "two";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Три кімн.";
            column5.Width = 150;
            column5.Name = "three";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Чотири кімн.";
            column6.Width = 150;
            column6.Name = "four";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "П'ять кімн.";
            column7.Width = 150;
            column7.Name = "five";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Шість кімн.";
            column8.Width = 150;
            column8.Name = "six";
            column8.Frozen = true;
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Більше шести кімн.";
            column9.Width = 150;
            column9.Name = "more";
            column9.Frozen = true;
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Загальна";
            column10.Width = 150;
            column10.Name = "total";
            column10.Frozen = true;
            column10.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.Columns.Add(column6);
            dataGridView.Columns.Add(column7);
            dataGridView.Columns.Add(column8);
            dataGridView.Columns.Add(column9);
            dataGridView.Columns.Add(column10);

            dataGridView.AllowUserToAddRows = false;
            dataGridView.ReadOnly = true;
        }


        private void домогосподарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
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

        private void вихідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Домогосподарства form = new Домогосподарства();
            Program.OpenForm(this, form);
        }

        private void AddDataGrid(RowCountOfRooms row, DataGridView _dataGridView)
        {
            dataGridView = _dataGridView;
            dataGridView.Rows.Add(row.id, row.year, row.one_rooms, row.two_rooms,
                row.three_rooms, row.four_rooms, row.five_rooms, row.six_rooms,
                row.more_rooms, row.total);
        }


        private void Оновити_дані_Click(object sender, EventArgs e)
        {
            dataGridViewTab.DataSource = null;
          
            dataGridViewTab.Rows.Clear();
           
            _data.Clear();
           
            //user = new User();

            MessageBox.Show("Зачекайте !");

            ConnectionClass _manager = new ConnectionClass();
           
            string CountRooms(string _village, int _c)
            {
                string village = _village;
                int z = _c;
                string count = "SELECT COUNT(*) FROM houses WHERE village = '" + village + "' AND total_of_rooms = '" + z + "'";
                return count;
            }

            string CountRoomsMore(string _village)
            {
                string village = _village;
                int k = 6;
                string count = "SELECT COUNT(*) FROM houses WHERE village = '" + village + "' AND total_of_rooms > '"+ k +"'";
                return count;
            }
           
            MySqlCommand search;
            _manager.openConnection();
            int[] vill = new int[7];
            int c;

            int total = 0;
            for (int k = 0; k < dataVillage.Count; k++)
            {
                dataGridViewTab.Rows.Add();
                dataGridViewTab.Rows[k].Cells[0].Value = dataVillage[k].Name.ToString();
                dataGridViewTab.Rows[k].Cells[1].Value = Convert.ToInt32(DateTime.Now.Year.ToString());
                total = 0;
                for (int i = 0; i < 6; i++)
                {
                    c = i + 1;
                    search = new MySqlCommand(CountRooms(dataVillage[k].Name.ToString(), c), _manager.getConnection());

                    try
                    {
                        vill[i] = Convert.ToInt32(search.ExecuteScalar());
                    }
                    catch
                    {
                        MessageBox.Show("Помилка !");
                    }
                    dataGridViewTab.Rows[k].Cells[i + 2].Value = vill[i];
                    total += vill[i];
                }
                search = new MySqlCommand(CountRoomsMore(dataVillage[k].Name.ToString()), _manager.getConnection());
                vill[6] = Convert.ToInt32(search.ExecuteScalar());
                dataGridViewTab.Rows[k].Cells[8].Value = vill[6];
                total += vill[6];
                dataGridViewTab.Rows[k].Cells[9].Value = total;
               
            }

            _manager.closeConnection();
           
        }


    }
}
