using DataBase;
using Newtonsoft.Json;
using System;
using System.IO;
public class ConfigurationManager
{
    public static AppSettings LoadAppSettings(string filePath)
    {
        try
        {
            // Читаємо весь вміст файлу appsettings.json
            var json = File.ReadAllText(filePath);

            // Десеріалізуємо JSON у об'єкт AppSettings
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
        catch (Exception ex)
        {
            // Логування помилок, якщо файл не можна прочитати
            Console.WriteLine($"Error loading appsettings.json: {ex.Message}");
            return null;
        }
    }
}
