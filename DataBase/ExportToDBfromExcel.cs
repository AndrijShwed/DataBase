using MySqlConnector;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DataBase
{
    
    public partial class ExportToDBfromExcel: Form
    {

        public void InitializeEPPlusLicense()
        {
            // Встановлюємо ліцензійний контекст
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Для некомерційного використання
        }

        private string excelFilePath;

        public ExportToDBfromExcel()
        {
            InitializeComponent();
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Стартова папка
                openFileDialog.Filter = "Всі файли (*.*)|*.*"; // Фільтр файлів
                openFileDialog.Title = "Виберіть файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelFilePath = openFileDialog.FileName;
                    textBoxFilePath.Text = excelFilePath; // Відображаємо вибраний шлях
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            InitializeEPPlusLicense();

            if (textBoxFilePath.Text == "" || textBoxTableOfDB.Text == "")
            {
                MessageBox.Show("Спочатку заповніть поля вибору файлу та таблиці БД");
                return;
            }

            ConnectionClass _manager = new ConnectionClass();
            _manager.openConnection();


            try
            {
                using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Перший аркуш
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    string table = textBoxTableOfDB.Text;

                    for (int row = 3; row <= rowCount; row++) // Пропускаємо заголовок
                    {
                        string PIP = worksheet.Cells[row, 1].Text;
                        string village = worksheet.Cells[row, 2].Text;
                        string plotNumber = worksheet.Cells[row, 3].Text;
                        string tenant = worksheet.Cells[row, 4].Text;
                        string plowedLandNumber = worksheet.Cells[row, 5].Text;
                        double plowedLandArea = Convert.ToDouble(worksheet.Cells[row, 6].Value);
                        string hayField1Number = worksheet.Cells[row, 7].Text;
                        double hayField1Area = Convert.ToDouble(worksheet.Cells[row, 8].Value);
                        string hayField2Number = worksheet.Cells[row, 9].Text;
                        double hayField2Area = Convert.ToDouble(worksheet.Cells[row, 10].Value);

                        string query = "INSERT INTO  " + table + " (fullname, village, plotnumber, tenant, plowedlandnumber, " +
                            "plowedlandarea, hayfield1number, hayfield1area, hayfield2number, hayfield2area) " +
                            "VALUES (@col1, @col2, @col3, @col4, @col5, @col6, @col7, @col8, @col9, @col10)";
                        using (var cmd = new MySqlCommand(query, _manager.getConnection()))
                        {
                            cmd.Parameters.AddWithValue("@col1", PIP);
                            cmd.Parameters.AddWithValue("@col2", village);
                            cmd.Parameters.AddWithValue("@col3", plotNumber);
                            cmd.Parameters.AddWithValue("@col4", tenant);
                            cmd.Parameters.AddWithValue("@col5", plowedLandNumber);
                            cmd.Parameters.AddWithValue("@col6", plowedLandArea);
                            cmd.Parameters.AddWithValue("@col7", hayField1Number);
                            cmd.Parameters.AddWithValue("@col8", hayField1Area);
                            cmd.Parameters.AddWithValue("@col9", hayField2Number);
                            cmd.Parameters.AddWithValue("@col10", hayField2Area);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Дані імпортовано!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }

    }
}
