using MySqlConnector;
using System;

namespace DataBase
{
    public class Person
    {
        public int people_id { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string sex { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string village { get; set; }
        public string street { get; set; }
        public string numb_of_house { get; set; }
        public string passport { get; set; }
        public string description { get; set; }
        public string id_kod { get; set; }
        public string phone_numb { get; set; }
        public string status { get; set; }
        public string registr { get; set; }
        public DateTime? M_Year { get; set; }
        public string Mil_ID { get; set; }
        
        public Person() { }
        public static Person ReadOne(MySqlDataReader reader)
        {
            return new Person
            {
                people_id = reader.GetInt32(reader.GetOrdinal("people_id")),
                lastname = reader["lastname"] as string,
                name = reader["name"] as string,
                surname = reader["surname"] as string,
                sex = reader["sex"] as string,
                date_of_birth = reader["date_of_birth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["date_of_birth"]),
                village = reader["village"] as string,
                street = reader["street"] as string,
                numb_of_house = reader["numb_of_house"] as string,
                passport = reader["passport"] as string,
                id_kod = reader["id_kod"] as string,
                phone_numb = reader["phone_numb"] as string,
                status = reader["status"] as string,
                registr = reader["registr"] as string,
                M_Year = reader["m_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["m_date"]),
                Mil_ID = reader["mil_ID"] as string,
                description = reader["description"] as string
            };
        }
    }
}
