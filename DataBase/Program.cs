using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            //Головна form = new Головна();
            Авторизація form = new Авторизація();
            form.FormClosed += (s, e) =>
            {
                // Якщо більше немає відкритих форм, завершуємо додаток
                if (Application.OpenForms.Count == 0)
                    Application.Exit();
            };

            form.Show();

            Application.Run();
        }

        // Допоміжний метод для відкриття будь-якої іншої форми
        public static void OpenForm(Form currentForm, Form newForm)
        {
            // Обробка закриття нової форми
            newForm.FormClosed += (s, args) =>
            {
                // Показуємо попередню форму, якщо вона ще існує
                if (!currentForm.IsDisposed)
                    currentForm.Show();
            };

            // Ховаємо поточну форму
            currentForm.Hide();

            // Показуємо нову форму
            newForm.Show();
        }
    }
}
