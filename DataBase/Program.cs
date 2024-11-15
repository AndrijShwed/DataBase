using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DataBase
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            // Шлях до файлу appsettings.json
            string filePath = "appsettings.json";

            // Завантажуємо налаштування з файлу
            var settings = ConfigurationManager.LoadAppSettings(filePath);

            if (settings != null)
            {
                // Отримуємо рядок з'єднання
                string connectionString = settings.connectionStrings.DefaultConnection;
                Console.WriteLine($"Connection String: {connectionString}");

                // Використовуємо ADO.NET для підключення до бази даних
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Виконання запитів або команд з базою даних
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Авторизація());
            Application.Run(new Головна());
        }
    }
}
