using MySqlConnector;
using System;
using System.IO;

namespace DataBase
{ 
    public class ConnectionClass : IDisposable
    {
        // Замість абсолютного шляху, можна комбінувати з поточною директорією
        static string filePath1 = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\DataBase\appsettings.json");

        // Очищаємо шлях (щоб вийти з каталогу bin\Debug або bin\Release)
        static string filePath = Path.GetFullPath(filePath1);  // Отримаємо абсолютний шлях

        static string connStr = ConfigurationManager.LoadAppSettings(filePath).connectionStrings.DefaultConnection;

        MySqlConnection sqlConn = new MySqlConnection(connStr);

        public void openConnection()
        {
            if (sqlConn.State == System.Data.ConnectionState.Closed)
            {
                sqlConn.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return sqlConn;
        }

        public void Dispose()
        {
            closeConnection();
            sqlConn?.Dispose();
        }
    }
}