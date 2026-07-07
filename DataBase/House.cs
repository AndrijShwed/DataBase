using MySqlConnector;
using System;

namespace DataBase
{
    public class House
    {
        public int idhouses { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string village { get; set; }
        public string street { get; set; }
        public string numb_of_house { get; set; }
        public double livingArea { get; set; }
        public double totalArea { get; set; }
        public int total_of_rooms { get; set; }

        public House() { }
        public static House ReadOne(MySqlDataReader reader)
        {
            return new House
            {
                idhouses = reader.GetInt32(reader.GetOrdinal("idhouses")),
                village = GetString(reader, "village"),
                street = GetString(reader, "street"),
                numb_of_house = GetString(reader, "numb_of_house"),
                lastname = GetString(reader, "lastname"),
                name = GetString(reader, "name"),
                surname = GetString(reader, "surname"),
                totalArea = GetDouble(reader, "totalArea"),
                livingArea = GetDouble(reader, "livingArea"),
                total_of_rooms = GetInt(reader, "total_of_rooms")
            };
        }


        public static string GetString(MySqlDataReader reader, string fieldName)
        {
            return reader[fieldName] == DBNull.Value ? "" : reader[fieldName].ToString();
        }

        public static int GetInt(MySqlDataReader reader, string fieldName)
        {
            return reader[fieldName] == DBNull.Value ? 0 : Convert.ToInt32(reader[fieldName]);
        }

        public static double GetDouble(MySqlDataReader reader, string fieldName)
        {
            return reader[fieldName] == DBNull.Value ? 0 : Convert.ToDouble(reader[fieldName]);
        }

    }

}
