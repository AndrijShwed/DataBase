using DataBase.Services;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DataBase
{
    public partial class ПочатокРоботи : Form
    {
        private List<VillageStreetInfo> data = new List<VillageStreetInfo> ();
        // User user = new User ();
        bool mess = false;
        public ПочатокРоботи()
        {
            InitializeComponent();
            HeaderOfTable();
        }

        private void HeaderOfTable()
        {
            this.dataGridViewПочатокРоботи.DefaultCellStyle.Font = new Font("TimeNewRoman", 10);
            this.dataGridViewПочатокРоботи.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            this.dataGridViewПочатокРоботи.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
            this.dataGridViewПочатокРоботи.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewПочатокРоботи.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkOrange;
            this.dataGridViewПочатокРоботи.EnableHeadersVisualStyles = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 50;
            column1.Name = "Номер";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Населений пункт";
            column2.Width = 235;
            column2.Name = "village";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Вулиця";
            column3.Width = 235;
            column3.Name = "street";
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Дата зміни назви";
            column4.Width = 200;
            column4.Name = "changeDate";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Видалити";
            column5.Width = 95;
            column5.Name = "delete";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "id";
            column6.Width = 40;
            column6.Name = "id";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();
            column6.Visible = false;

            dataGridViewПочатокРоботи.Columns.Add(column1);
            dataGridViewПочатокРоботи.Columns.Add(column2);
            dataGridViewПочатокРоботи.Columns.Add(column3);
            dataGridViewПочатокРоботи.Columns.Add(column4);
            dataGridViewПочатокРоботи.Columns.Add(column5);
            dataGridViewПочатокРоботи.Columns.Add(column6);
            
            dataGridViewПочатокРоботи.AllowUserToAddRows = false;
            dataGridViewПочатокРоботи.ReadOnly = true;

            LoadVillageStreets();

        }

        private void AddDataGrid(VillageStreetInfo row)
        {
            dataGridViewПочатокРоботи.Rows.Add(row.VillageName, row.StreetName, row.RenameDate);
        }

        public class VillageStreetInfo
        {
            public int VillagestreetId { get; set; }
            public int VillageId { get; set; }
            public string VillageName { get; set; }
            public int StreetId { get; set; }
            public string StreetName { get; set; }
            public bool IsActive { get; set; }
            public DateTime? RenameDate { get; set; }
        }

        
        private void LoadVillageStreets()
        {
            AddressService addressService = new AddressService();

            data.Clear();
            dataGridViewПочатокРоботи.DataSource = null;
            dataGridViewПочатокРоботи.Rows.Clear();

            data = addressService.GetAllVillagesStreets();

            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid(data[i]);
                dataGridViewПочатокРоботи.Rows[i].Cells[0].Value = i + 1;
                dataGridViewПочатокРоботи.Rows[i].Cells[1].Value = data[i].VillageName;
                dataGridViewПочатокРоботи.Rows[i].Cells[2].Value = data[i].StreetName;
                dataGridViewПочатокРоботи.Rows[i].Cells[3].Value = data[i].RenameDate?.ToString("dd.MM.yyyy");
                dataGridViewПочатокРоботи.Rows[i].Cells[5].Value = data[i].VillagestreetId;
                dataGridViewПочатокРоботи.Rows[i].Cells[4].Value = "Видалити";
                dataGridViewПочатокРоботи.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.DarkRed;
                dataGridViewПочатокРоботи.Rows[i].Cells[4].Style.ForeColor = System.Drawing.Color.White;
                dataGridViewПочатокРоботи.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця пуста, заповніть дані !");
            }
            

            // За бажанням:
            //dataGridViewПочатокРоботи.Columns["SettlementId"].Visible = false;
            //dataGridViewПочатокРоботи.Columns["StreetId"].Visible = false;
            //dataGridViewПочатокРоботи.Columns["SettlementName"].HeaderText = "Населений пункт";
            //dataGridViewПочатокРоботи.Columns["StreetName"].HeaderText = "Вулиця";
            //dataGridViewПочатокРоботи.Columns["IsActive"].HeaderText = "Активна";
            //dataGridViewПочатокРоботи.Columns["RenameDate"].HeaderText = "Дата перейменування";
        }



        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = System.Windows.Forms.Application.OpenForms.OfType<Головна>().FirstOrDefault();
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

        private void повернутисьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            this.Hide();
            form.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ДодатиВТаблицю_Click(object sender, EventArgs e)
        {
            string village = Convert.ToString(НазваНасПункту.Text);
            string street = Convert.ToString(НазваВулиці.Text);

            AddressService _addressService = new AddressService();
            _addressService.AddStreetToVillage(village, street);

            MessageBox.Show("Вулицю додано");

            LoadVillageStreets();
        }

        private void dataGridViewПочатокРоботи_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // user = new User();

           // if (user.userName == "A")
            //{

                if (e.ColumnIndex == 3)
                {
                    DataGridViewRow row = dataGridViewПочатокРоботи.Rows[e.RowIndex];


                    if (MessageBox.Show(string.Format("Ви дійсно бажаєте видалити цей рядок ?", row.Cells["Номер"].Value), "Погоджуюсь",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ConnectionClass _manager = new ConnectionClass();
                        _manager.openConnection();

                        string com = "DELETE FROM `villagestreet` WHERE(`id` = '" + row.Cells[4].Value + "')";

                    MySqlCommand dell = new MySqlCommand(com, _manager.getConnection());


                        if (dell.ExecuteNonQuery() == 1)
                        {
                            dataGridViewПочатокРоботи.Rows.RemoveAt(row.Index);
                            MessageBox.Show("Дані успішно видалено ");
                            _manager.closeConnection();
                        }
                        else
                        {
                            MessageBox.Show("Помилка роботи з базою даних !!!");
                        }

                    }
                }
            //}
            //else
            //{
            //    MessageBox.Show("У вас немає доступу до видалення даних з таблиці !");
            //}

        }

    }
}
