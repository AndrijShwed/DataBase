using DataBase.Services;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            dataGridViewПочатокРоботи.CellContentClick += dataGridView1_CellContentClick;
            dataGridViewПочатокРоботи.CellFormatting += dataGridView1_CellFormatting;
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
            column4.HeaderText = "Стара назва вулиці";
            column4.Width = 235;
            column4.Name = "oldStreet";
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Дата зміни назви";
            column5.Width = 200;
            column5.Name = "changeDate";
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Видалити";
            column6.Width = 95;
            column6.Name = "delete";
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "id";
            column7.Width = 40;
            column7.Name = "id";
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();
            column7.Visible = false;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "OpenFile";
            btn.HeaderText = "Файл";
            btn.Text = "відкрити";
            btn.UseColumnTextForButtonValue = false;
            btn.Width = 80;

            dataGridViewПочатокРоботи.Columns.Add(column1);
            dataGridViewПочатокРоботи.Columns.Add(column2);
            dataGridViewПочатокРоботи.Columns.Add(column3);
            dataGridViewПочатокРоботи.Columns.Add(column4);
            dataGridViewПочатокРоботи.Columns.Add(column5);
            dataGridViewПочатокРоботи.Columns.Add(column6);
            dataGridViewПочатокРоботи.Columns.Add(column7);
            dataGridViewПочатокРоботи.Columns.Add(btn);

            dataGridViewПочатокРоботи.AllowUserToAddRows = false;
            dataGridViewПочатокРоботи.ReadOnly = true;

            LoadVillageStreets();

        }

        private void AddDataGrid(VillageStreetInfo row)
        {
            dataGridViewПочатокРоботи.Rows.Add(row.VillageName, row.StreetName, row.OldStreetName, row.RenameDate);
        }

        public class VillageStreetInfo
        {
            public int VillagestreetId { get; set; }
            public int VillageId { get; set; }
            public string VillageName { get; set; }
            public int StreetId { get; set; }
            public string StreetName { get; set; }
            public string OldStreetName { get; set; }
            public bool IsActive { get; set; }
            public DateTime? RenameDate { get; set; }

            public byte[] FileData { get; set; }
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
                dataGridViewПочатокРоботи.Rows[i].Cells[3].Value = data[i].OldStreetName;
                dataGridViewПочатокРоботи.Rows[i].Cells[4].Value = data[i].RenameDate?.ToString("dd.MM.yyyy");
                dataGridViewПочатокРоботи.Rows[i].Cells[6].Value = data[i].VillagestreetId;
                dataGridViewПочатокРоботи.Rows[i].Cells[5].Value = "Видалити";
                dataGridViewПочатокРоботи.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.DarkRed;
                dataGridViewПочатокРоботи.Rows[i].Cells[5].Style.ForeColor = System.Drawing.Color.White;
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

           // if (user.userName == "A")
            //{

                if (e.ColumnIndex == 5)
                {
                    DataGridViewRow row = dataGridViewПочатокРоботи.Rows[e.RowIndex];
                    
                    string streetName = row.Cells[2].Value.ToString();
                    string villageName = row.Cells[1].Value.ToString();

                if (MessageBox.Show($"Ви дійсно бажаєте видалити вулицю <<{streetName}>> у населеному пункті <<{villageName}>>  ?", "Погоджуюсь",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ConnectionClass _manager = new ConnectionClass();
                        _manager.openConnection();

                        string com = "DELETE FROM `villagestreet` WHERE(`id` = '" + row.Cells[6].Value + "')";

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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridViewПочатокРоботи.Columns[e.ColumnIndex].Name == "OpenFile")
            {
                var row = dataGridViewПочатокРоботи.Rows[e.RowIndex].DataBoundItem as VillageStreetInfo;

                if (row?.FileData == null || row.FileData.Length == 0)
                    return; // ❌ нема файлу — нічого не робимо

                OpenFileFromBytes(row.FileData);
            }
        }


        private void OpenFileFromBytes(byte[] fileData)
        {
            string tempPath = Path.Combine(
                Path.GetTempPath(),
                "street_file_" + Guid.NewGuid()
            );

            File.WriteAllBytes(tempPath, fileData);

            Process.Start(new ProcessStartInfo
            {
                FileName = tempPath,
                UseShellExecute = true
            });
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewПочатокРоботи.Columns[e.ColumnIndex].Name != "OpenFile" || e.RowIndex < 0)
                return;

            var row = dataGridViewПочатокРоботи.Rows[e.RowIndex].DataBoundItem as VillageStreetInfo;

            if (row?.FileData != null && row.FileData.Length > 0)
            {
                e.Value = "Відкрити";
                e.FormattingApplied = true;
            }
            else
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

    }
}
